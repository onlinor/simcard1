import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';

import {Observable} from 'rxjs/internal/Observable';

@Injectable()
export class ApiService {

  private baseURL = 'http://localhost:5000/api';

  constructor(private http: HttpClient) {
  }

  get(path: string, params?: HttpParams): Observable<any> {
    return this.http.get(`${this.baseURL}` + `${path}`, {
      params: params
    });
  }

  post(path: string, data?: any, params?: HttpParams): Observable<any> {
    return this.http.post(
      `${this.baseURL}` + `${path}`,
      data,
      {
        params: params
      }
    );
  }

  put(path: string, data?: any): Observable<any> {
    return this.http.put(
      `${this.baseURL}` + `${path}`,
      data
    );
  }

  delete(path: string, params?: HttpParams): Observable<any> {
    return this.http.delete(`${this.baseURL}` + `${path}`, {
      params: params
    });
  }
}
