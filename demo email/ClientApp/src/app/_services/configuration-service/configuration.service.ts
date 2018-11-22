import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class ConfigurationService {

    constructor(private http: HttpClient) { }
    baseUrl = 'http://localhost:5000/api/configuration/';
    getAllConfiguration() {
        return this.http.get(this.baseUrl);
    }

    getConfiguration(id: number) {
        return this.http.get(this.baseUrl + id);
    }

    updateCustomer(id: number, configuration: any) {
        return this.http.put(this.baseUrl + id, configuration);
    }
}
