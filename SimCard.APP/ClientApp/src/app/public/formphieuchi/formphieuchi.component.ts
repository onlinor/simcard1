import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs/subscription";
import { CashbookService } from "../../core/services/cashbook.service";

@Component({
	selector: "app-formphieuchi",
	templateUrl: "./formphieuchi.component.html",
	styleUrls: ["./formphieuchi.component.css"]
})
export class FormphieuchiComponent implements OnInit, OnDestroy {
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

	dataPhieuChi: any = {
		loaiNganHang: '',
		loaiPhanBo: '',
		tenKhachHang: '', 
		donViNhan: '',
		donViNop: '',
		maKhachHang: '', 
		ghiChu: '',
		hinhThucChi: 'TM',
		hinhThucNop: '',
		maPhieu: 'PC', 
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
	dataPhieuChiArray: any;

	@Input("isShowDialogPhieuChi") isShowDialogPhieuChi: boolean;
	@Input("isNewCashBook") isNewCashBook: boolean;
	@Input("idSelectedCashbook") idSelectedCashbook;
	@Output("outIsShowDialogPhieuChi") emitShowDialogPhieuChi = new EventEmitter<any>();
	@Output("outDataPhieuChi") emitDataPhieuChi = new EventEmitter<any>();

	constructor(private cashbookService: CashbookService) {
	}

	ngOnInit() {
	}
	
	checkedATM(event: any) {
		if(this.theATM) {
			this.dataPhieuChi.hinhThucChi = 'TM,CK';
		} else {
			this.dataPhieuChi.hinhThucChi = 'TM';
		}
	}

	onSubmit() {
		if(this.theATM && this.dataPhieuChi.loaiNganHang !== 'default') {
			let ngayLap = new Date().toLocaleDateString();
			this.dataPhieuChi.maPhieu = 'PC' + ngayLap + '/' + this.dataPhieuChi.loaiNganHang;
		} else {
			let ngayLap = new Date().toLocaleDateString();
			this.dataPhieuChi.maPhieu = 'PC' + ngayLap;
		}
		this.isShowDialogPhieuChi = false;
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
		if(this.isNewCashBook)	{
			this.subscription = this.cashbookService.addCashbook(this.dataPhieuChi)
				.subscribe(() => {	
					this.emitDataPhieuChi.emit({...this.dataPhieuChi});
					}, error => {
					}
				);
		} else {
			this.subscription = this.cashbookService.updateCashbook(this.idSelectedCashbook, this.dataPhieuChi)
				.subscribe(() => {
						this.emitDataPhieuChi.emit({...this.dataPhieuChi});
					}, error => {
					}
				);
		}
		this.dataPhieuChi = {};
		this.dataPhieuChi.loaiNganHang = '';
		this.dataPhieuChi.maPhieu = 'PC';
		this.dataPhieuChi.hinhThucChi = 'TM';
		this.dataPhieuChi.ngayLap = new Date().toLocaleDateString();
		this.theATM = false;
	}
	
	
	onClose() {
		this.dataPhieuChi = {};
		this.dataPhieuChi.ngayLap = new Date().toLocaleDateString();
		this.dataPhieuChi.maPhieu = 'PC';
		this.dataPhieuChi.hinhThucChi = 'TM';
		this.theATM = false;
		this.dataPhieuChi.soTienChi = 0;
		this.isShowDialogPhieuChi = false;
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
	}

	onClearForm() {
		this.dataPhieuChi = {};
		this.dataPhieuChi.ngayLap = new Date().toLocaleDateString();
		this.dataPhieuChi.maPhieu = 'PC';
		this.dataPhieuChi.hinhThucChi = 'TM';
		this.theATM = false;
		this.dataPhieuChi.soTienChi = 0;
	}

	ngOnDestroy() {
		if (this.subscription) {
			this.subscription.unsubscribe();
		}
	}
}
