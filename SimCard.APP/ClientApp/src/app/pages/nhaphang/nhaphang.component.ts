import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FileService, ProductService, PhieunhapService, SupplierService } from '../../core/services';
import { Product, ExportType, ImportReceipt, Supplier } from '../../core/models';

@Component({
  selector: 'app-nhaphang',
  templateUrl: './nhaphang.component.html',
  styleUrls: ['./nhaphang.component.css']
})
export class NhaphangComponent implements OnInit {

  @ViewChild('myInput')
  myInputVariable: ElementRef;

  tableProducts: Product[] = [];

  products: Product[];
  tabviewpro: Product[];

  venders: Supplier[];
  selectedVender: Supplier;

  // phieu section
  totalMoney: number;
  vatMoney: number;
  Total: number;
  Thanhtoan: number;
  Conlai: number;

  // phieu nhap
  phieunhap: ImportReceipt = new ImportReceipt();
  idphieunhap: string;

  constructor(
    private fileService: FileService,
    private productService: ProductService,
    private phieuhangService: PhieunhapService,
    private venderService: SupplierService
  ) { }

  ngOnInit() {
    this.showProductsResponse();
    this.getVenders();
  }

  Save() {
    this.productService.save(this.tableProducts).subscribe(() => {
    this.showProductsResponse();
    this.savePhieunhap();

    this.tableProducts = [];
    });
  }

  myUploader(event) {
    // tslint:disable-next-line:prefer-const
    let fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      // tslint:disable-next-line:prefer-const
      let file: File = fileList[0];
      // tslint:disable-next-line:prefer-const
      let formData = new FormData();
      formData.append(file.name, file);

      this.fileService.Upload(formData).subscribe(Response => {
        // tslint:disable-next-line:prefer-const
        let tempProducts = Object.assign([], this.tableProducts);
        // tslint:disable-next-line:prefer-const
        let productstoadd = Object.assign([], Response);
        let tempPro: Product = new Product();

        productstoadd.forEach(element => {
          if (this.isProductexist(element.ma, this.tableProducts)) {
            tempPro = this.tableProducts.find(x => x.ma === element.ma);
            tempPro.soluongnhap = tempPro.soluongnhap += element.soLuong;
            tempPro.thanhtien = tempPro.soluongnhap * tempPro.dongia;
          } else {
            tempPro.ma = element.ma;
            tempPro.ten = element.ten;
            tempPro.soluong = tempPro.soluongnhap = element.soLuong;
            tempPro.menhgia = element.menhGia;
            tempPro.chietkhau = element.chietKhau;
            tempPro.dongia = (tempPro.menhgia / 100) * (100 - tempPro.chietkhau);
            tempPro.thanhtien = tempPro.soluongnhap * tempPro.dongia;
            tempProducts.push(tempPro);
            tempPro = new Product();
            this.tableProducts = tempProducts;
            this.updateTotalMoney(this.tableProducts);
          }
        });
      });
    }
    this.reset();
  }

  reset() {
    this.myInputVariable.nativeElement.value = '';
  }

  showProductsResponse() {
    this.productService.getAll().subscribe(resp => {
      this.tabviewpro = this.products = resp;
    });
  }

  handleChange(e) {
    if (e === 0) {
      this.tabviewpro = this.products;
    } else {
      switch (e.index) {
        case 0: {
          this.tabviewpro = this.products;
          break;
        }
        // case 1: {
        //   this.tabviewpro = this.products.filter(x => x.name.includes('Sim số')).map(x => Object.assign({}, x));
        //   break;
        // }
        // case 2: {
        //   this.tabviewpro = this.products.filter(x => x.name.includes('Thẻ cào')).map(x => Object.assign({}, x));
        //   break;
        // }
        default: {
          console.log('invalid selection');
          break;
        }
      }
    }
  }

  rowEditCompleted(event) {
    if (event.data.soluongnhap === 0 || event.data.soluongnhap === null) {
      // I will do something later :)
    } else {
      let selectedproduct: Product = new Product();

      if (this.isProductexist(event.data.ma, this.tableProducts)) {
        selectedproduct = this.tableProducts.find(x => x.ma === event.data.ma);
        selectedproduct.soluongnhap += event.data.soluongnhap;
        if (selectedproduct.thanhtien) {
          selectedproduct.thanhtien = selectedproduct.soluongnhap * selectedproduct.dongia;
        }
        this.updateTotalMoney(this.tableProducts);
      } else {
        const addedProducts = Object.assign([], this.tableProducts);
        selectedproduct.ma = event.data.ma;
        selectedproduct.ten = event.data.ten;
        selectedproduct.menhgia = event.data.menhgia;
        selectedproduct.soluongnhap = event.data.soluongnhap;
        selectedproduct.soluong = event.data.soluongnhap;
        //   (this.pro.denomination * (100 - this.pro.discount)) / 100;
        // this.pro.total = this.pro.quantity * this.pro.unitprice;
        // if (tempProducts.find(x => x.name === this.pro.name)) {
        //   // tslint:disable-next-line:prefer-const
        //   let item = tempProducts.find(i => i.name === this.pro.name);
        //   item.quantity = item.quantity + this.pro.quantity;
        // } else {
        //   tempProducts.push(this.pro);
        // }
        addedProducts.push(selectedproduct);
        this.tableProducts = addedProducts;
        this.updateTotalMoney(this.tableProducts);
      }
    }
  }

  rowTableCompleted(event) {
    if (event.data.soluongnhap === 0 || event.data.soluongnhap === null) {
      // I will do something later :)
    } else {
      const selectedProduct = this.tableProducts.find(x => x.ma === event.data.ma);
      selectedProduct.dongia = selectedProduct.menhgia * (100 - selectedProduct.chietkhau) / 100;
      selectedProduct.thanhtien = selectedProduct.soluongnhap * selectedProduct.dongia;
      this.updateTotalMoney(this.tableProducts);
    }
  }

  updateTotalMoney(tableProducts: Product[]) {
    this.totalMoney = 0;
    // tslint:disable-next-line:forin
    tableProducts.forEach(element => {
      if (element.thanhtien) {
        this.totalMoney += element.thanhtien;
      }
    });
    this.vatMoney = (this.totalMoney * 10) / 100;
    this.Total = this.totalMoney + this.vatMoney;
  }

  isProductexist(ma: string, tables: Product[]): Boolean {
    if (tables.findIndex(x => x.ma === ma) !== -1) {
      return true;
    }
    return false;
  }

  generateID () {
    this.phieuhangService.getID().subscribe(resp => {
      this.idphieunhap = resp.id;
    });
  }

  getVenders() {
    this.venderService.getAll().subscribe( resp => {
    this.venders = resp;
    });
  }

  savePhieunhap() {
    this.phieunhap.Prefixid = this.idphieunhap.substring(0, 10);
    this.phieunhap.Suffixid = this.idphieunhap.substr(11);
    this.phieunhap.Dssanpham = this.tableProducts;
    this.phieunhap.Tennhacungcap = this.selectedVender.name;
    this.phieunhap.Tienthanhtoan = this.Thanhtoan;
    this.phieunhap.Tienconlai = this.Total - this.Thanhtoan;
    this.phieuhangService.addPhieunhap(this.phieunhap).subscribe(() => {});
  }
}
