import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs/subscription";
import { BankbookService } from "../../core/services/bankbook.service";

@Component({
  selector: 'app-formphieuthubankbook',
  templateUrl: './formphieuthubankbook.component.html',
  styleUrls: ['./formphieuthubankbook.component.css']
})

export class FormphieuthubankbookComponent implements OnInit, OnDestroy {
  LoaiNganHang = [
		{label: 'Chọn', value: 'default'},
		{label: 'Agribank', value: 'AGB'},
		{label: 'Vietcombank', value: 'VCB'},
		{label: 'Viettinbank', value: 'VTB'},
		{label: 'VPbank', value: 'VPB'},
		{label: 'Techcombank', value: 'TCB'},
		{label: 'Shinhanbank', value: 'SHB'},
		{label: 'Sacombank', value: 'SCB'},
		{label: 'DongABank', value: 'DAB'},
		{label: 'AChauBank', value: 'ACB'}
	];

	LoaiPhanBo = [
		{ label: 'Chi Phí', value: 'CP' },
        { label: 'Thu Chi Khác', value: 'TC' },
		{ label: 'Không', value: 'NO'}
	];

	dataPhieuThu: any = {
		loaiNganHang: '',
		loaiPhanBo: '',
		tenKhachHang: '',
		donViNhan: '',
		donViNop: '',
		maKhachHang: '',
		ghiChu: '',
		hinhThucChi: '',
		hinhThucNop: 'TM',
		maPhieu: 'PT',
		nguoiChi: '',
		nguoiThu: '',
		ngayLap: new Date().toLocaleDateString(),
		noiDungPhieu: '',
		soTienChi: 0,
		soTienThu: 0,
		congDon: 0
	};
	theATM: boolean = false;
	dsKhachHang: any;
	subscription: Subscription;
	dataPhieuThuArray: any;

	@Input("isShowDialogPhieuThu") isShowDialogPhieuThu: boolean;
	@Input("isNewCashBook")  isNewCashBook: boolean;
	@Input("idSelectedBankbook") idSelectedBankbook;
	@Output("outIsShowDialogPhieuThu") emitShowDialogPhieuThu = new EventEmitter<any>();
	@Output("outDataPhieuThu") emitDataPhieuThu = new EventEmitter<any>();
	
	constructor(private bankbookService: BankbookService) {

	}

	ngOnInit() {

	}

	checkedATMThu(event: any) {
		if(this.theATM) {
			this.dataPhieuThu.hinhThucNop = 'TM,CK';
		} else {
			this.dataPhieuThu.hinhThucNop = 'TM';
		}
	}

	onSubmit() {
		if(this.theATM && this.dataPhieuThu.loaiNganHang !== 'default') {
			let ngayLap = new Date().toLocaleDateString();
			this.dataPhieuThu.maPhieu = 'PT' +  ngayLap + '/' + this.dataPhieuThu.loaiNganHang;
		} else {
			let ngayLap = new Date().toLocaleDateString();
			this.dataPhieuThu.maPhieu = 'PT' + ngayLap;
		}
		this.isShowDialogPhieuThu = false;
		this.emitShowDialogPhieuThu.emit(this.isShowDialogPhieuThu);
		if(this.isNewCashBook) {
			this.subscription = this.bankbookService.addBankbook(this.dataPhieuThu)
				.subscribe(() => {	
					this.emitDataPhieuThu.emit({...this.dataPhieuThu});
					}, error => {
					}
				);
		} else {
			this.subscription = this.bankbookService.updateBankbook(this.idSelectedBankbook, this.dataPhieuThu)
				.subscribe(() => {
						this.emitDataPhieuThu.emit({...this.dataPhieuThu});
					}, error => {
					}
				);
		}
		this.dataPhieuThu = {};
		this.dataPhieuThu.loaiNganHang = '';
		this.dataPhieuThu.maPhieu = 'PT'
		this.dataPhieuThu.hinhThucThu = 'TM';
		this.dataPhieuThu.ngayLap = new Date().toLocaleDateString();
		this.theATM = false;
	}

	onClose() {
		this.dataPhieuThu = {};
		this.dataPhieuThu.ngayLap = new Date().toLocaleDateString();
		this.dataPhieuThu.maPhieu = 'PT';
		this.dataPhieuThu.hinhThucNop = 'TM';
		this.theATM = false;
		this.dataPhieuThu.soTienThu = 0;
		this.isShowDialogPhieuThu = false;
		this.emitShowDialogPhieuThu.emit(this.isShowDialogPhieuThu);
	}

	onClearForm() {
		this.dataPhieuThu = {};
		this.dataPhieuThu.ngayLap = new Date().toLocaleDateString();
		this.dataPhieuThu.maPhieu = 'PT';
		this.dataPhieuThu.hinhThucNop = 'TM';
		this.theATM = false;
		this.dataPhieuThu.soTienThu = 0;
	}

	ngOnDestroy() {
		if (this.subscription) {
			this.subscription.unsubscribe();
		}
	}
}