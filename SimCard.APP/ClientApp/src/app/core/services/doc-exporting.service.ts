import { BaseService } from './base.service';
import { Observable } from 'rxjs';

export class DocExportingService extends BaseService {
  exportReportToExcel(type: number): Observable<any> {
    return this.apiService.get(`/report/ExportToExcel${type}`);
  }

  exportReportToPdf(type: number): Observable<any> {
    return this.apiService.get(`/report/ExportToPdf/${type}`);
  }
}
