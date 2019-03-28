import { Component, OnInit } from '@angular/core';
import {
  Product,
  Supplier,
  ProductExport,
  ExportType,
  Bank,
  ExportReceipt
} from '../../core/models';
import { PhieuxuatService, ProductService } from '../../core/services';

@Component({
  selector: 'app-exportproduct',
  templateUrl: './exportproduct.component.html',
  styleUrls: ['./exportproduct.component.css']
})
export class ExportProductComponent implements OnInit {

  tabviewProducts: Array<Product> = [];

  tableProducts: Array<Product> = [];

  exportReceipt: ExportReceipt = new ExportReceipt();

  totalMoney = 0;

  vatMoney = 0;

  total = 0;

  thanhToan = 0;

  constructor(
    private productService: ProductService,
    private phieuxuatSerivce: PhieuxuatService
  ) {}

  ngOnInit() {
    this.getAllProducts();
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
      }
      selectedProduct.soLuong += event.data.exportnumber;
      selectedProduct.thanhTien = selectedProduct.donGia * selectedProduct.soLuong;
    }
  }

  onProductTableEditCompleted(event: any) {
    const selectedProduct = this.tableProducts.find(
      x => x.ma === event.data.ma);
      selectedProduct.donGia = (selectedProduct.menhGia / 100) * (100 - selectedProduct.chietKhau);
      selectedProduct.thanhTien = selectedProduct.donGia * selectedProduct.soLuong;
  }

  generateProductCode() {
    this.phieuxuatSerivce.getProductCode().subscribe(resp => {
      this.exportReceipt.ma = resp.ma;
    });
  }
}
