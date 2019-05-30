import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ExportConstant, ReportConstant } from '../../core';
import { DocExportingService, ReportService } from '../../core/services';

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
  supportedFilterList = ReportConstant.SupportedFilterList;

  // Supported Export Methods
  selectedExportMethod = 'xlsx';
  supportedExportMethods = ExportConstant.SupportedExportMethod;

  // Supported report types
  selectedReport = 1;
  supportedReportTypes = ReportConstant.SupportedReports;

  constructor(
    private reportService: ReportService,
    private docExportingService: DocExportingService
  ) {}

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
        this.supportedFilterList = this.getSupportedFilterList(
          result.filterData
        );
        this.bankAccounts =
          result.filterData.bankAccounts !== null
            ? result.filterData.products
            : [];
        this.products =
          result.filterData.products !== null ? result.filterData.products : [];
        this.shops =
          result.filterData.shops !== null ? result.filterData.shops : [];
        this.warehouses =
          result.filterData.warehouses !== null
            ? result.filterData.warehouses
            : [];
        this.customers =
          result.filterData.customers !== null
            ? result.filterData.customers
            : [];
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
        switch (item) {
          case 'matHang':
            result.push({ field: item, header: 'Mặt hàng' });
            break;
          case 'maHang':
            result.push({ field: item, header: 'Mã hàng' });
            break;
          case 'toanCongTy':
            result.push({ field: item, header: 'Toàn công ty' });
            break;
          case 'phieuNhap':
            result.push({ field: item, header: 'Phiếu Nhập' });
            break;
          case 'soLuong':
            result.push({ field: item, header: 'Số lượng' });
            break;
          case 'chietKhauDauVao':
            result.push({ field: item, header: 'Chiết khấu đầu vào' });
            break;
          case 'chietKhauDauRa':
            result.push({ field: item, header: 'Chiết khấu đầu ra' });
            break;
          case 'giaDauVao':
            result.push({ field: item, header: 'Giá đầu vào' });
            break;
          case 'giaDauRa':
            result.push({ field: item, header: 'Giá đầu ra' });
            break;
          case 'khachHang':
            result.push({ field: item, header: 'Khách hàng' });
            break;
          case 'ngayXuat':
            result.push({ field: item, header: 'Ngày xuất' });
            break;
          case 'ngayNhap':
            result.push({ field: item, header: 'Ngày nhập' });
            break;
          case 'ngayThang':
            result.push({ field: item, header: 'Ngày tháng' });
            break;
          case 'noiDung':
            result.push({ field: item, header: 'Nội dung' });
            break;
          case 'thuKhac':
            result.push({ field: item, header: 'Thu khác' });
            break;
          case 'chiKhac':
            result.push({ field: item, header: 'Chi khác' });
            break;
          case 'soThu':
            result.push({ field: item, header: 'Số thu' });
            break;
          case 'soChi':
            result.push({ field: item, header: 'Số chi' });
            break;
          case 'phieuThuChi':
            result.push({ field: item, header: 'Phiếu thu chi' });
            break;
          case 'congDon':
            result.push({ field: item, header: 'Cộng dồn' });
            break;
          case 'chiTietPhieu':
            result.push({ field: item, header: 'Chi tiết phiếu' });
            break;
          case 'noKhach':
            result.push({ field: item, header: 'Nợ khách' });
            break;
          case 'maKhachHang':
            result.push({ field: item, header: 'Mã khách hàng' });
            break;
          case 'noKhach':
            result.push({ field: item, header: 'Nợ khách' });
            break;
          case 'khachNo':
            result.push({ field: item, header: 'Khách nợ' });
            break;
          case 'chiNhanh':
            result.push({ field: item, header: 'Chi nhánh' });
            break;
          case 'loiNhuanBanHang':
            result.push({ field: item, header: 'Lợi nhuận bán' });
            break;
          case 'loiNhuanKhac':
            result.push({ field: item, header: 'Lợi nhuận khác' });
            break;
          case 'tongLoiNhuan':
            result.push({ field: item, header: 'Tổng lợi nhuận' });
            break;
          case 'chiPhiBanHang':
            result.push({ field: item, header: 'Chi phí bán hàng' });
            break;
          case 'loiNhuanThuc':
            result.push({ field: item, header: 'Lợi nhuận thực' });
            break;
          case 'chietKhau':
            result.push({ field: item, header: 'Chiết khấu' });
            break;
          case 'giaNhap':
            result.push({ field: item, header: 'Giá nhập' });
            break;
          case 'giaXuat':
            result.push({ field: item, header: 'Giá xuất' });
            break;
          case 'nhaCC':
            result.push({ field: item, header: 'Nhà cung cấp' });
            break;
          case 'phieuXuat':
            result.push({ field: item, header: 'Phiếu xuất' });
            break;
          case 'thanhTien':
            result.push({ field: item, header: 'Thành tiền' });
            break;
          case 'nganHang':
            result.push({ field: item, header: 'Ngân hàng' });
            break;
          case 'diaChi':
            result.push({ field: item, header: 'Địa chỉ' });
            break;
          case 'giamDoc':
            result.push({ field: item, header: 'Giám đốc' });
            break;
          case 'doanhThuBanHang':
            result.push({ field: item, header: 'Doanh thu bán' });
            break;
          case 'doanhThuNoiBo':
            result.push({ field: item, header: 'Doanh thu nội bộ' });
            break;
          case 'doanhThuThuc':
            result.push({ field: item, header: 'Doanh thu thực' });
            break;
          case 'loiNhuan':
            result.push({ field: item, header: 'Lợi nhuận' });
            break;
          case 'tonDauKy':
            result.push({ field: item, header: 'Tồn đầu kỳ' });
            break;
          case 'thanhTienTonDauKy':
            result.push({ field: item, header: 'Thành tiền tồn đầu kỳ' });
            break;
          case 'nhapTrongKy':
            result.push({ field: item, header: 'Nhập trong kỳ' });
            break;
          case 'thanhTienNhap':
            result.push({ field: item, header: 'Thành tiền nhập' });
            break;
          case 'xuatTrongKy':
            result.push({ field: item, header: 'Xuất trong kỳ' });
            break;
          case 'thanhTienXuat':
            result.push({ field: item, header: 'Thành tiền xuất' });
            break;
          case 'tonCuoiKy':
            result.push({ field: item, header: 'Tồn cuối kỳ' });
            break;
          default:
            result.push({ field: item, header: this.toProperCase(item) });
            break;
        }
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

  private toProperCase(str: string) {
    return str.replace(/\w\S*/g, function(text) {
      return text.charAt(0).toUpperCase() + text.substr(1).toLowerCase();
    });
  }
}
