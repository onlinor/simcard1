import { Observable } from 'rxjs';
import { BaseService } from './base.service';
import { HttpParams } from '@angular/common/http';

export class ReportService extends BaseService {
    public getReport(type: number, filter: any): Observable<any> {
        const param = new HttpParams().set('type', type.toString());
        return this.apiService.post(`/report/getReport`, filter, param);
  }
}
