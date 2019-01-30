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
		maPhieu: '',
		nguoiChi: '',
		ngayLap: new Date().toLocaleDateString(),
		noidungPhieu: '',
		soTien: 0
	};
	dsKhachHang: any;
	@Input("isShowDialogPhieuChi") isShowDialogPhieuChi: boolean;
	@Output("outIsShowDialogPhieuChi") emitShowDialogPhieuChi = new EventEmitter<any>();
	constructor() { }

	ngOnInit() {
	}

	onSave() {
		this.dataPhieuChi.loaiPhanBo = this.selectedPhanBo;
		this.dataPhieuChi.hinhthucChi = this.selectedHinhThuc;
		this.isShowDialogPhieuChi = false;
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
		this.ngForm.reset();
	}

	onClose() {
		this.isShowDialogPhieuChi = false;
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
		this.ngForm.reset();
	}
	
	onSubmit() {

	}

	onClearForm() {
		this.ngForm.reset();
	}

}
