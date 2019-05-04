import { Component, OnInit } from '@angular/core';
import { ProductExchange } from '../../core/models';
import { ProductExchangeService } from '../../core/services';

@Component({
  selector: 'app-listproduct',
  templateUrl: './listproduct.component.html',
  styleUrls: ['./listproduct.component.css']
})
export class ListproductComponent implements OnInit {
  displayDialog: boolean;

  productExchange: ProductExchange = new ProductExchange();

  selectedProductExchange: ProductExchange;

  newProductExchange: boolean;

  productExchanges: ProductExchange[];

  cols: any[];

  constructor(private productExchangeService: ProductExchangeService) {}

  ngOnInit() {
    this.showSuppliersResponse();

    this.cols = [{ field: 'name', header: 'Tên' }];
  }

  showDialogToAdd() {
    this.newProductExchange = true;
    this.productExchange = new ProductExchange();
    this.displayDialog = true;
  }

  save() {
    this.productExchangeService.save(this.productExchange).subscribe(() => {
      this.showSuppliersResponse();
    });

    this.productExchange = new ProductExchange();
    this.displayDialog = false;
  }

  showSuppliersResponse() {
    this.productExchangeService.getAll().subscribe(resp => {
      this.productExchanges = resp;
    });
  }
  delete() {
    const index = this.productExchanges.indexOf(this.selectedProductExchange);
    this.productExchanges = this.productExchanges.filter((val, i) => i !== index);
    this.productExchange = new ProductExchange();
    this.displayDialog = false;
  }

  onRowSelect(event) {
    this.newProductExchange = false;
    this.productExchange = this.cloneSupplier(event.data);
    this.displayDialog = true;
  }

  cloneSupplier(sp: ProductExchange): ProductExchange {
    // tslint:disable-next-line:prefer-const
    let supplier = new ProductExchange();
    // tslint:disable-next-line:forin
    for (const prop in sp) {
      supplier[prop] = sp[prop];
    }
    return supplier;
  }
}
