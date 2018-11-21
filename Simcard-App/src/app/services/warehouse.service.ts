import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders, HttpErrorResponse} from '@angular/common/http';
import { WarehouseConfig } from './warehouseConfig';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

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

  GetWarehouses (): Observable<HttpResponse<WarehouseConfig>> {
    return this.http.get<WarehouseConfig>(
       this.baseUrl, {observe: 'response'}
    );
  }

  deleteWarehouse (id: number): Observable<{}> {
      const url = `${this.baseUrl}/remove/${id}`;
      return this.http.delete(url, httpOptions)
      .pipe(
        // catchError() and handleerror implement
      );
  }
}
