import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from "@angular/core";
import { NgForm } from "@angular/forms";

@Component({
  selector: "app-formphieuthu",
  templateUrl: "./formphieuthu.component.html",
  styleUrls: ["./formphieuthu.component.css"]
})
export class FormphieuthuComponent implements OnInit {
	@ViewChild('f') ngForm: NgForm;
	selectedPhanBo: String = '';
	LoaiPhanBo = [
		{ label: 'Chi Phí', value: 'CP' },
        { label: 'Thu Chi Khác', value: 'TC' },
		{ label: 'Không', value: 'NO'}
	];
	selectedHinhThuc: String = '';
	LoaiHinhThucNop = [
		{label: 'Tiền Mặt', value: 'TM'},
		{label: 'Chuyển Khoản', value: 'CK'}
	];
	dataPhieuThu: any = {
		loaiPhanBo: '',
		tenKhachHang: '',
		donviNop: '',
		maKhachHang: '',
		ghiChu: '',
		hinhthucNop: '',
		maPhieu: '',
		nguoiThu: '',
		ngayLap: new Date().toLocaleDateString(),
		noidungPhieu: '',
		soTien: 0
	};
	dsKhachHang: any;
	@Input("isShowDialogPhieuThu") isShowDialogPhieuThu: boolean;
	@Output("outIsShowDialogPhieuThu") emitShowDialogPhieuThu = new EventEmitter<any>();
	constructor() {

	}

	ngOnInit() {

	}

	onSave() {
		this.dataPhieuThu.hinhthucNop = this.selectedHinhThuc;
		this.dataPhieuThu.loaiPhanBo = this.selectedPhanBo;
		this.isShowDialogPhieuThu = false;
		this.emitShowDialogPhieuThu.emit(this.isShowDialogPhieuThu);
		this.ngForm.reset();
	}

	onClose() {
		this.isShowDialogPhieuThu = false;
		this.emitShowDialogPhieuThu.emit(this.isShowDialogPhieuThu);
		this.ngForm.reset();
	}

	onClearForm() {
		this.ngForm.reset();
	}

	onSubmit() {

	}
}
