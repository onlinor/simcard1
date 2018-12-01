import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
    headers: new HttpHeaders({
        Accept: 'application/json'
    })
};

@Injectable({
    providedIn: 'root'
})
export class FileService {
    baseUrl = 'http://localhost:5000/api/customer/import';

    constructor(private http: HttpClient) { }

    uploadFile(file: File) {
        const formData = new FormData();
        formData.append(file.name, file);
        return this.http.post(this.baseUrl, formData, httpOptions).pipe();
    }
}
