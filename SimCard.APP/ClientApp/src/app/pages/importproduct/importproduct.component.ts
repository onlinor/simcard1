import { Component, OnInit, ViewChild } from '@angular/core';
import { FormphieuchiComponent } from '../../public/formphieuchi/formphieuchi.component';

import {
  FileService,
  ProductService,
  PhieunhapService,
  SupplierService,
  ProductExchangeService
} from '../../core/services';
import { Product, ImportReceipt, Supplier, ProductExchange } from '../../core/models';

@Component({
  selector: 'app-importproduct',
  templateUrl: './importproduct.component.html',
  styleUrls: ['./importproduct.component.css']
})
export class ImportProductComponent implements OnInit {
  @ViewChild(FormphieuchiComponent)
  myFormChiChild: FormphieuchiComponent;

  LoaiNganHang = [
    { label: 'Chọn', value: 'default' },
    { label: 'Agribank', value: 'AGB' },
    { label: 'Vietcombank', value: 'VCB' },
    { label: 'Viettinbank', value: 'VTB' },
    { label: 'VPbank', value: 'VPB' },
    { label: 'Techcombank', value: 'TCB' },
    { label: 'Shinhanbank', value: 'SHB' },
    { label: 'Sacombank', value: 'SCB' },
    { label: 'DongABank', value: 'DAB' },
    { label: 'AChauBank', value: 'ACB' }
  ];

  loaiNganHang: String = '';

  tableProducts: Array<Product> = [];

  tabviewProducts: Array<Product> = [];

  tabviewProductExchanges: Array<ProductExchange> = [];

  suppliers: Array<Supplier> = [];

  totalMoney = 0;

  vatMoney = 0;

  total = 0;

  thanhToan = 0;

  payBank = 0;
  isPaybankChecked = false;

  payCash = 0;
  isPaycashChecked = false;

  isShowDialogPhieuChi: Boolean = false;

  importReceipt: ImportReceipt = new ImportReceipt();

  todayDate: Date;
  receiptNCC: string;

  constructor(
    private fileService: FileService,
    private productService: ProductService,
    private phieuhangService: PhieunhapService,
    private supplierService: SupplierService,
    private productExchangeService: ProductExchangeService
  ) {}

  ngOnInit() {
    this.getAllProducts();
    this.getAllProductExchanges();
    this.getSuppliers();
    this.todayDate = new Date();
  }

  onChangeIsPaybankChecked() {
    if (!this.isPaybankChecked) {
      this.thanhToan = this.thanhToan - this.payBank;
      this.payBank = 0;
      this.loaiNganHang = '';
    }
  }

  onChangeIsPaycashChecked() {
    if (!this.isPaycashChecked) {
      this.thanhToan = this.thanhToan - this.payCash;
      this.payCash = 0;
    }
  }

  onChangePaybank() {
    this.thanhToan = this.payBank + this.payCash;
  }

  onChangePaycash() {
    this.thanhToan = this.payBank + this.payCash;
  }

  onGetIsShowDialogPhieuChi(data: any) {
    this.isShowDialogPhieuChi = data;
  }

  save() {
    this.productService.save(this.tableProducts).subscribe(() => {
      this.getAllProducts();
      this.savePhieunhap();

      this.tableProducts = [];
    });
  }

  uploadProductList(event: any) {
    const fileList: FileList = event.files;
    if (fileList.length > 0) {
      const file: File = fileList[0];
      const formData = new FormData();
      formData.append(file.name, file);

      this.fileService
        .uploadProductList(formData)
        .subscribe((response: Array<Product>) => {
          this.tableProducts = Object.assign(this.tableProducts, response);

          // Update donGia and thanhTien, shopID is belong-ed to for each product
          // (Save time, may put it somewhere else without any function,..)
          this.tableProducts.forEach(element => {
            element.donGia =
              (element.menhGia / 100) * (100 - element.chietKhau);
            element.thanhTien =
              element.soLuong *
              (element.menhGia - (element.menhGia * element.chietKhau) / 100);
            element.shopId = 1;
             switch (element.ma.substr(0, 2)) {
               case 'DT': {
                 element.loai = 'DT';
                 break;
                 }
                default: {
                element.loai = 'SIM';
                break;
                }
             }
          });
          this.updateTotalMoney();
        });
    }
  }

  getAllProducts() {
    this.productService.getAll().subscribe(response => {
      this.tabviewProducts = response;
    });
  }

  getAllProductExchanges() {
    this.productExchangeService.getAll().subscribe(response => {
      this.tabviewProductExchanges = response;
    });
  }

