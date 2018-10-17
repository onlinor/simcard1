import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
    providedIn: 'root'
})

export class CustomerService {

    baseUrl = 'http://localhost:5000/api/customer/';

    constructor(private http: HttpClient) {

    }

    getAllCustomer() {
        return this.http.get(this.baseUrl);
    }

    getCustomer(id: number) {
        return this.http.get(this.baseUrl + id);
    }

    addCustomer(customer: any) {
        return this.http.post(this.baseUrl, customer);
    }

    deleteCustomer(id: number) {
        return this.http.delete(this.baseUrl + id);
    }

    updateCustomer(id: number, customer: any) {
        return this.http.put(this.baseUrl + id, customer);
    }
}
