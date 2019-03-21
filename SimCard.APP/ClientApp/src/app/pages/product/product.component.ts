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
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  text: string;
  headers: any;

  tableproducts: Product[];
  products: Product[];
  tabviewpro: Product[];
  exportpro: ProductExport[];
  pro: ProductExport = {
    name: null,
    quantity: null,
    unitprice: null,
    discount: null,
    denomination: null,
    total: null
  };

  selectedProduct: Product;

  exporttypes: ExportType[];
  selectedtype: ExportType;

  banks: Bank[];
  bank: Bank;

  suppliers: Supplier[];
  selectedSupplier: Supplier;
  // input product
  tempPro: Product = {
    id: 0,
    ma: null,
    ten: null,
    soLuong: null,
    menhGia: null,
    chietKhau: null,
    donGia: null,
    thanhTien: null
  };
  tempProName: string;
  tempProId: number;
  tempProQuantity: number;
  tempProUnit: string;
  tempProBuyingprice: number;

  constructor(
    private productService: ProductService,
    private supplierService: SupplierService,
    private fileService: FileService
  ) {}

  ngOnInit() {
    /*     this.showProductsResponse();
    this.getWarehouse();

    this.shops = [
      { name: 'Shop 1', id: 1 },
      { name: 'Shop 2', id: 2 },
      { name: 'Shop 3', id: 3 },
      { name: 'Shop 4', id: 4 }
    ];

    this.exporttypes = [
      { name: 'XLX', id: 1 },
      { name: 'XLXS', id: 2 },
      { name: 'PDF', id: 3 },
      { name: 'JPEG', id: 4 }
    ];

    this.banks = [
      { name: 'Master', id: 1 },
      { name: 'Visa', id: 2 },
      { name: 'VCB', id: 3 },
      { name: 'TCK', id: 4 }
    ]; */
  }

  showProductsResponse() {
    this.productService.getAll().subscribe(resp => {
      this.products = resp;
    });
  }


  /*   addToTable() {
    // tslint:disable-next-line:prefer-const
    let tempProducts = Object.assign([], this.tableproducts);

    this.tempPro.id = this.tempProId;
    this.tempPro.name = this.tempProName;
    this.tempPro.quantity = this.tempProQuantity;
    this.tempPro.buyingprice = this.tempProBuyingprice;
    this.tempPro.unit = this.tempProUnit;
    this.tempPro.shopid = this.selectedShop.id;

    tempProducts.push(this.tempPro);
    this.tempPro = { id: null, name: null, quantity: null, buyingprice: null, unit: null, shopid: null };
    this.tableproducts = tempProducts;
  } */

  /*   DeleteRow(idproduct: any) {
    // tslint:disable-next-line:prefer-const
    let proToRemove = this.tableproducts.find(x => x.id === idproduct);
    // tslint:disable-next-line:prefer-const
    let index = this.tableproducts.indexOf(proToRemove);
    // tslint:disable-next-line:prefer-const
    this.tableproducts = this.tableproducts.filter((val, i) => i !== index);
  } */

  addProduct() {
    this.productService.save(this.tableproducts).subscribe(() => {
      this.showProductsResponse();
    });
    this.tableproducts = null;
  }

  myUploader(event: any) {
    const fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      const file: File = fileList[0];
      const formData = new FormData();
      formData.append(file.name, file);

      this.fileService.uploadProductList(formData).subscribe(Response => {
        const tempProducts = Object.assign([], this.tableproducts);
        const temp = Object.assign([], Response);

        temp.forEach((product: Product) => {
          this.tempPro.id = 0;
          this.tempPro.ma = product.ma;
          this.tempPro.ten = product.ten;
          this.tempPro.soLuong = product.soLuong;
          this.tempPro.menhGia = product.menhGia;
          this.tempPro.chietKhau = product.chietKhau;
          this.tempPro.donGia = 10;
          this.tempPro.thanhTien = 20;

          tempProducts.push(this.tempPro);
          this.tempPro = {
            id: 0,
            ma: null,
            ten: null,
            soLuong: null,
            menhGia: null,
            chietKhau: null,
            donGia: null,
            thanhTien: null
          };
          this.tableproducts = tempProducts;
        });
      });
    }
  }

  handleChange(e) {
    /*
    switch (e.index) {
      case 0: {
        this.tabviewpro = this.products.filter(x => x.name.includes('Điện thoại')).map(x => Object.assign({}, x));
        break;
      }
      case 1: {
        this.tabviewpro = this.products.filter(x => x.name.includes('Sim số')).map(x => Object.assign({}, x));
        break;
      }
      case 2: {
        this.tabviewpro = this.products.filter(x => x.name.includes('Thẻ cào')).map(x => Object.assign({}, x));
        break;
      }
      default: {
        console.log('invalid selection');
        break;
      }
    }
     */
  }

  rowEditCompleted(event: any) {
    if (event.data.quantity === 0 || event.data.quantity === null) {
      // I will do something later :)
    } else {
      const tempProducts = Object.assign([], this.exportpro);
      this.pro.name = event.data.name;
      this.pro.denomination = null;
      this.pro.quantity = event.data.quantity;
      this.pro.discount = 5;
      this.pro.unitprice =
        (this.pro.denomination * (100 - this.pro.discount)) / 100;
      this.pro.total = this.pro.quantity * this.pro.unitprice;
      if (tempProducts.find(x => x.name === this.pro.name)) {
        // tslint:disable-next-line:prefer-const
        let item = tempProducts.find(i => i.name === this.pro.name);
        item.quantity = item.quantity + this.pro.quantity;
      } else {
        tempProducts.push(this.pro);
      }
      this.pro = {
        name: null,
        quantity: null,
        unitprice: null,
        discount: null,
        denomination: null,
        total: null
      };
      this.exportpro = tempProducts;
    }
  }

  exportrowEditCompleted(event) {
    event.data.unitprice =
      (event.data.denomination * (100 - event.data.discount)) / 100;
    event.data.total = event.data.quantity * event.data.unitprice;
  }

  saveAndExport() {
    for (const product of this.exportpro) {
      const pro = {
        name: product.name,
        quantity: product.quantity
      };
      this.productService.updateQuantityByProductName(pro).subscribe();
    }
  }
}