  onProductTableEditCompleted(event: any) {
    // Update donGia and thanhTien for each product(Save time, may put it somewhere else without any function,..)
    const selectedProduct = this.tableProducts.find(
      x => x.ma === event.data.ma
    );
    selectedProduct.donGia =
      (selectedProduct.menhGia / 100) * (100 - selectedProduct.chietKhau);
    selectedProduct.thanhTien =
      selectedProduct.soLuong *
      (selectedProduct.menhGia -
        (selectedProduct.menhGia * selectedProduct.chietKhau) / 100);
    this.updateTotalMoney();
  }

  onDropdownValueChange(event: any) {
    this.receiptNCC = event.value.name;
    this.tableProducts.forEach(element => {
      element.supplierId = event.value.id;
    });
    this.importReceipt.supplierId = event.value.id;
  }

  rowEditCompleted(event: any) {
    if (event.data.soluongnhap === 0 || event.data.soluongnhap === null) {
      console.log('Input is not correct, please try again');
    } else {
      const selectedProduct = this.tableProducts.find(
        x => x.ma === event.data.ma
      );
      if (selectedProduct) {
        selectedProduct.donGia =
          (selectedProduct.menhGia * (100 - selectedProduct.chietKhau)) / 100;
        selectedProduct.thanhTien =
          selectedProduct.soLuongNhap * selectedProduct.donGia;
      }
      this.updateTotalMoney();
    }
  }

  onProductExchangeSelected(event: any) {
    const selectedProduct = this.tableProducts.find(
      x => x.ma === event.data.ma
    );
    if (selectedProduct) {
      // Do nothing
    } else {
      const product: Product = {
        ten: event.ten,
        ma: event.ma,
        chietKhau: 0,
        soLuong: 0,
        id: null,
        loai: null,
        menhGia: event.menhgia,
        donGia: null,
        thanhTien: null
      };
      this.tableProducts.push(product);
    }
    this.updateTotalMoney();
  }

  updateTotalMoney() {
    this.totalMoney = 0;
    this.tableProducts.forEach(line => {
      this.totalMoney +=
        line.soLuong * (line.menhGia - (line.menhGia * line.chietKhau) / 100);
    });
    this.vatMoney = (this.totalMoney * 10) / 100;
    this.total = this.totalMoney + this.vatMoney;
  }

  isProductexist(ma: string, tables: Product[]): Boolean {
    if (tables.findIndex(x => x.ma === ma) !== -1) {
      return true;
    }
    return false;
  }

  generateProductCode() {
    this.phieuhangService.getProductCode().subscribe(resp => {
      this.importReceipt.ma = resp.ma;
    });
  }

  getSuppliers() {
    this.supplierService.getAll().subscribe(response => {
      this.suppliers = response;
    });
  }

  dataImportProductBinding() {
    this.myFormChiChild.dataPhieuChi.loaiNganHang = this.loaiNganHang;
    (this.myFormChiChild.dataPhieuChi.nguoiChi = this.importReceipt.nhanVienLap),
      (this.myFormChiChild.dataPhieuChi.tenKhachHang = this.importReceipt.nguoiDaiDien),
      (this.myFormChiChild.dataPhieuChi.soTienChi = this.thanhToan),
      (this.myFormChiChild.isATM = this.isPaybankChecked),
      (this.myFormChiChild.isCash = this.isPaycashChecked);
    this.myFormChiChild.checkedATM();
    this.myFormChiChild.checkedCash();
    this.myFormChiChild.isNewCashBook = true;
    this.isShowDialogPhieuChi = true;
  }

  savePhieunhap() {
    this.importReceipt.prefix = this.importReceipt.ma.substring(0, 10);
    this.importReceipt.suffix = Number(this.importReceipt.ma.substr(11));
    this.importReceipt.tienThanhToan = this.thanhToan;
    this.importReceipt.tienConLai = this.total - this.thanhToan;
    this.importReceipt.products = this.tableProducts;
    this.importReceipt.shopId = 1;
    this.phieuhangService.addPhieunhap(this.importReceipt).subscribe(() => {});
    this.dataImportProductBinding();
  }

