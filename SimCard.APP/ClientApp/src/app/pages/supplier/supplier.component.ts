import { Component, OnInit } from '@angular/core';
import { Supplier } from '../../core/models';
import { SupplierService } from '../../core/services/supplier.service';

@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})
export class SupplierComponent implements OnInit {
  displayDialog: boolean;
  supplier: Supplier = new Supplier();
  selectedSupplier: Supplier;
  newSupplier: boolean;
  suppliers: Supplier[];
  cols: any[];

  constructor(private supplierService: SupplierService) {}

  ngOnInit() {
    this.showSuppliersResponse();

    this.cols = [{ field: 'name', header: 'Tên' }];
  }

  showDialogToAdd() {
    this.newSupplier = true;
    this.supplier = new Supplier();
    this.displayDialog = true;
  }

  save() {
    this.supplierService.save(this.supplier).subscribe(() => {
      this.showSuppliersResponse();
    });

    this.supplier = new Supplier();
    this.displayDialog = false;
  }

  showSuppliersResponse() {
    this.supplierService.getAll().subscribe(resp => {
      this.suppliers = resp;
    });
  }
  delete() {
    const index = this.suppliers.indexOf(this.selectedSupplier);
    this.suppliers = this.suppliers.filter((val, i) => i !== index);
    this.supplier = new Supplier();
    this.displayDialog = false;
  }

  onRowSelect(event) {
    this.newSupplier = false;
    this.supplier = this.cloneSupplier(event.data);
    this.displayDialog = true;
  }

  cloneSupplier(sp: Supplier): Supplier {
    // tslint:disable-next-line:prefer-const
    let supplier = new Supplier();
    // tslint:disable-next-line:forin
    for (const prop in sp) {
      supplier[prop] = sp[prop];
    }
    return supplier;
  }
}
