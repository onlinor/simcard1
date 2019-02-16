import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from "@angular/core";
import { NgForm } from "@angular/forms";

@Component({
	selector: "app-formphieuchi",
	templateUrl: "./formphieuchi.component.html",
	styleUrls: ["./formphieuchi.component.css"]
})
export class FormphieuchiComponent implements OnInit {
	@ViewChild('f') ngForm: NgForm;
	selectedPhanBo: String = '';
	LoaiPhanBo = [
		{ label: 'Chi Phí', value: 'CP' },
        { label: 'Thu Chi Khác', value: 'TC' },
		{ label: 'Không', value: 'NO'}
	];
	selectedHinhThuc: String = '';
	LoaiHinhThucChi = [
		{label: 'Tiền Mặt', value: 'TM'},
		{label: 'Chuyển Khoản', value: 'CK'}
	];
	dataPhieuChi: any = {
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
	@Input("isShowDialogPhieuChi") isShowDialogPhieuChi: boolean;
	@Input("isNewCashBook") isNewCashBook: boolean;
	@Input("cashbookTemp") cashbookTemp: any;
	@Output("outIsShowDialogPhieuChi") emitShowDialogPhieuChi = new EventEmitter<any>();
	@Output("outDataPhieuChi") emitDataPhieuChi = new EventEmitter<any>();
	constructor() {
	}

	ngOnInit() {
		console.log('test', this.cashbookTemp);
	}

	onSubmit() {
		this.dataPhieuChi.loaiPhanBo = this.selectedPhanBo;
		this.dataPhieuChi.hinhthucChi = this.selectedHinhThuc;
		this.isShowDialogPhieuChi = false;
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
		this.emitDataPhieuChi.emit(this.dataPhieuChi);
		this.dataPhieuChi = {};
		this.dataPhieuChi.maPhieu = 'PC';
		this.dataPhieuChi.ngayLap = new Date().toLocaleDateString();
	}

	onClose() {
		this.dataPhieuChi = {};
		this.dataPhieuChi.ngayLap = new Date().toLocaleDateString();
		this.isShowDialogPhieuChi = false;
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
		this.dataPhieuChi.maPhieu = 'PC';
	}

	onClearForm() {
		this.dataPhieuChi = {};
		this.dataPhieuChi.maPhieu = 'PC';
		this.dataPhieuChi.ngayLap = new Date().toLocaleDateString();
	}

}
