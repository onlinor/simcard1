import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bankbook',
  templateUrl: './bankbook.component.html',
  styleUrls: ['./bankbook.component.css']
})
export class BankbookComponent implements OnInit {
	selectedDonVi: String = '';
	LoaiDonVi = [
		{ label: 'Shop 1', value: 'CN1' },
		{ label: 'Shop 2', value: 'CN2' },
		{ label: 'Shop 3', value: 'CN3' },
		{ label: 'Shop 4', value: 'CN4' }
	];
	isShowDialogPhieuChi: boolean = false;
	isShowDialogPhieuThu: boolean = false;
	constructor() {}

	ngOnInit() {}
	
	onShowDialogPhieuChi() {
	this.isShowDialogPhieuChi = true;
	}

	onGetIsShowDialogPhieuChi(data: any) {
	this.isShowDialogPhieuChi = data;
	}

	onShowDialogPhieuThu() {
	this.isShowDialogPhieuThu = true;
	}

	onGetIsShowDialogPhieuThu(data: any) {
	this.isShowDialogPhieuThu = data;
	}
}
