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
  @ViewChild('myInput')
  myInputVariable: ElementRef;

  tableProducts: Array<Product> = [];

  products: Array<Product> = [];
  tabviewpro: Array<Product> = [];

  venders: Array<Supplier> = [];
  selectedVendor: Supplier;

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
    private venderService: SupplierService
  ) { }

  ngOnInit() {
    this.showProductsResponse();
    this.getVendors();
  }

  save() {
    this.productService.save(this.tableProducts).subscribe(() => {
      this.showProductsResponse();
      this.savePhieunhap();

      this.tableProducts = [];
    });
  }

  uploadProductList(event: any) {
    const fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      const file: File = fileList[0];
      const formData = new FormData();
      formData.append(file.name, file);

      this.fileService.uploadProductList(formData).subscribe((response: Array<Product>) => {
        this.tableProducts = Object.assign(this.tableProducts, response);
        this.updateTotalMoney();
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

  handleChange(e: any) {
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

  isProductexist(ma: string, tables: Product[]): Boolean {
    if (tables.findIndex(x => x.ma === ma) !== -1) {
      return true;
    }
    return false;
  }

  generateID() {
    this.phieuhangService.getID().subscribe(resp => {
      this.idphieunhap = resp.id;
    });
  }

  getVendors() {
    this.venderService.getAll().subscribe(resp => {
      this.venders = resp;
    });
  }

  savePhieunhap() {
    this.phieunhap.prefix = this.idphieunhap.substring(0, 10);
    this.phieunhap.suffix = this.idphieunhap.substr(11);
    this.phieunhap.products = this.tableProducts;
    this.phieunhap.tennhacungcap = this.selectedVendor.name;
    this.phieunhap.tienthanhtoan = this.thanhtoan;
    this.phieunhap.tienconlai = this.total - this.thanhtoan;
    this.phieuhangService.addPhieunhap(this.phieunhap).subscribe(() => { });
  }
}
