import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-cashbook",
  templateUrl: "./cashbook.component.html",
  styleUrls: ["./cashbook.component.css"]
})
export class CashbookComponent implements OnInit {
	isShowDialogPhieuChi: boolean = false;
	isShowDialogPhieuThu: boolean = false;
	constructor() { }

	ngOnInit() { }

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
