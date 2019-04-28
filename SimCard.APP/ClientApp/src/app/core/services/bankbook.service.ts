import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class BankbookService extends BaseService {
  constructor() {
    super();
    this.BASE_URI = '/bankbook';
  }

  getAllBankbook(): Observable<any> {
    return this.apiService.get(this.BASE_URI);
  }

  getBankbook(id: number): Observable<any> {
    return this.apiService.get(`${this.BASE_URI}/${id}`);
  }

  addBankbook(bankbook: any): Observable<any> {
    return this.apiService.post(this.BASE_URI, bankbook);
  }

  deleteBankbook(id: number): Observable<any> {
    return this.apiService.delete(`${this.BASE_URI}/${id}`);
  }

  updateBankbook(id: number, bankbook: any): Observable<any> {
    return this.apiService.put(`${this.BASE_URI}/${id}`, bankbook);
  }

  getLastIDBankbookRecord(): Observable<any> {
    return this.apiService.get(`${this.BASE_URI}/last`);
  }
}
