import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class EventsService {
    baseUrl = 'http://localhost:5000/api/event/';
    //
    constructor(private http: HttpClient) { }

    getAllEvents() {
        return this.http.get(this.baseUrl);
    }

    getEvent(id: number) {
        return this.http.get(this.baseUrl + id);
    }

    addEvent(eventParams: any) {
        return this.http.post(this.baseUrl, eventParams);
    }

    deleteEvent(id: number) {
        return this.http.delete(this.baseUrl + id);
    }

    updateEvent(id: number, eventParams: any) {
        return this.http.put(this.baseUrl + id, eventParams);
    }

    getLastIDEventRecord() {
        return this.http.get(this.baseUrl + 'last');
    }

    updateStatusEvent(id: number, eventParams: any) {
        return this.http.put(this.baseUrl + 'status/' + id, eventParams);
    }
}
