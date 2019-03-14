import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PhieunhapService extends BaseService {

    constructor() {
        super();
        this.BASE_URI = '/phieunhap';
    }

    getID (): Observable<any> {
        return this.apiService.get(`${this.BASE_URI}/taoma`);
    }

    addPhieunhap(viewModel: any): Observable<any> {
        return this.apiService.post(`${this.BASE_URI}/add`, viewModel);
    }
}
