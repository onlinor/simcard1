import { Component, OnInit } from '@angular/core';

import {
  FileService,
  ProductService,
  PhieunhapService,
  SupplierService
} from '../../core/services';
import {
  Product,
  ImportReceipt,
  Supplier
} from '../../core/models';

@Component({
  selector: 'app-importproduct',
  templateUrl: './importproduct.component.html',
  styleUrls: ['./importproduct.component.css']
})
export class ImportProductComponent implements OnInit {

  tableProducts: Array<Product> = [];

  tabviewProducts: Array<Product> = [];

  suppliers: Array<Supplier> = [];

  totalMoney = 0;

  vatMoney = 0;

  total = 0;

  thanhToan = 0;

  importReceipt: ImportReceipt = new ImportReceipt();

  constructor(
    private fileService: FileService,
    private productService: ProductService,
    private phieuhangService: PhieunhapService,
    private supplierService: SupplierService,
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
        this.tableProducts = Object.assign(this.tableProducts, response);

    // Update donGia and thanhTien, shopID is belong-ed to for each product(Save time, may put it somewhere else without any function,..)
    this.tableProducts.forEach(element => {
          element.donGia = (element.menhGia / 100) * (100 - element.chietKhau);
          element.thanhTien = element.soLuong * (element.menhGia - (element.menhGia * element.chietKhau) / 100);
          element.shopId = 1;
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

  onProductTableEditCompleted(event: any) {
    // Update donGia and thanhTien for each product(Save time, may put it somewhere else without any function,..)
    const selectedProduct = this.tableProducts.find(
      x => x.ma === event.data.ma);
    selectedProduct.donGia = (selectedProduct.menhGia / 100) * (100 - selectedProduct.chietKhau);
    selectedProduct.thanhTien = selectedProduct.soLuong
     * (selectedProduct.menhGia - (selectedProduct.menhGia * selectedProduct.chietKhau) / 100);
    this.updateTotalMoney();
  }

  onDropdownValueChange(event: any) {
    this.tableProducts.forEach(element => {
      element.supplierId = event.value.id;
    });
    this.importReceipt.supplierId = event.value.id;
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

  savePhieunhap() {
    this.importReceipt.prefix = this.importReceipt.ma.substring(0, 10);
    this.importReceipt.suffix = Number(this.importReceipt.ma.substr(11));
    this.importReceipt.tienThanhToan = this.thanhToan;
    this.importReceipt.tienConLai = this.total - this.thanhToan;
    this.importReceipt.products = this.tableProducts;
    this.importReceipt.shopId = 1;
    this.phieuhangService.addPhieunhap(this.importReceipt).subscribe(() => { });
  }
}