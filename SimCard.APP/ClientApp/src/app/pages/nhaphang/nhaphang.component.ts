import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import {
  FileService,
  ProductService,
  PhieunhapService,
  SupplierService
} from '../../core/services';
import {
  Product,
  ExportType,
  ImportReceipt,
  Supplier
} from '../../core/models';

@Component({
  selector: 'app-nhaphang',
  templateUrl: './nhaphang.component.html',
  styleUrls: ['./nhaphang.component.css']
})
export class NhaphangComponent implements OnInit {
  tableProducts: Array<Product> = [];

  products: Array<Product> = [];

  suppliers: Array<Supplier> = [];

  selectedSupplier: Supplier;

  // phieu section
  totalMoney = 0;

  vatMoney = 0;

  total = 0;

  thanhtoan = 0;

  conlai = 0;

  // phieu nhap
  phieunhap: ImportReceipt = new ImportReceipt();
  idphieunhap: string;

  constructor(
    private fileService: FileService,
    private productService: ProductService,
    private phieuhangService: PhieunhapService,
    private supplierService: SupplierService
  ) { }

  ngOnInit() {
    this.getAllProducts();
    this.getSuppliers();
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

      this.fileService.uploadProductList(formData).subscribe((response: Array<Product>) => {
        console.log(typeof response);
        console.log(response);
        console.log(this.tableProducts);
        this.tableProducts = Object.assign(this.tableProducts, response);
        this.updateTotalMoney();
      });
    }
  }

  getAllProducts() {
    this.productService.getAll().subscribe(response => {
      this.products = response;
    });
  }

  onProductTableEditCompleted(event: any) {
    this.updateTotalMoney();
  }

  rowEditCompleted(event: any) {
    if (event.data.soluongnhap === 0 || event.data.soluongnhap === null) {
      // I will do something later :)
    } else {
      const selectedProduct = this.tableProducts.find(
        x => x.ma === event.data.ma
      );
      selectedProduct.donGia =
        (selectedProduct.menhGia * (100 - selectedProduct.chietKhau)) / 100;
      selectedProduct.thanhTien =
        selectedProduct.soluongnhap * selectedProduct.donGia;
      this.updateTotalMoney();
    }
  }

  updateTotalMoney() {
    this.totalMoney = 0;
    this.tableProducts.forEach(line => {
      this.totalMoney += line.soLuong * (line.menhGia - line.menhGia * line.chietKhau / 100);
    });
    this.vatMoney = (this.totalMoney * 10) / 100;
    this.total = this.totalMoney + this.vatMoney;
  }

  generateID() {
    this.phieuhangService.getID().subscribe(response => {
      this.idphieunhap = response.id;
    });
  }

  getSuppliers() {
    this.supplierService.getAll().subscribe(response => {
      this.suppliers = response;
    });
  }

  savePhieunhap() {
    this.phieunhap.prefix = this.idphieunhap.substring(0, 10);
    this.phieunhap.suffix = this.idphieunhap.substr(11);
    this.phieunhap.products = this.tableProducts;
    this.phieunhap.tennhacungcap = this.selectedSupplier.name;
    this.phieunhap.tienthanhtoan = this.thanhtoan;
    this.phieunhap.tienconlai = this.total - this.thanhtoan;
    this.phieuhangService.addPhieunhap(this.phieunhap).subscribe(() => { });
  }
}
