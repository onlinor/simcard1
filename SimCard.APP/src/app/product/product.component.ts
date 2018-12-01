import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Product } from '../services/product';
import { Shop } from '../services/shop';
import { WarehouseService } from '../services/warehouse.service';
import { Warehouse } from '../services/warehouse';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  text: string;
  headers: any;
  products: Product[];
  selectedProduct: Product;
  shops: Shop[];
  selectedShop: Shop;
  warehouses: Warehouse[];
  selectedWarehouse: Warehouse;
  // input product
  tempPro: Product = {id: null, name: null, quantity: null, buyingprice: null, unit: null, shopid: null};
  tempProName: string;
  tempProId: number;
  tempProQuantity: number;
  tempProUnit: string;
  tempProBuyingprice: number;

  constructor(private productService: ProductService, private warehouseService: WarehouseService) { }

  ngOnInit() {
    this.showProductsResponse();
    this.getWarehouse();

    this.shops = [
      {name: 'Shop 1', id: 1},
      {name: 'Shop 2', id: 2},
      {name: 'Shop 3', id: 3},
      {name: 'Shop 4', id: 4}
  ];
  }

  showProductsResponse() {
    this.productService.getProducts().subscribe(
      resp => {
        const keys = resp.headers.keys();
        this.headers = keys.map(key =>
          `${key}: ${resp.headers.get(key)}`);

        this.extractData(resp.body);
      }
    );
  }

  getWarehouse() {
    this.warehouseService.getWarehouses().subscribe(
      resp => {
        this.extractWarehouses(resp.body);
      }
    );
  }

  extractWarehouses(body: any) {
    this.warehouses = [];
    for (const warehouse of body) {
      this.warehouses.push(warehouse);
    }
  }

  extractData(body: any) {
    this.products = [];
    for (const product of body) {
      this.products.push(product);
    }
  }

  addToTable () {
    // tslint:disable-next-line:prefer-const
    let tempProducts = [...this.products];

    this.tempPro.id = this.tempProId;
    this.tempPro.name = this.tempProName;
    this.tempPro.quantity = this.tempProQuantity;
    this.tempPro.buyingprice = this.tempProBuyingprice;
    this.tempPro.unit = this.tempProUnit;
    this.tempPro.shopid = this.selectedShop.id;

    tempProducts.push(this.tempPro);
    this.tempPro = {id: null, name: null, quantity: null, buyingprice: null, unit: null, shopid: null};
    this.products = tempProducts;
  }

  DeleteRow (idproduct: any) {
    // tslint:disable-next-line:prefer-const
    let proToRemove = this.products.find(x => x.id === idproduct);
    // tslint:disable-next-line:prefer-const
    let index = this.products.indexOf(proToRemove);
    // tslint:disable-next-line:prefer-const
    this.products = this.products.filter((val, i) => i !== index);
  }
}
