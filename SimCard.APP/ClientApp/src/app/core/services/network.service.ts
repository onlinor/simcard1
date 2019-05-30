import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';

@Injectable()
export class NetworkService extends BaseService {
  constructor() {
    super();
    this.BASE_URI = '/network';
  }

  getAll(): Observable<any> {
    return this.apiService.get(this.BASE_URI);
  }

  save(viewModel: any): Observable<any> {
    if (true) {
      return this.create(viewModel);
    }
    // return this.update(viewModel);
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

  updateQuantityByProductName(viewModel: any): Observable<any> {
    return this.update(viewModel);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(`${this.BASE_URI}/remove/${id}`);
  }
}
