import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ConfigurationService extends BaseService {
  constructor() {
    super();
    this.BASE_URI = '/configuration';
  }

  getAllConfiguration(): Observable<any> {
    return this.apiService.get(this.BASE_URI);
  }

  getConfiguration(id: number): Observable<any> {
    return this.apiService.get(`${this.BASE_URI}/${id}`);
  }

  updateConfiguration(id: number, configuration: any): Observable<any> {
    return this.apiService.put(`${this.BASE_URI}/${id}`, configuration);
  }
}