  destroyTickiet() {
    this.tableProducts.length = 0;
    this.importReceipt.ma = '';
    this.importReceipt.ghiChu = '';
    this.importReceipt.prefix = '';
    this.importReceipt.products = null;
    this.importReceipt.suffix = null;
    this.importReceipt.supplierId = null;
    this.importReceipt.tongTien = 0;
    this.importReceipt.nguoiDaiDien = '';
    this.importReceipt.nhanVienLap = '';
    this.importReceipt.soDienThoai = null;
    this.importReceipt.tongTien = 0;
    this.importReceipt.tienThanhToan = 0;
    this.importReceipt.congNoCu = 0;
    this.totalMoney = 0;
    this.vatMoney = 0;
    this.total = 0;
    this.thanhToan = 0;
  }

  print(): void {
    let printContents, popupWin;
    printContents = document.getElementById('print-section').innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
          @media print {
            @media print {
              [class*="col-sm-"] {
                float: left;
              }
            }
            .col-sm-1, .col-sm-2, .col-sm-3, .col-sm-4, .col-sm-5, .col-sm-6, .col-sm-7, .col-sm-8, .col-sm-9, .col-sm-10,
             .col-sm-11, .col-sm-12 {
              float: left;
            }
            .col-sm-12 {
              width: 100%;
            }
            .col-sm-11 {
              width: 91.66666667%;
            }
            .col-sm-10 {
              width: 83.33333333%;
            }
            .col-sm-9 {
              width: 75%;
            }
            .col-sm-8 {
              width: 66.66666667%;
            }
            .col-sm-7 {
              width: 58.33333333%;
            }
            .col-sm-6 {
              width: 50%;
            }
            .col-sm-5 {
              width: 41.66666667%;
            }
            .col-sm-4 {
              width: 33.33333333%;
            }
            .col-sm-3 {
              width: 25%;
            }
            .col-sm-2 {
              width: 16.66666667%;
            }
            .col-sm-1 {
              width: 8.33333333%;
            }
            .col-sm-pull-12 {
              right: 100%;
            }
            .col-sm-pull-11 {
              right: 91.66666667%;
            }
            .col-sm-pull-10 {
              right: 83.33333333%;
            }
            .col-sm-pull-9 {
              right: 75%;
            }
            .col-sm-pull-8 {
              right: 66.66666667%;
            }
            .col-sm-pull-7 {
              right: 58.33333333%;
            }
            .col-sm-pull-6 {
              right: 50%;
            }
            .col-sm-pull-5 {
              right: 41.66666667%;
            }
            .col-sm-pull-4 {
              right: 33.33333333%;
            }
            .col-sm-pull-3 {
              right: 25%;
            }
            .col-sm-pull-2 {
              right: 16.66666667%;
            }
            .col-sm-pull-1 {
              right: 8.33333333%;
            }
            .col-sm-pull-0 {
              right: auto;
            }
            .col-sm-push-12 {
              left: 100%;
            }
            .col-sm-push-11 {
              left: 91.66666667%;
            }
            .col-sm-push-10 {
              left: 83.33333333%;
            }
            .col-sm-push-9 {
              left: 75%;
            }
            .col-sm-push-8 {
              left: 66.66666667%;
            }
            .col-sm-push-7 {
              left: 58.33333333%;
            }
            .col-sm-push-6 {
              left: 50%;
            }
            .col-sm-push-5 {
              left: 41.66666667%;
            }
            .col-sm-push-4 {
              left: 33.33333333%;
            }
            .col-sm-push-3 {
              left: 25%;
            }
            .col-sm-push-2 {
              left: 16.66666667%;
            }
            .col-sm-push-1 {
              left: 8.33333333%;
            }
            .col-sm-push-0 {
              left: auto;
            }
            .col-sm-offset-12 {
              margin-left: 100%;
            }
            .col-sm-offset-11 {
              margin-left: 91.66666667%;
            }
            .col-sm-offset-10 {
              margin-left: 83.33333333%;
            }
            .col-sm-offset-9 {
              margin-left: 75%;
            }
            .col-sm-offset-8 {
              margin-left: 66.66666667%;
            }
            .col-sm-offset-7 {
              margin-left: 58.33333333%;
            }
            .col-sm-offset-6 {
              margin-left: 50%;
            }
            .col-sm-offset-5 {
              margin-left: 41.66666667%;
            }
            .col-sm-offset-4 {
              margin-left: 33.33333333%;
            }
            .col-sm-offset-3 {
              margin-left: 25%;
            }
            .col-sm-offset-2 {
              margin-left: 16.66666667%;
            }
            .col-sm-offset-1 {
              margin-left: 8.33333333%;
            }
            .col-sm-offset-0 {
              margin-left: 0%;
            }
          }
          </style>
        </head>
    <body onload="window.print();window.close()">${printContents}</body>
      </html>`
    );
    popupWin.document.close();
  }
}
