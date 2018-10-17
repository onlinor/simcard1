import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerService } from '../_services/customer.service';

@Component({
    selector: 'app-customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  customers: any;
  customer: any;
  customerList: any = {};
  customerForUpdate = {
    'storeName': 'STMobile',
    'storeAddress': '35 Le Dai Hanh, Q.10',
    'fullName': 'TranVanTy',
    'phoneNumber': '0909666999',
    'birthday': '1989-12-02',
    'gender': true,
    'email': 'tytyst@gmail.com'
  };

  constructor(private http: HttpClient, private customerService: CustomerService) {}

    ngOnInit() {
        this.getAllCustomers();
        this.getCustomer(45);
    }

    getAllCustomers() {
        this.customerService.getAllCustomer().subscribe(
            response => {
                this.customers = response;
                console.log('cus', this.customers);
            }, error => {
                    console.log(error);
                }
        );
    }

    getCustomer(id: number) {
        this.customerService.getCustomer(45).subscribe(
            response => {
                this.customer = response;
                console.log('one', this.customer);
        }, error => {
            console.log(error);
        });
    }

    addCustomer() {
        console.log(this.customerList);
        this.customerService.addCustomer(this.customerList).subscribe(() => {
            console.log('success');
        }, error => {
            console.log(error);
        });
    }
    DeleteCustomer() {
        this.customerService.deleteCustomer(46).subscribe(() => {
            console.log('success delete');
        }, error => {
            console.log(error);
        });
    }

    updateCustomer() {
        this.customerService.updateCustomer(44, this.customerForUpdate).subscribe(() => {
            console.log('success update');
        }, error => {
            console.log(error);
        });
    }
}
