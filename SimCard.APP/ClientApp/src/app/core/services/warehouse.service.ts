import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class WarehouseService extends BaseService {

    constructor() {
        super();
        this.BASE_URI = '/warehouse';
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

    update(viewModel: any): Observable<any> {
        return this.apiService.put(`${this.BASE_URI}/edit/${viewModel.id}`, viewModel);
    }

    delete(viewModel: any): Observable<any> {
        return this.apiService.delete(`${this.BASE_URI}/remove/${viewModel.id}`);
    }
}