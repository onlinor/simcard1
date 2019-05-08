import { Component, OnInit } from '@angular/core';
import { ProductExchange, Product, Supplier } from '../../core/models';
import { ProductExchangeService, ProductService, SupplierService } from '../../core/services';

@Component({
  selector: 'app-listproduct',
  templateUrl: './listproduct.component.html',
  styleUrls: ['./listproduct.component.css']
})
export class ListproductComponent implements OnInit {

  displayEditDialog: boolean;
  displayAddDialog: boolean;

  productExchange: ProductExchange = new ProductExchange();

  selectedProductExchange: ProductExchange;

  newProductExchange: boolean;

  productExchanges: ProductExchange[];

  cols: any[];

  suppliers: Supplier[];

  productExchangeTypes = [
    { label: 'Thẻ Cào', value: 'TC' },
    { label: 'Sim Số', value: 'SS' },
    { label: 'Điện Thoại', value: 'DT' },
    { label: 'Phụ Kiện', value: 'PK' }
  ];

  constructor(
    private productExchangeService: ProductExchangeService,
    private productService: ProductService,
    private supplierService: SupplierService
    ) {}

  ngOnInit() {
    this.showProductExchangesResponse();
    this.showSuppliersResponse();
    this.cols = [
      { field: 'ten', header: 'Tên' },
      { field: 'ma', header: 'Mã' },
      { field: 'menhgia', header: 'Mệnh Giá' },
      { field: 'loai', header: 'Loại' },
      { field: 'supplierId', header: 'Nhà Cung Cấp' }
    ];
  }

  showDialog() {
    this.newProductExchange = true;
    this.productExchange = new ProductExchange();
    this.displayAddDialog = true;
  }

  addNew() {
    this.productExchangeService.save(this.productExchange).subscribe(() => {
      const initialProduct: Product = {
        chietKhau: 0,
        donGia: 0,
        loai: this.productExchange.loai,
        ma: this.productExchange.ma,
        menhGia: this.productExchange.menhGia,
        shopId: 1,
        soLuong: 0,
        supplierId: this.productExchange.supplierId,
        ten: this.productExchange.ten,
        thanhTien: 0,
      };
      this.productService.save(initialProduct).subscribe(() => {});
      this.showProductExchangesResponse();
    });

    this.productExchange = new ProductExchange();
    this.displayAddDialog = false;
  }

  delete() {
    const index = this.selectedProductExchange.id;
    this.productExchangeService.delete(index).subscribe(() => {
      this.showProductExchangesResponse();
    });
    this.productExchange = new ProductExchange();
    this.displayEditDialog = false;
  }

  edit() {
    if (this.productExchanges.find(x => x.id !== this.selectedProductExchange.id
       && (x.ten === this.productExchange.ten || x.ma === this.productExchange.ma))) {
      console.log('Trùng');
    } else {
      this.productExchange.id = this.selectedProductExchange.id;
      this.productExchangeService.update(this.productExchange).subscribe(() => {
        this.showProductExchangesResponse();
      });
    }
    this.productExchange = new ProductExchange();
    this.displayEditDialog = false;
  }

  showProductExchangesResponse() {
    this.productExchangeService.getAll().subscribe(resp => {
      this.productExchanges = resp;
    });
  }
  onRowSelect(event) {
    this.newProductExchange = false;
    this.productExchange = this.cloneProductExchange(event.data);
    this.displayEditDialog = true;
  }

  cloneProductExchange(sp: any): ProductExchange {
    // tslint:disable-next-line:prefer-const
    let productExchange: ProductExchange = {
      id: sp.id,
      ten: sp.ten,
      ma: sp.ma,
      menhGia: sp.menhgia,
      loai: sp.loai,
      supplierId: sp.supplierid
    };
    // assign
    return productExchange;
  }

  showSuppliersResponse() {
    this.supplierService.getAll().subscribe(resp => {
      this.suppliers = resp;
    });
  }

  onDropdownValueChange(event: any) {
    this.productExchange.supplierId = event.value.id;
  }
}
