import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PhieuxuatService extends BaseService {

    constructor() {
        super();
        this.BASE_URI = '/exportreceipt';
    }

    getProductCode (): Observable<any> {
        return this.apiService.get(`${this.BASE_URI}/getproductcode`);
    }

    addPhieuxuat(viewModel: any): Observable<any> {
        return this.apiService.post(`${this.BASE_URI}/add`, viewModel);
    }
}
