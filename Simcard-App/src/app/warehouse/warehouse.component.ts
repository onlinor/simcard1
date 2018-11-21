import { Component, OnInit } from '@angular/core';
import { WarehouseConfig } from '../services/warehouseConfig';
import { WarehouseService } from '../services/warehouse.service';

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.css']
})
export class WarehouseComponent implements OnInit {

  // httpclent
  headers: any;
  // datatable
  warehouses: Array<WarehouseConfig> = new Array<WarehouseConfig>();

  constructor(private warehouseService: WarehouseService) { }

  ngOnInit() {
    this.showWarehousesResponse();
  }

  showWarehousesResponse() {
    this.warehouseService.GetWarehouses().subscribe(
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

  deleteWarehouse(id: any) {
    this.warehouseService.deleteWarehouse(id).subscribe(() => {
      this.showWarehousesResponse();
    });
  }

  onRowClick (event: any, warehosue: any) {
    this.deleteWarehouse(warehosue.id);
  }
}
