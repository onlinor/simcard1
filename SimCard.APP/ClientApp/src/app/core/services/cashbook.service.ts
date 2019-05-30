import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';

@Injectable()
export class CashbookService extends BaseService {
  constructor() {
    super();
    this.BASE_URI = '/cashbook';
  }
  getAllCashbook(): Observable<any> {
    return this.apiService.get(this.BASE_URI);
  }

  getCashbook(id: number): Observable<any> {
    return this.apiService.get(`${this.BASE_URI}/${id}`);
  }

  addCashbook(cashbook: any): Observable<any> {
    return this.apiService.post(this.BASE_URI, cashbook);
  }

  deleteCashbook(id: number): Observable<any> {
    return this.apiService.delete(`${this.BASE_URI}/${id}`);
  }

  updateCashbook(id: number, cashbook: any): Observable<any> {
    return this.apiService.put(`${this.BASE_URI}/${id}`, cashbook);
  }

  getLastIDCashbookRecord(): Observable<any> {
    return this.apiService.get(`${this.BASE_URI}/last`);
  }
}
