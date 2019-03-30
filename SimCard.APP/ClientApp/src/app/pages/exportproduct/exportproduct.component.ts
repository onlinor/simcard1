import { Component, OnInit } from '@angular/core';
import {
  Product,
  Supplier,
  ProductExport,
  ExportType,
  Bank,
  ExportReceipt,
  Customer
} from '../../core/models';
import { PhieuxuatService, ProductService, CustomerService } from '../../core/services';

@Component({
  selector: 'app-exportproduct',
  templateUrl: './exportproduct.component.html',
  styleUrls: ['./exportproduct.component.css']
})
export class ExportProductComponent implements OnInit {

  tabviewProducts: Array<Product> = [];

  tableProducts: Array<Product> = [];

  exportReceipt: ExportReceipt = new ExportReceipt();

  customerList: Array<Customer> = [];

  totalMoney = 0;

  vatMoney = 0;

  total = 0;

  thanhToan = 0;

  constructor(
    private productService: ProductService,
    private phieuxuatSerivce: PhieuxuatService,
    private customerService: CustomerService
  ) {}

  ngOnInit() {
    this.getAllProducts();
    this.getAllCustomers();
  }

  getAllProducts() {
    this.productService.getAll().subscribe(response => {
      this.tabviewProducts = response;
    });
  }

  rowEditCompleted(event: any) {
    if (event.data.soluongnhap === 0 || event.data.soluongnhap === null) {
      // I will do something later :)
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
          chietKhau: (event.data.menhgia - event.data.donGia) * 100 / event.data.menhgia,
          donGia: event.data.donGia,
          thanhTien: event.data.exportnumber * event.data.donGia
        };
        this.tableProducts.push(newProduct);
      } else {
        selectedProduct.soLuong += event.data.exportnumber;
        selectedProduct.thanhTien = selectedProduct.donGia * selectedProduct.soLuong;
      }
    }
    this.updateTotalMoney();
  }

  onProductTableEditCompleted(event: any) {
    const selectedProduct = this.tableProducts.find(
      x => x.ma === event.data.ma);
      selectedProduct.donGia = (selectedProduct.menhGia / 100) * (100 - selectedProduct.chietKhau);
      selectedProduct.thanhTien = selectedProduct.donGia * selectedProduct.soLuong;
      this.updateTotalMoney();
  }

  updateTotalMoney() {
    this.totalMoney = 0;
    this.tableProducts.forEach(line => {
      this.totalMoney += line.soLuong * (line.menhGia - line.menhGia * line.chietKhau / 100);
    });
    this.vatMoney = (this.totalMoney * 10) / 100;
    this.total = this.totalMoney + this.vatMoney;
  }

  generateProductCode() {
    this.phieuxuatSerivce.getProductCode().subscribe(resp => {
      this.exportReceipt.ma = resp.ma;
    });
  }

  // get all customers from db
  getAllCustomers() {
    this.customerService.getAllCustomer().subscribe(
      response => {
        this.customerList = response;
        console.log(this.customerList);
      }
    );
  }

  onDropdownValueChange(event: any) {
    this.exportReceipt.shopId = event.value.id;
  }

  save() {
    this.tableProducts.forEach(p => {
      p.shopId = this.exportReceipt.shopId;
      p.supplierId = 1;
    });
    this.productService.save(this.tableProducts).subscribe(() => {
      this.savePhieuxuat();
    });
  }

  savePhieuxuat() {
    this.exportReceipt.prefix = this.exportReceipt.ma.substring(0, 10);
    this.exportReceipt.suffix = Number(this.exportReceipt.ma.substr(11));
    this.exportReceipt.tienThanhToan = this.thanhToan;
    this.exportReceipt.tienConLai = this.total - this.thanhToan;
    this.exportReceipt.products = this.tableProducts;
    // this.exportReceipt.addPhieuxuat(this.exportReceipt).subscribe(() => { });
  }
}
