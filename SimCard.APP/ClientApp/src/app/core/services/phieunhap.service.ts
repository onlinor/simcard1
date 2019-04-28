import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PhieunhapService extends BaseService {
  constructor() {
    super();
    this.BASE_URI = '/importreceipt';
  }

  getProductCode(): Observable<any> {
    return this.apiService.get(`${this.BASE_URI}/getproductcode`);
  }

  addPhieunhap(viewModel: any): Observable<any> {
    return this.apiService.post(`${this.BASE_URI}/add`, viewModel);
  }
}
