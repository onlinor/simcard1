import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";

@Component({
  selector: "app-formphieuthu",
  templateUrl: "./formphieuthu.component.html",
  styleUrls: ["./formphieuthu.component.css"]
})
export class FormphieuthuComponent implements OnInit {
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
	selectedPhanBo: String = '';
	LoaiPhanBo = [
		{ label: 'Chi Phí', value: 'CP' },
        { label: 'Thu Chi Khác', value: 'TC' },
		{ label: 'Không', value: 'NO'}
	];
	LoaiHinhThucNop = [
		{label: 'Tiền Mặt', value: 'TM'},
		{label: 'Chuyển Khoản', value: 'CK'}
	];
	dataPhieuThu: any = {
		loaiNganHang: '',
		loaiPhanBo: '',
		tenKhachHang: '',
		donviNop: '',
		maKhachHang: '',
		ghiChu: '',
		hinhthucNop: '',
		maPhieu: 'PT',
		nguoiThu: '',
		ngayLap: new Date().toLocaleDateString(),
		noidungPhieu: '',
		sotienThu: 0
	};
	hinhthucCK: boolean = false;
	dsKhachHang: any;
	@Input("isShowDialogPhieuThu") isShowDialogPhieuThu: boolean;
	@Output("outIsShowDialogPhieuThu") emitShowDialogPhieuThu = new EventEmitter<any>();
	@Output("outDataPhieuThu") emitDataPhieuThu = new EventEmitter<any>();
	constructor() {

	}

	ngOnInit() {

	}

	onSubmit() {
		if(this.dataPhieuThu.loaiNganHang.length > 0) {
			let ngayLapType1 = this.dataPhieuThu.ngayLap + '/';
			this.dataPhieuThu.maPhieu = 'PT' + ngayLapType1 + this.dataPhieuThu.loaiNganHang;	
		} else {
			this.dataPhieuThu.maPhieu = 'PT' + this.dataPhieuThu.ngayLap
		}
		this.isShowDialogPhieuThu = false;
		this.emitShowDialogPhieuThu.emit(this.isShowDialogPhieuThu);
		this.emitDataPhieuThu.emit(this.dataPhieuThu);
		this.dataPhieuThu = {};
		this.dataPhieuThu.maPhieu = 'PT'
		this.dataPhieuThu.ngayLap = new Date().toLocaleDateString();
	}

	onChangeHTT(event: any) {
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
		this.dataPhieuThu = {};
		this.dataPhieuThu.maPhieu = 'PT';
		this.dataPhieuThu.ngayLap = new Date().toLocaleDateString();
		this.isShowDialogPhieuThu = false;
		this.emitShowDialogPhieuThu.emit(this.isShowDialogPhieuThu);
	}

	onClearForm() {
		this.dataPhieuThu = {};
		this.dataPhieuThu.ngayLap = new Date().toLocaleDateString();
		this.dataPhieuThu.maPhieu = 'PT';
	}

}
