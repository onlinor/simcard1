import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable()
export class ShopService {
    baseUrl = 'http://localhost:5000/api/product/';

    constructor(private http: HttpClient) { }

    AddProduct(model: any) {
        console.log('vao roi');
        return this.http.post(this.baseUrl + 'AddProduct', model)
        .pipe(
            map((Response: any) => {
                const value = Response;
                if (value) {
                    console.log(value);
                }
            })
        );
    }
}
