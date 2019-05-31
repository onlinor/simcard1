import { Component, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { FormphieuthuComponent } from '../../public/formphieuthu/formphieuthu.component';
import { Product, ExportReceipt, Shop, Network, Debtbook } from '../../core/models';
import {
  PhieuxuatService,
  ProductService,
  ShopService,
  NetworkService,
  CustomerService,
  DebtbookService
} from '../../core/services';

@Component({
  selector: 'app-exportproduct',
  templateUrl: './exportproduct.component.html',
  styleUrls: ['./exportproduct.component.css']
})
export class ExportProductComponent implements OnInit {
  @ViewChild(FormphieuthuComponent)
  myFormThuChild: FormphieuthuComponent;
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

  shopList: Array<Shop> = [];

  loaiNganHang: String = '';

  tabviewProducts: Array<Product> = [];

  tableProducts: Array<Product> = [];

  exportReceipt: ExportReceipt = new ExportReceipt();

  networks: Array<Network> = [];

  totalMoney = 0;

  vatMoney = 0;

  total = 0;

  thanhToan = 0;

  payBank = 0;
  isPaybankChecked = false;

  payCash = 0;
  isPaycashChecked = false;

  isShowDialogPhieuThu: Boolean = false;
  customerList: any;

  debtbookParams: Debtbook = new Debtbook();


  subscription: Subscription;

  constructor(
    private productService: ProductService,
    private phieuxuatSerivce: PhieuxuatService,
    private shopService: ShopService,
    private networkService: NetworkService,
    private customerService: CustomerService
  ) {}

  ngOnInit() {
    this.getAllProducts();
    this.getAllShops();
    this.getAllNetworks();
    this.getAllCustomer();
  }

  getAllCustomer() {
    this.subscription = this.customerService.getAllCustomer()
		.subscribe(
			response => {
				this.customerList = response;
			},
			error => {}
		);
  }

  onChangePaybank() {
    this.thanhToan = this.payBank + this.payCash;
  }

  onChangePaycash() {
    this.thanhToan = this.payBank + this.payCash;
  }

  onGetIsShowDialogPhieuThu(data: any) {
    this.isShowDialogPhieuThu = data;
  }

  getAllProducts() {
    this.productService.getAll().subscribe(response => {
      this.tabviewProducts = response;
    });
  }

  onDropdownValueChange(event: any) {
    this.exportReceipt.shopId = event.value.id;
    this.myFormThuChild.dataPhieuThu.shopId = event.value.id;
  }

  rowEditCompleted(event: any) {
    if (
      event.data.exportnumber <= 0 ||
      event.data.exportnumber === null ||
      event.data.exportnumber > event.data.soluong
    ) {
      console.log('Input is not correct, please try again');
    } else {
      const selectedProduct = this.tableProducts.find(
        x => x.ma === event.data.ma
      );
      if (!selectedProduct) {
        const newProduct: Product = {
          id: event.data.id,
          ma: event.data.ma,
          ten: event.data.ten,
          soLuong: event.data.exportnumber,
          menhGia: event.data.menhgia,
          loai: event.data.loai,
          chietKhau: parseFloat(
            (
              ((event.data.menhgia - event.data.donGia) * 100) /
              event.data.menhgia
            ).toFixed(1)
          ),
          donGia: event.data.donGia,
          thanhTien: event.data.exportnumber * event.data.donGia
        };
        this.tableProducts.push(newProduct);
      } else {
        selectedProduct.soLuong += event.data.exportnumber;
        selectedProduct.thanhTien =
          selectedProduct.donGia * selectedProduct.soLuong;
      }
      this.updateTotalMoney();
    }
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

  onProductTableEditCompleted(event: any) {
    const selectedProduct = this.tableProducts.find(
      x => x.ma === event.data.ma
    );
    selectedProduct.donGia =
      (selectedProduct.menhGia / 100) * (100 - selectedProduct.chietKhau);
    selectedProduct.thanhTien =
      selectedProduct.donGia * selectedProduct.soLuong;
    this.updateTotalMoney();
  }

  generateProductCode() {
    this.phieuxuatSerivce.getProductCode().subscribe(resp => {
      this.exportReceipt.ma = resp.ma;
    });
  }

  dataExportProductBinding() {
    this.myFormThuChild.dataPhieuThu.loaiNganHang = this.loaiNganHang;
    this.myFormThuChild.dataPhieuThu.nguoiThu = this.exportReceipt.nhanVienLap;
    this.myFormThuChild.dataPhieuThu.tenKhachHang = this.exportReceipt.nguoiDaiDien;
    this.myFormThuChild.dataPhieuThu.soTienThu = this.thanhToan;
    this.myFormThuChild.isATM = this.isPaybankChecked;
    this.myFormThuChild.isCash = this.isPaycashChecked;
    this.myFormThuChild.checkedATM();
    this.myFormThuChild.checkedCash();
    this.myFormThuChild.isNewCashBook = true;
    this.isShowDialogPhieuThu = true;
    this.myFormThuChild.customerList = this.customerList;
    this.myFormThuChild.fillDropdownCustomer();
  }

  // get all customers from db
  getAllShops() {
    this.shopService.getAll().subscribe(response => {
      this.shopList = response;
    });
  }

  initialDebtbookData() {
    this.debtbookParams.maKhachHang = this.myFormThuChild.dataPhieuThu.maKhachHang;
    this.debtbookParams.tenKhachHang = this.exportReceipt.nguoiDaiDien;
    this.debtbookParams.noiDungPhieu = this.exportReceipt.ghiChu;
    this.debtbookParams.soPhieu = this.exportReceipt.ma;
    this.debtbookParams.khachNo = 0;
    this.debtbookParams.noKhach = this.exportReceipt.tongTien;
    this.debtbookParams.congDon = 0;
  }

  addToDebtbook() {
    this.initialDebtbookData();
    this.myFormThuChild.callApiAddDebtbook(this.debtbookParams);
  }

  getAllNetworks() {
    this.networkService.getAll().subscribe(response => {
      this.networks = response;
    });
  }

  save() {
    this.tableProducts.forEach(p => {
      p.shopId = this.exportReceipt.shopId;
      p.supplierId = 1;
    });
    this.addToDebtbook();
    this.productService.save(this.tableProducts).subscribe(() => {
      this.savePhieuxuat();
      this.dataExportProductBinding();
      this.getAllProducts();
      this.tableProducts = [];
    });
  }

  savePhieuxuat() {
    this.exportReceipt.prefix = this.exportReceipt.ma.substring(0, 10);
    this.exportReceipt.suffix = Number(this.exportReceipt.ma.substr(11));
    this.exportReceipt.tienThanhToan = this.thanhToan;
    this.exportReceipt.tienConLai = this.total - this.thanhToan;
    this.exportReceipt.products = this.tableProducts;
    this.phieuxuatSerivce.addPhieuxuat(this.exportReceipt).subscribe(() => { });
  }
}
