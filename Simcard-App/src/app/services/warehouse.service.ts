import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Warehouse } from './warehouse';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})

export class WarehouseService {

  baseUrl = 'http://localhost:5000/api/warehouse';

  constructor(private http: HttpClient) { }

  getWarehouses (): Observable<HttpResponse<Warehouse>> {
    return this.http.get<Warehouse>(
       this.baseUrl, {observe: 'response'}
    );
  }

  deleteWarehouse (id: number): Observable<{}> {
    return this.http.delete(
      `${this.baseUrl}/remove/${id}`, httpOptions)
      .pipe(
        // catchError() and handleerror implement
      );
  }


  addWarehouse (warehouse: Warehouse): Observable<Warehouse> {
    return this.http.post<Warehouse>(
      `${this.baseUrl}/add`, warehouse, httpOptions)
      .pipe(
        // catchError() and handleerror implement
      );
  }

  updateWarehouse (warehouse: Warehouse): Observable<Warehouse> {
    return this.http.put<Warehouse>(
      `${this.baseUrl}/edit/${warehouse.id}`, warehouse, httpOptions)
      .pipe(
        // catchError() and handleerror implement
      );
  }
}
