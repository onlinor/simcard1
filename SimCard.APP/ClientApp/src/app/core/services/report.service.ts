import { Observable } from 'rxjs';
import { BaseService } from './base.service';

export class ReportService extends BaseService {
  public getReport(type: number, filter: any): Observable<any> {
    return this.apiService.post(`/report/GetReport/${type}`, filter);
  }
}
