import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';

@Injectable()
export class CustomerService extends BaseService {
  constructor() {
    super();
    this.BASE_URI = '/customer';
  }

  getAllCustomer(): Observable<any> {
    return this.apiService.get(this.BASE_URI);
  }

  getCustomer(id: number): Observable<any> {
    return this.apiService.get(`${this.BASE_URI}/${id}`);
  }

  addCustomer(customer: any): Observable<any> {
    return this.apiService.post(this.BASE_URI, customer);
  }

  deleteCustomer(id: number): Observable<any> {
    return this.apiService.delete(`${this.BASE_URI}/${id}`);
  }

  updateCustomer(id: number, customer: any): Observable<any> {
    return this.apiService.put(`${this.BASE_URI}/${id}`, customer);
  }

  getLastIDCustomerRecord(): Observable<any> {
    return this.apiService.get(`${this.BASE_URI}/last`);
  }

  uploadFile(file: File) {
    const formData = new FormData();
    formData.append(file.name, file);
    return this.apiService.post(`${this.BASE_URI}/import`, formData).pipe();
  }
}
