import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Product } from './product';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  baseUrl = 'http://localhost:5000/api/product';

  constructor(private http: HttpClient) { }

  getProducts (): Observable<HttpResponse<Product>> {
    return this.http.get<Product>(
       this.baseUrl, {observe: 'response'}
    );
  }

  // deleteProduct (id: number): Observable<{}> {
  //   return this.http.delete(
  //     `${this.baseUrl}/remove/${id}`, httpOptions)
  //     .pipe(
  //       // catchError() and handleerror implement
  //     );
  // }


  addProduct (product: Product): Observable<Product> {
    return this.http.post<Product>(
      `${this.baseUrl}/add`, product, httpOptions)
      .pipe(
        // catchError() and handleerror implement
      );
  }

  // updateProduct (product: Product): Observable<Product> {
  //   return this.http.put<Product>(
  //     `${this.baseUrl}/edit/${warehouse.id}`, warehouse, httpOptions)
  //     .pipe(
  //       // catchError() and handleerror implement
  //     );
  // }

  UpdateQuantityByProductName (name: string, quantity: number): Observable<any> {

    const pro = {name: name, quantity: quantity};

    return this.http.put(
      `${this.baseUrl}/edit`, pro, httpOptions)
      .pipe(

      );
  }

  addProducts (products: Product[]): Observable<Product> {
    return this.http.post<Product>(
      `${this.baseUrl}/addproducts`, products, httpOptions)
      .pipe(
        // catchError() and handleerror implement
      );
  }
}
