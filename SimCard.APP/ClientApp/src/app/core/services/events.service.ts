import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';

@Injectable()
export class EventsService extends BaseService {
  constructor() {
    super();
    this.BASE_URI = '/event';
  }

  getAllEvents(): Observable<any> {
    return this.apiService.get(this.BASE_URI);
  }

  getEvent(id: number): Observable<any> {
    return this.apiService.get(this.BASE_URI);
  }

  addEvent(eventParams: any): Observable<any> {
    return this.apiService.post(this.BASE_URI, eventParams);
  }

  deleteEvent(id: number): Observable<any> {
    return this.apiService.delete(`${this.BASE_URI}/${id}`);
  }

  updateEvent(id: number, eventParams: any): Observable<any> {
    return this.apiService.put(`${this.BASE_URI}/${id}`, eventParams);
  }

  getLastIDEventRecord(): Observable<any> {
    return this.apiService.get(`${this.BASE_URI}/last`);
  }

  updateStatusEvent(id: number, eventParams: any): Observable<any> {
    return this.apiService.put(`${this.BASE_URI}/status/${id}`, eventParams);
  }
}
