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
import { Observable } from 'rxjs';

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

  // Supported filter list
  selectedFilterValue = {
    shop: 0,
    from: null,
    to: null,
    product: 0,
    warehouse: 0,
    customer: 0,
    bankAccount: 0
  };
  supportedFilterList = ReportConstant.supportedFilterList;

  // Supported Export Methods
  selectedExportMethod = 'xlsx';
  supportedExportMethods = ExportConstant.SupportedExportMethod;

  // Supported report types
  selectedReport = 1;
  supportedReportTypes = ReportConstant.SupportedReports;

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
    this.getReport();
  }

  // This function will get all data, included report data, columns and filter
  getReport() {
    this.get().subscribe(
      result => {
        // Set report table data
        this.reportData = result.data;
        this.reportColumns = this.getColsFromData(this.reportData[0]);

        // Set filter data
        this.supportedFilterList = this.getSupportedFilterList(result.filterData);
        this.bankAccounts = result.filterData.bankAccounts !== null ? result.filterData.products : [];
        this.products = result.filterData.products !== null ? result.filterData.products : [];
        this.shops = result.filterData.shops !== null ? result.filterData.shops : [];
        this.warehouses = result.filterData.warehouses !== null ? result.filterData.warehouses : [];
        this.customers = result.filterData.customers !== null ? result.filterData.customers : [];
      },
      error => console.log('Error getting data from API')
    );
  }

  // This function will only change report data, filters, columns ... wont be affected
  filter() {
    this.get().subscribe(
      result => {
        this.reportData = result.data;
      },
      error => console.log('Error getting data from API')
    );
  }

  clearFilter() {
    this.selectedFilterValue = {
      shop: 0,
      from: null,
      to: null,
      product: 0,
      warehouse: 0,
      customer: 0,
      bankAccount: 0
    };
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

  private get(): Observable<any> {
    return this.reportService.getReport(
      this.selectedReport,
      this.selectedFilterValue
    );
  }

  private getSupportedFilterList(filterData: any) {
    const filter = this.supportedFilterList;
    const result = {};
    for (const item in filterData) {
      if (filterData.hasOwnProperty(item)) {
        result[item] = true;
      }
    }
    Object.assign(filter, result);
    return filter;
  }

  private getColsFromData(data: any) {
    const result = [];
    for (const item in data) {
      if (data.hasOwnProperty(item)) {
        result.push(item);
      }
    }
    return result;
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
