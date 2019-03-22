import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProductService extends BaseService {

    constructor() {
        super();
        this.BASE_URI = '/product';
    }

    getAll (): Observable<any> {
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

    createMultiple(viewModel: any): Observable<any> {
        return this.apiService.post(`${this.BASE_URI}/addproducts`, viewModel);
    }

    update(viewModel: any): Observable<any> {
        return this.apiService.put(`${this.BASE_URI}/edit/${viewModel.id}`, viewModel);
    }

    updateQuantityByProductName (viewModel: any): Observable<any> {
        return this.update(viewModel);
      }

    delete(viewModel: any): Observable<any> {
        return this.apiService.delete(`${this.BASE_URI}/remove/${viewModel.id}`);
    }

    getAllGroupByType(): Observable<any> {
        return this.apiService.get(`${this.BASE_URI}/getAllGroupByType`);
    }
}
