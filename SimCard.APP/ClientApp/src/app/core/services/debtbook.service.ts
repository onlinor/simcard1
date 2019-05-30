import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';

@Injectable()
export class DebtbookService extends BaseService {
  constructor() {
    super();
    this.BASE_URI = '/debtbook';
  }
  getAllDebtbook(): Observable<any> {
    return this.apiService.get(this.BASE_URI);
  }
  addDebtbook(debtbook: any): Observable<any> {
    return this.apiService.post(this.BASE_URI, debtbook);
  }
}
