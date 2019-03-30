import { BaseService } from './base.service';
import { Observable } from 'rxjs';

export class ShopService extends BaseService {
  getAll(): Observable<any> {
    return this.apiService.get('/shops');
  }

  addShop(viewModel: any): Observable<any> {
    return this.apiService.post(`${this.BASE_URI}/add`, viewModel);
}
}
