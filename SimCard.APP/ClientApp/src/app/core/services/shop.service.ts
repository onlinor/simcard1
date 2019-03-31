import { BaseService } from './base.service';
import { Observable } from 'rxjs';

export class ShopService extends BaseService {

  constructor() {
    super();
    this.BASE_URI = '/shop';
  }

  getAll(): Observable<any> {
    return this.apiService.get(`${this.BASE_URI}`);
  }

  addShop(viewModel: any): Observable<any> {
    return this.apiService.post(`${this.BASE_URI}/add`, viewModel);
  }

}
