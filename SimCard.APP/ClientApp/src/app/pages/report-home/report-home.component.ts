import { Component, OnInit } from '@angular/core';
import {
  ReportService,
  DocExportingService,
  ProductService,
  ShopService,
  SupplierService,
  CustomerService,
  BankbookService
} from '../../core/services';
import { ReportConstant, ExportConstant } from '../../core';

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

  // Supported Export Methods
  selectedExportMethod = 'xlsx';
  supportedExportMethods = ExportConstant.SupportedExportMethod;

  // Report types
  reports = ReportConstant.SupportedReports;

  constructor(
    private reportService: ReportService,
    private docExportingService: DocExportingService,
    private shopService: ShopService,
    private productService: ProductService,
    private supplierService: SupplierService,
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

        this.bankAccounts = result.filterData.bankAccounts;
        this.products = result.filterData.products;
        this.shops = result.filterData.shops;
        this.warehouses = result.filterData.warehouses;
        this.customers = result.filterData.customers;
      },
      error => console.log('Error getting data from API')
    );
  }

  filter() {
    console.log(this.selectedFilter);
  }

  export() {
    switch (this.selectedExportMethod) {
      case 'xlsx':
        this.exportToExcel();
        break;
      default:
        this.exportToPdf();
        break;
    }
  }

  private clearFilter() {
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

  private getShops() {
    this.shopService.getAll().subscribe(
      result => {
        this.shops = result;
      },
      error => console.log('Error getting data from API')
    );
  }

  private getProducts() {
    this.productService.getAll().subscribe(
      result => {
        this.products = result;
      },
      error => console.log('Error getting data from API')
    );
  }

  private getWarehouses() {
    this.supplierService.getAll().subscribe(
      result => {
        this.warehouses = result;
      },
      error => console.log('Error getting data from API')
    );
  }

  private getCustomers() {
    this.customerService.getAllCustomer().subscribe(
      result => {
        this.customers = result;
      },
      error => console.log('Error getting data from API')
    );
  }

  private getBankAccounts() {
    this.bankService.getAllBankbook().subscribe(
      result => {
        this.bankAccounts = result;
      },
      error => console.log('Error getting data from API')
    );
  }

  private exportToExcel() {
    this.docExportingService.exportReportToExcel(this.selectedReport).subscribe(
      result => {
        console.log('File exported.');
      },
      error => console.log('Error getting data from API')
    );
  }

  private exportToPdf() {
    this.docExportingService.exportReportToPdf(this.selectedReport).subscribe(
      result => {
        console.log('File exported.');
      },
      error => console.log('Error getting data from API')
    );
  }
}
