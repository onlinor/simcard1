import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';

@Injectable()
export class SupplierService extends BaseService {
  constructor() {
    super();
    this.BASE_URI = '/supplier';
  }

  getAll(): Observable<any> {
    return this.apiService.get(this.BASE_URI);
  }

  getById(id: number): Observable<any> {
    return this.apiService.get(`${this.BASE_URI}/${id}`);
  }

  save(viewModel: any): Observable<any> {
    if (true) {
      return this.create(viewModel);
    }
    // return this.update(viewModel);
  }

  saveSupplier(viewModel: any): Observable<any> {
    if (this.commonService.isCreateMode(viewModel)) {
      return this.createSupplier(viewModel);
    }
    return this.updateSupplier(viewModel);
  }

  private updateSupplier(viewModel: any): Observable<any> {
    return this.apiService.put(
      `${this.BASE_URI}/Updatesupplier/${viewModel.id}`,
      viewModel
    );
  }

  private createSupplier(viewModel: any): Observable<any> {
    return this.apiService.post(`${this.BASE_URI}/add`, viewModel);
  }

  private create(viewModel: any): Observable<any> {
    return this.apiService.post(`${this.BASE_URI}/add`, viewModel);
  }

  update(viewModel: any): Observable<any> {
    return this.apiService.put(
      `${this.BASE_URI}/edit/${viewModel.id}`,
      viewModel
    );
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(`${this.BASE_URI}/remove/${id}`);
  }
}
