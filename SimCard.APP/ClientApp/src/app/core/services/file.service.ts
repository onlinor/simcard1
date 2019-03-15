import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class FileService extends BaseService {
  constructor() {
    super();
    this.BASE_URI = '/';
  }

  // file uploading method
  Upload(viewModel: any): Observable<any> {
    return this.apiService.post(`${this.BASE_URI}product/import`, viewModel);
  }
}
