import { Component, OnInit } from '@angular/core';
import { Warehouse } from '../../core/models/warehouse.model';
import { WarehouseService } from '../../core/services/warehouse.service';
import { FormGroup, Validators } from '@angular/forms';
import { BaseComponent } from '../../core/base';

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.css']
})
export class WarehouseComponent extends BaseComponent implements OnInit {
  displayDialogAdd: boolean;
  displayDialogEdit: boolean;
  warehouseTemp: Warehouse = { id: null, name: null, note: null };
  selectedWarehouse: Warehouse;
  newWarehouse: boolean;
  warehouses: Warehouse[];
  cols: any[];
  // loading
  isFullfilled: any;

  // validation
  createForm: FormGroup;

  constructor(private warehouseService: WarehouseService) {
    super();
  }

  ngOnInit() {
    super.ngOnInit();
    this.showWarehousesResponse();
    this.cols = [
      { field: 'id', header: 'ID' },
      { field: 'name', header: 'Name' },
      { field: 'note', header: 'Note' }
    ];
    this.initForm();
  }

  showDialogToAdd() {
    this.newWarehouse = true;
    this.warehouseTemp = { id: null, name: null, note: null };
    this.displayDialogAdd = true;
  }

  showWarehousesResponse() {
    this.warehouseService.getAll().subscribe(resp => {
      this.warehouses = resp;
    });
  }

  add() {
    this.submitted = true;
    if (this.createForm.invalid) {
      return false;
    }
    this.warehouseTemp.id = 0; // set to not null to pass to api
    this.warehouseService.save(this.warehouseTemp).subscribe(() => {
      this.showWarehousesResponse();
    });
    this.warehouseTemp = null;
    this.displayDialogAdd = false;
  }

  update() {
    this.warehouseTemp.id = this.selectedWarehouse.id;
    this.warehouseService.update(this.warehouseTemp).subscribe(() => {
      this.showWarehousesResponse();
    });
    this.warehouseTemp = null;
    this.displayDialogEdit = false;
  }

  delete() {
    this.warehouseService.delete(this.selectedWarehouse).subscribe(() => {
      this.showWarehousesResponse();
    });
    this.warehouseTemp = null;
    this.displayDialogEdit = false;
  }

  onRowSelect(event) {
    this.newWarehouse = false;
    this.warehouseTemp = this.cloneWarehouse(event.data);
    this.isFullfilled = true;
    this.displayDialogEdit = true;
  }

  cloneWarehouse(w: Warehouse): Warehouse {
    // tslint:disable-next-line:prefer-const
    let warehouseTemp = { id: null, name: null, note: null };
    // tslint:disable-next-line:prefer-const
    for (let prop in w) {
      if (w.hasOwnProperty(prop)) {
        warehouseTemp[prop] = w[prop];
      }
    }
    return warehouseTemp;
  }

  saveChanges() {
    this.warehouseTemp.id = this.selectedWarehouse.id;
    this.warehouseService.update(this.warehouseTemp).subscribe(() => {
      this.showWarehousesResponse();
    });
    this.warehouseTemp = null;
    this.displayDialogEdit = false;
  }

  private initForm() {
    this.createForm = this.formBuilder.group({
      name: [null, Validators.required],
      note: [null, Validators.required]
    });
  }
}
