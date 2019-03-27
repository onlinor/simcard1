import { Component, OnInit } from '@angular/core';
import {
  Product,
  Supplier,
  ProductExport,
  ExportType,
  Bank
} from '../../core/models';
import { ProductService } from '../../core/services/product.service';
import { SupplierService } from '../../core/services/supplier.service';
import { FileService } from '../../core/services/file.service';

@Component({
  selector: 'app-exportproduct',
  templateUrl: './exportproduct.component.html',
  styleUrls: ['./exportproduct.component.css']
})
export class ExportProductComponent implements OnInit {

  tabviewProducts: Array<Product> = [];

  tableProducts: Array<Product> = [];

  constructor(
    private productService: ProductService,
    private fileService: FileService
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
      selectedProduct.donGia =
        (selectedProduct.menhGia * (100 - selectedProduct.chietKhau)) / 100;
      selectedProduct.thanhTien =
        selectedProduct.soluongnhap * selectedProduct.donGia;
      /* this.updateTotalMoney(); */
    }
  }
}
