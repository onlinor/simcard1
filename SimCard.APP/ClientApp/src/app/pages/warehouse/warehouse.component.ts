import { Component, OnInit } from '@angular/core';
import { Warehouse } from '../../core/models';
import { WarehouseService } from '../../core/services/warehouse.service';

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.css']
})
export class WarehouseComponent implements OnInit {

  displayDialog: boolean;

  warehouse: Warehouse = new Warehouse();

  selectedWarehouse: Warehouse;

  newWarehouse: boolean;

  warehouses: Warehouse[];

  cols: any[];

  constructor(private warehouseService: WarehouseService) { }


  ngOnInit() {
    this.showWarehousesResponse();

    this.cols = [
      { field: 'name', header: 'Tên' }
    ];
  }

  showDialogToAdd() {
    this.newWarehouse = true;
    this.warehouse = new Warehouse();
    this.displayDialog = true;
  }

  save() {
    this.warehouseService.save(this.warehouse).subscribe(() => {
    this.showWarehousesResponse();
    });

    this.warehouse = new Warehouse();
    this.displayDialog = false;
  }

  showWarehousesResponse() {
    this.warehouseService.getAll().subscribe( resp => {
    this.warehouses = resp;
    });
  }
  delete() {
    const index = this.warehouses.indexOf(this.selectedWarehouse);
    this.warehouses = this.warehouses.filter((val, i) => i !== index);
    this.warehouse = new Warehouse();
    this.displayDialog = false;
  }

  onRowSelect(event) {
    this.newWarehouse = false;
    this.warehouse = this.cloneWarehouse(event.data);
    this.displayDialog = true;
  }

  cloneWarehouse(w: Warehouse): Warehouse {
    // tslint:disable-next-line:prefer-const
    let warehouse = new Warehouse();
    // tslint:disable-next-line:forin
    for (const prop in w) {
      warehouse[prop] = w[prop];
    }
    return warehouse;
  }
}
