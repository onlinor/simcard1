import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerService } from '../../_services/customer.service';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
    @ViewChild('f') ngForm: NgForm;
    year = 1900;
    day: string;
    month: string;
    isInputYear: Boolean = false;
    customerInfo = {
        tenCH: '',
        diachiCH: '',
        hoTen : '',
        sdt1: '',
        sdt2: '',
        maKH: '',
        matheTV: '',
        tenCongTy: '',
        masoThue: '',
        diachiHoaDon: '',
        nguonDen: '',
        ngGioiThieu: '',
        email: '',
        zalo: '',
        fb: '',
        ngayDen: '',
        ngaySinh: '',
        gioiTinh: null
    };
    lastIDRecord: any;
    customers: any;
    customer: any;
    customerForUpdate = {
        tenCH: 'testtestetestMobile',
        diachiCH: 'Muihano',
        hoTen: 'Nickckyyyy',
        sdt1: '0909888222',
        sdt2: '0909000000',
        maKH: 'KH007',
        matheTV: 'KH007',
        tenCongTy: 'Lolo',
        masoThue: '4555',
        diachiHoaDon: 'loggoooo',
        nguonDen: 'zalo',
        ngGioiThieu: 'Ererete',
        email: 'hahagoo@gmail.com',
        fb: 'hahakoo',
        zalo: 'oioerloo',
        ngayDen: '2008-12-02T10:00:00',
        ngaySinh: '1980-11-01T10:00:00',
        gioiTinh: true
    };
    constructor(
        private http: HttpClient,
        private customerService: CustomerService
    ) { }

    ngOnInit() {
        // this.getAllCustomers();
        this.getLastIDCustomerRecord(); // get last record id to generate maKH
    }

    onHandleInputYear() {
        this.isInputYear = !this.isInputYear;
    }

    // trigger when open form
    onGenerateMaKH() {
        this.lastIDRecord = this.lastIDRecord + 1;
        const maKH = 'KH' + this.lastIDRecord;
        this.customerInfo.maKH = maKH;
    }

    onHandleDateNoYear() {
        this.customerInfo.ngaySinh = this.year + '-' + this.month + '-' + this.day;
    }

    // get last id record to generate maKH with type: KH + id
    getLastIDCustomerRecord() {
        this.customerService.getLastIDCustomerRecord().subscribe(
            response => {
                this.lastIDRecord =  response;
            }, error => {
                console.log(error);
            });
    }

    getAllCustomers() {
        this.customerService.getAllCustomer().subscribe(
            response => {
                this.customers = response;
                console.log('cus', this.customers);
            },
            error => {
                console.log(error);
            });
    }

    getCustomer(id: number) {
        this.customerService.getCustomer(45).subscribe(
            response => {
                this.customer = response;
                console.log('one', this.customer);
            },
            error => {
                console.log(error);
            }
        );
    }

    onSubmit() {
        if (this.isInputYear) {
            if (!this.day || !this.month) {
                console.log('submit fail');
                return;
            } else {
                this.onHandleDateNoYear(); // combine day, month, year
            }
        }
        console.log(this.customerInfo);
        this.customerService.addCustomer(this.customerInfo)
            .subscribe(() => {
                console.log('success');
            },
            error => {
                console.log(error);
            }
        );
        this.onClearData();
    }
    //
    deleteCustomer() {
        this.customerService.deleteCustomer(11)
            .subscribe(() => {
                console.log('success delete');
            },
            error => {
                console.log(error);
            }
        );
    }

    updateCustomer() {
        this.customerService.updateCustomer(7, this.customerForUpdate)
            .subscribe(() => {
                console.log('success update');
            },
            error => {
                console.log(error);
            }
        );
    }

    onClearData() {
        this.ngForm.reset();
    }

    // Trigger from date-input
    onGetDay(day) {
        this.day = day;
    }

    // Trigger from date-input
    onGetMonth(month) {
        this.month = month;
    }
}
