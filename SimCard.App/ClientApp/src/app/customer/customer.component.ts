import { Component, OnInit, ViewChild, OnDestroy} from '@angular/core';
import { CustomerService } from '../_services/customer-service/customer.service';
import { MessageService } from 'primeng/api';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs/subscription';

@Component({
    selector: 'app-customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit, OnDestroy {
    @ViewChild('f') ngForm: NgForm;
    isNgaySinhValid = true;
    dayCheck: any;
    monthCheck: any;
    isDateNoYear: boolean;
    isOpenDialog: boolean;
    idSelectedCustomer: any;
    isNewCustomer: boolean;
    initialCustomer: any;
    keyword: string;
    isInputYear: Boolean = false;
    year = 1900;
    day: string;
    month: string;
    lastIDRecord: any;
    customerInfo: any = {
        tenCH: '',
        diachiCH: '',
        hoTen: '',
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
    subscription: Subscription;
    constructor(
        private customerService: CustomerService,
        private messageService: MessageService
    ) { }

    toastSuccess() {
        this.messageService.add({
            severity: 'success',
            detail: 'Dữ liệu đã được cập nhật'
        });
    }

    ngOnInit() {
        this.getAllCustomers();
    }

    // get all customers from db
    getAllCustomers() {
        this.subscription = this.customerService.getAllCustomer().subscribe(
            response => {
                this.customers = response;
                this.initialCustomer = response;
                console.log('kh', this.customers);
            },
            error => {
                console.log(error);
            }
        );
    }

    // get last id record to generate maKH with type: KH + id
    getLastIDCustomerRecord() {
        this.subscription = this.customerService.getLastIDCustomerRecord().subscribe(
            response => {
                this.lastIDRecord = response;
                this.onGenerateMaKH();
            },
            error => {
                console.log(error);
            }
        );
    }

    // generate maKH follow id
    onGenerateMaKH() {
        if (!this.lastIDRecord) {
            this.lastIDRecord = 0;
        }
        this.lastIDRecord = this.lastIDRecord + 1;
        const maKH = 'KH' + this.lastIDRecord;
        this.customerInfo.maKH = maKH;
        this.customerInfo.matheTV = maKH;
    }

    // generate ngayDen as local datetime
    onGenerateNgayDen() {
        this.customerInfo.ngayDen = new Date().toLocaleDateString();
    }

    // parseDate to string
    parseDate(dateString: string, prop: string): Date {
        if (dateString) {
            this.customerInfo[prop] = new Date(dateString);
            this.customerInfo.ngayDen = new Date();
            if (this.customerInfo.ngaySinh > this.customerInfo.ngayDen) {
                this.isNgaySinhValid = false;
            } else {
                this.isNgaySinhValid = true;
            }
        } else {
            return null;
        }
    }

    // Trigger from date-input
    onGetDay(day) {
        this.day = day;
        if (+this.day < 10) {
            // prefix 0 follow yyyy-MM-dd format
            this.day = '0' + this.day;
        }
    }

    // Trigger from date-input
    onGetMonth(month) {
        this.month = month;
    }

    // handle when checked/unchecked the checkbox of year
    onHandleInputYear() {
        this.isInputYear = !this.isInputYear;
        if (this.isInputYear) {
            this.customerInfo.ngaySinh = null;
            if (this.day && this.month) {
                this.onHandleDateNoYear();
            }
        } else {
            this.day = null;
            this.month = null;
        }
    }

    // combine day, month, year when no input year
    onHandleDateNoYear() {
        this.customerInfo.ngaySinh = this.year + '-' + this.month + '-' + this.day;
    }
    // GET LIST FIELD AND LOGIC
    onGetListField(value) {
        this.dsFieldInTable = value;
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

    // select row on table
    onRowSelect(event) {
        this.isOpenDialog = true;
        this.isNewCustomer = false;
        this.idSelectedCustomer = event.data.id;
        this.customerInfo = this.cloneCustomer(event.data);
        this.customerInfo.ngaySinh = new Date(this.customerInfo.ngaySinh);
        const namSinh = this.customerInfo.ngaySinh.getFullYear();
        if (namSinh === 1900) {
            this.isInputYear = true;
            this.dayCheck = this.customerInfo.ngaySinh.getDate();
            this.monthCheck = this.customerInfo.ngaySinh.getMonth() + 1;
            this.customerInfo.ngaySinh = null;
            this.day = this.dayCheck;
            this.month = this.monthCheck;
        } else {
            this.isInputYear = false;
            this.dayCheck = null;
            this.monthCheck = null;
            this.day = null;
            this.month = null;
        }
    }

    // call in onSelectRow to through obj
    cloneCustomer(customer: any) {
        const customerToUpdate = {};
        // tslint:disable-next-line:forin
        for (const prop in customer) {
            customerToUpdate[prop] = customer[prop];
        }
        return customerToUpdate;
    }

    // Open form.
    showDialogToAdd() {
        this.ngForm.reset();
        this.dayCheck = null;
        this.monthCheck = null;
        this.customerInfo = {};
        this.getLastIDCustomerRecord();
        this.onGenerateNgayDen();
        this.isOpenDialog = true;
        this.isNewCustomer = true;
    }

    // Submit form
    onSubmit() {
        if (this.isInputYear) {
            this.onHandleDateNoYear();
        }
        if (this.isNewCustomer) {
            this.subscription = this.customerService.addCustomer(this.customerInfo)
                .subscribe(() => {
                        this.toastSuccess();
                        this.getAllCustomers();
                    },
                    error => {
                        console.log(error);
                    }
            );
        } else {
            this.subscription = this.customerService.updateCustomer(this.idSelectedCustomer, this.customerInfo)
                .subscribe(() => {
                        this.toastSuccess();
                        this.getAllCustomers();
                    },
                    error => {
                        console.log(error);
                    }
                );
        }
        this.isOpenDialog = false;
    }

    // Clear all data in form
    onClearData() {
        this.ngForm.reset();
        this.customerInfo = {};
        this.onGenerateNgayDen();
        this.getLastIDCustomerRecord();
    }

    // Delete data
    onDeleteData() {
        this.subscription = this.customerService.deleteCustomer(this.idSelectedCustomer)
            .subscribe(() => {
                this.toastSuccess();
                this.getAllCustomers();
            },
            error => {
                console.log(error);
            }
        );
        this.ngForm.reset();
        this.isOpenDialog = false;
    }

    ngOnDestroy() {
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }
}
