import { Component, OnInit } from '@angular/core';
import { ProductExchange } from '../../core/models';
import { ProductExchangeService } from '../../core/services';
import { loadInternal } from '@angular/core/src/render3/util';

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

  productExchangeTypes = [
    { label: 'Chọn', value: 'default' },
    { label: 'SIM', value: 'SIM' },
    { label: 'Điện Thoại', value: 'DT' }
  ];

  constructor(private productExchangeService: ProductExchangeService) {}

  ngOnInit() {
    this.showProductExchangesResponse();

    this.cols = [
      { field: 'ten', header: 'Tên' },
      { field: 'ma', header: 'Mã' },
      { field: 'menhgia', header: 'Mệnh Giá' },
      { field: 'loai', header: 'Loại' }
    ];
  }

  showDialog() {
    this.newProductExchange = true;
    this.productExchange = new ProductExchange();
    this.displayAddDialog = true;
  }

  addNew() {
    this.productExchangeService.save(this.productExchange).subscribe(() => {
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
      loai: sp.loai
    };
    // assign
    return productExchange;
  }
}
