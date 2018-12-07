import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpRequest, HttpParams, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Product } from '../../_models/product';

const httpOptions = {
  headers: new HttpHeaders({
    'Accept': 'application/json'
  })
};


@Injectable({
  providedIn: 'root'
})
export class FileImportService {

  baseUrl = 'http://localhost:5000/api/product/import';

  constructor(private http: HttpClient) { }

    // file from event.target.files[0]
    uploadFile(file: File): Observable<Product> {

      // tslint:disable-next-line:prefer-const
      let formData = new FormData();
      formData.append(file.name, file);

      return this.http.post<Product>(
        this.baseUrl, formData, httpOptions, )
        .pipe(
          // catchError() and handleerror implement
        );
    }
}
