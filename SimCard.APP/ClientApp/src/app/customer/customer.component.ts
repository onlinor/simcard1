import { Component, OnInit, ViewChild, OnDestroy} from '@angular/core';
import { CustomerService } from '../_services/customer-service/customer.service';
import { MessageService } from 'primeng/api';
import { FileService } from '../_services/fileExcel-service/file.service';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs/subscription';

@Component({
    selector: 'app-customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit, OnDestroy {
    @ViewChild('f') ngForm: NgForm;
    selectedCustomer: any;
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
        tenCH: null,
        diachiCH: null,
        hoTen: null,
        sdt1: null,
        sdt2: null,
        maKH: null,
        matheTV: null,
        tenCongTy: null,
        masoThue: null,
        diachiHoaDon: null,
        nguonDen: null,
        ngGioiThieu: null,
        email: null,
        zalo: null,
        fb: null,
        ngayDen: new Date().toLocaleDateString(),
        ngaySinh: null,
        gioiTinh: null
    };
    tempArr: any = {
        id: null,
        tenCH: null,
        diachiCH: null,
        hoTen: null,
        sdt1: null,
        sdt2: null,
        maKH: null,
        matheTV: null,
        tenCongTy: null,
        masoThue: null,
        diachiHoaDon: null,
        nguonDen: null,
        ngGioiThieu: null,
        email: null,
        zalo: null,
        fb: null,
        ngayDen: null,
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
    cols: any = [
        { field: 'maKH', header: 'Mã khách hàng' },
        { field: 'tenCH', header: 'Tên cửa hàng' },
        { field: 'diachiCH', header: 'Địa chỉ cửa hàng' },
        { field: 'hoTen', header: 'Họ tên' },
        { field: 'sdt1', header: 'Số điện thoại' },
        { field: 'sdt2', header: 'Số điện thoại 2' },
        { field: 'ngaySinh', header: 'Ngày sinh' },
        { field: 'gioiTinh', header: 'Giới tính' },
        { field: 'email', header: 'Email' },
        { field: 'zalo', header: 'Zalo' },
        { field: 'fb', header: 'Facebook' },
        { field: 'tenCongTy', header: 'Tên công ty' },
        { field: 'masoThue', header: 'Mã số thuế' },
        { field: 'diachiHoaDon', header: 'Địa chỉ hóa đơn' },
        { field: 'nguonDen', header: 'Nguồn đến' },
        { field: 'ngayDen', header: 'Ngày đến' },
        { field: 'ngGioiThieu', header: 'Người giới thiệu' },
        { field: 'matheTV', header: 'Mã thẻ TV' }
    ];
    customers: any;
    subscription: Subscription;
    constructor(
        private customerService: CustomerService,
        private messageService: MessageService,
        private fileService: FileService
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

    onCloseForm() {
        this.isOpenDialog = false;
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

    myUploader(event) {
        // tslint:disable-next-line:prefer-const
        let fileList: FileList = event.target.files;
        if (fileList.length > 0) {
            // tslint:disable-next-line:prefer-const
            let file: File = fileList[0];
            this.subscription = this.fileService.uploadFile(file)
                .subscribe(response => {
                    // tslint:disable-next-line:prefer-const
                    let tempCustomer = Object.assign([], this.customers);
                    // tslint:disable-next-line:prefer-const
                    let tempResponse = response;
                    // tslint:disable-next-line:forin
                    for (const i in tempResponse) {
                        let flag = false;
                        const idPropResponse = tempResponse[i].id;
                        // tslint:disable-next-line:forin
                        for (const x in tempCustomer) {
                            if (tempCustomer[x].id === idPropResponse) {
                                flag = true;
                                break;
                            }
                        }
                        if (flag === false) {
                            this.tempArr.id = tempResponse[i].id;
                            this.tempArr.tenCH = tempResponse[i].tenCH;
                            this.tempArr.diachiCH = tempResponse[i].diachiCH;
                            this.tempArr.hoTen = tempResponse[i].hoTen;
                            this.tempArr.sdt1 = tempResponse[i].sdt1;
                            this.tempArr.sdt2 = tempResponse[i].sdt2;
                            this.tempArr.maKH = tempResponse[i].maKH;
                            this.tempArr.matheTV = tempResponse[i].matheTV;
                            this.tempArr.tenCongTy = tempResponse[i].tenCongTy;
                            this.tempArr.masoThue = tempResponse[i].masoThue;
                            this.tempArr.diachiHoaDon = tempResponse[i].diachiHoaDon;
                            this.tempArr.nguonDen = tempResponse[i].nguonDen;
                            this.tempArr.ngGioiThieu = tempResponse[i].ngGioiThieu;
                            this.tempArr.email = tempResponse[i].email;
                            this.tempArr.zalo = tempResponse[i].zalo;
                            this.tempArr.fb = tempResponse[i].fb;
                            this.tempArr.ngayDen = tempResponse[i].ngayDen;
                            this.tempArr.ngaySinh = tempResponse[i].ngaySinh;
                            this.tempArr.gioiTinh = tempResponse[i].gioiTinh;

                            tempCustomer.push(this.tempArr);
                            this.customerService.addCustomer(this.tempArr)
                                .subscribe(() => {
                                    console.log('success');
                                }, error => {
                                    console.log(error);
                            });
                            this.customers = tempCustomer;
                            this.tempArr = {};
                        }
                    }
                }, error => {
                    console.log(error);
                });
        }
    }

    ngOnDestroy() {
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }
}
