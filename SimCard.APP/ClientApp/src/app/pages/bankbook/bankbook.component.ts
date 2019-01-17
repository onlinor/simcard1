import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-bankbook",
  templateUrl: "./bankbook.component.html",
  styleUrls: ["./bankbook.component.css"]
})
export class BankbookComponent implements OnInit {
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
