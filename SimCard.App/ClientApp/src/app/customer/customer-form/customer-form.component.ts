import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerService } from '../../_services/customer-service/customer.service';
import { NgForm } from '@angular/forms';
import $ from 'jquery';

declare var $: any;

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
    @ViewChild('f') ngForm: NgForm;
    test: string;
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
        ngayDen: new Date().toLocaleDateString(),
        ngaySinh: null,
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
    constructor(private http: HttpClient, private customerService: CustomerService ) {
    }

    ngOnInit() {
        this.getAllCustomers();
        this.getLastIDCustomerRecord(); // get last record id to generate maKH
    }

    onHandleInputYear() {
        this.isInputYear = !this.isInputYear;
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
    // trigger when open form
    onGenerateMaKH() {
        this.lastIDRecord = this.lastIDRecord + 1;
        const maKH = 'KH' + this.lastIDRecord;
        this.customerInfo.maKH = maKH;
        this.customerInfo.matheTV = maKH;
    }

    // combine day, month, year when no input year
    onHandleDateNoYear() {
        this.customerInfo.ngaySinh = this.year + '-' + this.month + '-' + this.day;
    }
    //
    getAllCustomers() {
        this.customerService.getAllCustomer().subscribe(
            response => {
                this.customers = response;
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
                console.log('Submit fail');
                return;
            } else {
                this.onHandleDateNoYear(); // combine day, month, year
            }
        }
        console.log('submit', this.customerInfo);
        this.customerService.addCustomer(this.customerInfo)
            .subscribe(() => {
                console.log('Submit Success');
            },
            error => {
                console.log(error);
            }
        );
        this.onRefreshData();
        this.onCloseModal();
    }
    onRefreshData() {
        this.ngForm.reset();
        if (this.isInputYear) {
            this.isInputYear = false;
        }
        this.customerInfo.ngaySinh = '';
    }
    // DELETE CUSTOMER
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
    // UPDATE CUSTOMER
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

    onGenerateNgayDen() {
        this.customerInfo.ngayDen = new Date().toLocaleDateString();
    }

    onClearData() {
        $('#hoTen').trigger('focus');
        if (this.isInputYear) {
            this.isInputYear = false;
        }
        this.customerInfo = {
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
            ngayDen: new Date().toLocaleDateString(),
            ngaySinh: null,
            gioiTinh: null
        };
        this.onGenerateMaKH();
    }

    // Trigger from date-input
    onGetDay(day) {
        this.day = day;
        if (+this.day < 10) { // prefix 0 follow yyyy-MM-dd format
            this.day = '0' + this.day;
        }
    }

    // Trigger from date-input
    onGetMonth(month) {
        this.month = month;
    }

    onOpenModal() {
        this.onGenerateMaKH();
        this.onGenerateNgayDen();
        $('#form-modal').modal('show');
        $('#form-modal').on('shown.bs.modal', function () {
            $('#hoTen').trigger('focus');
        });
    }

    onCloseModal() {
        $('#form-modal').modal('hide');
        this.onRefreshData();
    }
}
