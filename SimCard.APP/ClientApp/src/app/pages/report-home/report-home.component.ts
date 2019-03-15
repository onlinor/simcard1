import { Component, OnInit } from '@angular/core';
import {
  ReportService,
  DocExportingService,
  ProductService,
  ShopService,
  WarehouseService,
  CustomerService,
  BankbookService
} from '../../core/services';
import { ReportConstant } from '../../core';

@Component({
  selector: 'app-report-home',
  templateUrl: './report-home.component.html',
  styleUrls: ['./report-home.component.css']
})
export class ReportHomeComponent implements OnInit {
  // Report data and configs
  reportData = [];
  reportColumns = [];

  // Filter data
  shops = [];
  products = [];
  warehouses = [];
  customers = [];
  bankAccounts = [];

  // Filter configs
  selectedReport = 1;
  selectedFilter = {
    shop: 0,
    from: null,
    to: null,
    product: 0,
    warehouse: 0,
    customer: 0,
    bankAccount: 0
  };
  supportedFilter = {
    shop: true,
    from: true,
    to: true,
    product: true,
    warehouse: true,
    customer: true,
    bankAccount: true
  };

  // Report types
  reports = ReportConstant.SupportedReports;

  constructor(
    private reportService: ReportService,
    private docExportingService: DocExportingService,
    private shopService: ShopService,
    private productService: ProductService,
    private warehouseService: WarehouseService,
    private customerService: CustomerService,
    private bankService: BankbookService
  ) { }

  ngOnInit() {
    this.getShops();
    this.getProducts();
    this.getReport();
  }

  getReport() {
    this.reportService.getReport(this.selectedReport, this.selectedFilter).subscribe(
      result => {
        this.reportData = result.data;
        this.reportColumns = result.columns;
        this.supportedFilter = result.supportedFilter;
      },
      error => console.log('Error getting data from API')
    );
  }

  filter() {
    console.log(this.selectedFilter);
  }

  clearFilter() {
    this.selectedFilter = {
      shop: 0,
      from: null,
      to: null,
      product: 0,
      warehouse: 0,
      customer: 0,
      bankAccount: 0
    };
  }

  getShops() {
    this.shopService.getAll().subscribe(
      result => {
        this.shops = result;
      },
      error => console.log('Error getting data from API')
    );
  }

  getProducts() {
    this.productService.getAll().subscribe(
      result => {
        this.products = result;
      },
      error => console.log('Error getting data from API')
    );
  }

  getWarehouses() {
    this.warehouseService.getAll().subscribe(
      result => {
        this.warehouses = result;
      },
      error => console.log('Error getting data from API')
    );
  }

  getCustomers() {
    this.customerService.getAllCustomer().subscribe(
      result => {
        this.customers = result;
      },
      error => console.log('Error getting data from API')
    );
  }

  getBankAccounts() {
    this.bankService.getAllBankbook().subscribe(
      result => {
        this.bankAccounts = result;
      },
      error => console.log('Error getting data from API')
    );
  }

  exportToExcel() {
    this.docExportingService
      .exportReportToExcel(this.selectedReport)
      .subscribe(
        result => { },
        error => console.log('Error getting data from API')
      );
  }

  exportToPdf() {
    this.docExportingService
      .exportReportToPdf(this.selectedReport)
      .subscribe(
        result => { },
        error => console.log('Error getting data from API')
      );
  }
}
