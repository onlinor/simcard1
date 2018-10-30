import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../_services/customer-service/customer.service';

@Component({
    selector: 'app-customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
    isHideAllField = true;
    initialCustomer: any;
    keyword: string;
    dsFieldInTable = {
        maKH: true,
        tenCH: true,
        diachiCH: true,
        hoTen: true,
        sdt1: true,
        sdt2: false,
        ngaySinh: true,
        gioiTinh: true,
        email: false,
        fb: false,
        zalo: false,
        tenCongTy: false,
        masoThue: false,
        diachiHoaDon: true,
        nguonDen: false,
        ngayDen: true,
        ngGioiThieu: false,
        matheTV: false
    };
    customers: any;
    constructor(
        private customerService: CustomerService
    ) { }

    ngOnInit() {
        this.getAllCustomers();
    }
    // GET ALL CUSTOMERF FROM DB
    getAllCustomers() {
        this.customerService.getAllCustomer().subscribe(
            response => {
                this.customers = response;
                this.initialCustomer = response;
            },
            error => {
                console.log(error);
            });
    }
    // GET LIST FIELD AND LOGIC
    onGetListField(value) {
        this.dsFieldInTable = value;
        let flag = false;
        // tslint:disable-next-line:forin
        for (const item in this.dsFieldInTable) {
            if (this.dsFieldInTable[item]) {
                flag = true;
            }
        }
        if (flag === true) {
            this.isHideAllField = true;
        } else {
            this.isHideAllField = false;
        }
    }

    // SEARCH
    onGetKeywordKH(keyword) {
        const resultArray = [];
        this.customers = this.initialCustomer; // rest customers array
        this.keyword = keyword.toLowerCase();
        if (keyword === '') {
            return this.customers;
        } else {
            for (const item of this.customers) {
                if (item['hoTen'].toLowerCase().includes(this.keyword)) {
                    resultArray.push(item);
                }
            }
            this.customers = resultArray;
        }
    }
}
