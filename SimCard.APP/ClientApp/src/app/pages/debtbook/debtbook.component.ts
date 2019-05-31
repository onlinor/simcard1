import { Component, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormphieuchiComponent } from '../../public/formphieuchi/formphieuchi.component';
import { FormphieuthuComponent } from '../../public/formphieuthu/formphieuthu.component';
import {
  BankbookService,
  CashbookService,
  DebtbookService
} from '../../core/services';

@Component({
  selector: 'app-debtbook',
  templateUrl: './debtbook.component.html',
  styleUrls: ['./debtbook.component.css']
})
export class DebtbookComponent implements OnInit {
  @ViewChild(FormphieuchiComponent)
  myFormChiChild: FormphieuchiComponent;
  @ViewChild(FormphieuthuComponent)
  myFormThuChild: FormphieuthuComponent;
  selectedDonVi = '';
  LoaiDonVi = [
    { label: 'Toàn CN', value: 'TOANCN' },
    { label: 'CN 1', value: 'CN1' },
    { label: 'CN 2', value: 'CN2' },
    { label: 'CN 3', value: 'CN3' },
    { label: 'CN 4', value: 'CN4' }
  ];
  cols: any = [
    { field: 'dateCreated', header: 'Ngày' },
    { field: 'tenKhachHang', header: 'Tên Khách Hàng' },
    { field: 'maKhachHang', header: 'Mã Khách Hàng' },
    { field: 'soPhieu', header: 'Số Phiếu' },
    { field: 'noiDungPhieu', header: 'Diễn Giải' },
    { field: 'noKhach', header: 'Nợ Khách' },
    { field: 'khachNo', header: 'Khách Nợ' },
    { field: 'congDon', header: 'Cộng Dồn' }
  ];

  debtbookData: any;
  selectedDebtbook: any;
  keywordKH = '';
  allKH = false;
  dateFrom: any;
  dateTo: any;
  isShowDialogPhieuChi = false;
  isShowDialogPhieuThu = false;
  idSelectedCashbook: any;
  isNewCashBook: boolean;
  initialDebtbook: any;
  cashbookData: any;
  bankbookData: any;
  subscription: Subscription;
  totalDebtor = 0; // nợ khách
  totalCreditor = 0; // khách nợ
  totalIncremental = 0; // cộng dồn
  constructor(
    private cashbookService: CashbookService,
    private bankbookService: BankbookService,
    private debtbookService: DebtbookService
  ) { }

  ngOnInit() {
    this.subscription = this.debtbookService.getAllDebtbook().subscribe(
      response => {
        this.debtbookData = response;
        this.initialDebtbook = response;
        console.log('debt', this.debtbookData);
      },
      error => { }
    );
    this.subscription = this.cashbookService.getAllCashbook().subscribe(
      response => {
        this.cashbookData = response;
      },
      error => { }
    );

    this.subscription = this.bankbookService.getAllBankbook().subscribe(
      response => {
        this.bankbookData = response;
      },
      error => { }
    );

    // this.debtbookData.map(item => {
    // 	this.totalDebtor = item['noKhach'] + this.totalDebtor;
    // 	this.totalCreditor = item['khachNo'] + this.totalCreditor;
    // })
  }

  onSearchKH() {
    const resultArray = [];
    this.debtbookData = this.initialDebtbook;
    this.keywordKH = this.keywordKH.toLowerCase();
    if (this.keywordKH === '') {
      return this.debtbookData;
    } else {
      for (const item of this.debtbookData) {
        if (item['tenKH'].toLowerCase().includes(this.keywordKH)) {
          resultArray.push(item);
        }
      }
      this.debtbookData = resultArray;
    }
  }

  onSearchByDate() {
    const arrayResult = [];
    this.debtbookData = this.initialDebtbook;
    const dateFrom = new Date(this.dateFrom);
    const dateTo = new Date(this.dateTo);
    if (!dateFrom || !dateTo) {
      return this.debtbookData;
    } else {
      for (const item of this.debtbookData) {
        const ngayLap = new Date(item.ngayLap);
        if (dateFrom <= ngayLap && ngayLap < dateTo) {
          arrayResult.push(item);
        }
      }
      this.debtbookData = arrayResult;
    }
  }
  onGetIsShowDialogPhieuChi(data: any) {
    this.isShowDialogPhieuChi = data;
  }

  onGetIsShowDialogPhieuThu(data: any) {
    this.isShowDialogPhieuThu = data;
  }
  onRowSelect(event: any) {
    this.isNewCashBook = false;
    this.idSelectedCashbook = event.data.id;
    let data = {};
    const soPhieu = event.data['soPhieu'];
    const isPC = soPhieu.includes('PC');
    const isPT = soPhieu.includes('PT');
    const isPayATM = soPhieu.includes('/');
    if (isPayATM) {
      data = this.bankbookData.filter(item => {
        return item['maPhieu'] === soPhieu;
      });
    } else {
      data = this.cashbookData.filter(item => {
        return item['maPhieu'] === soPhieu;
      });
    }
    if (isPC) {
      this.isShowDialogPhieuChi = true;
      let checkHTChi = '';
      if (data[0]['hinhThucChi']) {
        checkHTChi = data[0]['hinhThucChi'];
      }
      if (checkHTChi === 'TM') {
        this.myFormChiChild.isCash = true;
        this.myFormChiChild.isATM = false;
      }
      if (checkHTChi === 'CK,TM') {
        this.myFormChiChild.isATM = true;
        this.myFormChiChild.isCash = true;
      }
      if (checkHTChi === 'CK') {
        this.myFormChiChild.isCash = false;
        this.myFormChiChild.isATM = true;
      }
      if (checkHTChi === '') {
        this.myFormChiChild.isCash = false;
        this.myFormChiChild.isATM = false;
      }
      this.myFormChiChild.dataPhieuChi = data[0];
    }
    if (isPT) {
      this.isShowDialogPhieuThu = true;
      let checkHTThu = '';
      if (data[0]['hinhThucNop']) {
        checkHTThu = data[0]['hinhThucNop'];
      }
      if (checkHTThu === 'TM') {
        this.myFormThuChild.isATM = false;
        this.myFormThuChild.isCash = true;
      }
      if (checkHTThu === 'CK,TM') {
        this.myFormThuChild.isATM = true;
        this.myFormThuChild.isCash = true;
      }
      if (checkHTThu === 'CK') {
        this.myFormThuChild.isATM = true;
        this.myFormThuChild.isCash = false;
      }
      if (checkHTThu === '') {
        this.myFormThuChild.isATM = false;
        this.myFormThuChild.isCash = false;
      }
      this.myFormThuChild.dataPhieuThu = data[0];
    }
  }
}
