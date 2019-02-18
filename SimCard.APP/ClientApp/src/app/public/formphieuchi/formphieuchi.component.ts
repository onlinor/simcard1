import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";

@Component({
	selector: "app-formphieuchi",
	templateUrl: "./formphieuchi.component.html",
	styleUrls: ["./formphieuchi.component.css"]
})
export class FormphieuchiComponent implements OnInit {
	LoaiNganHang = [
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
	LoaiHinhThucChi = [
		{label: 'Tiền Mặt', value: 'TM'},
		{label: 'Chuyển Khoản', value: 'CK'}
	];
	dataPhieuChi: any = {
		loaiNganHang: '',
		loaiPhanBo: '',
		tenKhachHang: '',
		donviNhan: '',
		maKhachHang: '',
		ghiChu: '',
		hinhthucChi: '',
		maPhieu: 'PC',
		nguoiChi: '',
		ngayLap: new Date().toLocaleDateString(),
		noidungPhieu: '',
		sotienChi: 0
	};
	donvinhan = '';
	dsKhachHang: any;
	hinhthucCK: boolean = false;
	@Input("isShowDialogPhieuChi") isShowDialogPhieuChi: boolean;
	@Output("outIsShowDialogPhieuChi") emitShowDialogPhieuChi = new EventEmitter<any>();
	@Output("outDataPhieuChi") emitDataPhieuChi = new EventEmitter<any>();
	constructor() {
	}

	ngOnInit() {
	}

	onSubmit() {
		if(this.dataPhieuChi.loaiNganHang.length > 0) {
			let ngayLapType1 = this.dataPhieuChi.ngayLap + '/';
			this.dataPhieuChi.maPhieu = 'PC' + ngayLapType1 + this.dataPhieuChi.loaiNganHang;	
		} else {
			this.dataPhieuChi.maPhieu = 'PC' + this.dataPhieuChi.ngayLap
		}
		this.isShowDialogPhieuChi = false;
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
		this.emitDataPhieuChi.emit(this.dataPhieuChi);
		this.dataPhieuChi = {};
		this.dataPhieuChi.maPhieu = 'PC'
		this.dataPhieuChi.ngayLap = new Date().toLocaleDateString();
	}
	
	onChangeHTC(event: any) {
		if(event.value.length == 0) {
			this.hinhthucCK = false;
		} else {
			let item = event.value.toString();
			if(item === 'CK' || item === 'CK,TM' || item === 'TM,CK') {
				this.hinhthucCK = true;
			} else {
				this.hinhthucCK = false;
			}
		}
	}
	onClose() {
		this.dataPhieuChi = {};
		this.dataPhieuChi.ngayLap = new Date().toLocaleDateString();
		this.dataPhieuChi.maPhieu = 'PC';
		this.isShowDialogPhieuChi = false;
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
	}

	onClearForm() {
		this.dataPhieuChi = {};
		this.dataPhieuChi.ngayLap = new Date().toLocaleDateString();
		this.dataPhieuChi.maPhieu = 'PC';
	}
}
