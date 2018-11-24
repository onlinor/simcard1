import { Component, OnInit } from '@angular/core';
import { WarehouseService } from '../services/warehouse.service';
import { Warehouse } from '../services/warehouse';

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.css']
})
export class WarehouseComponent implements OnInit {

  displayDialogAdd: boolean;
  displayDialogEdit: boolean;
  warehouseTemp: Warehouse = {'id': null, 'name': null, 'note': null};
  selectedWarehouse: Warehouse;
  newWarehouse: boolean;
  warehouses: Warehouse[];
  cols: any[];
  // loading
  isFullfilled: any;
  // httpclent
  headers: any;
  // datatable

  constructor(private warehouseService: WarehouseService) { }

  ngOnInit() {
    this.showWarehousesResponse();

    this.cols = [
      { field: 'id', header: 'ID' },
      { field: 'name', header: 'Name' },
      { field: 'note', header: 'Note' }
    ];
  }

  showDialogToAdd() {
    this.newWarehouse = true;
    this.warehouseTemp = {'id': null, 'name': null, 'note': null};
    this.displayDialogAdd = true;
  }

  add() {
    this.warehouseTemp.id = 0; // set to not null to pass to api
    this.warehouseService.addWarehouse(this.warehouseTemp).subscribe(() => {
      this.showWarehousesResponse();
    });
    this.warehouseTemp = null;
    this.displayDialogAdd = false;
  }

  delete() {
    this.warehouseService.deleteWarehouse(Number(this.selectedWarehouse.id)).subscribe(() => {
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
    let warehouseTemp = {'id': null, 'name': null, 'note': null};
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
    this.warehouseService.updateWarehouse(this.warehouseTemp).subscribe(() => {
      this.showWarehousesResponse();
    });
    this.warehouseTemp = null;
    this.displayDialogEdit = false;
  }

  showWarehousesResponse() {
    this.warehouseService.getWarehouses().subscribe(
      // resp is of type `HttpResponse<WarehouseConfig>`
      resp => {
        // display its headers
        const keys = resp.headers.keys();
        this.headers = keys.map(key =>
          `${key}: ${resp.headers.get(key)}`);

        // access the body directly, which is typed as `WarehouseConfig`.
        this.extractData(resp.body);
      }
    );
  }

  extractData(body: any) {
    this.warehouses = [];
    for (const warehouse of body) {
      this.warehouses.push(warehouse);
    }
  }
}
