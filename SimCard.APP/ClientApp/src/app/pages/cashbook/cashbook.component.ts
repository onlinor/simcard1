import { Component, OnInit, ViewChild } from "@angular/core";
import { FormphieuchiComponent } from "../../public/formphieuchi/formphieuchi.component";
import { FormphieuthuComponent } from "../../public/formphieuthu/formphieuthu.component";

@Component({
	selector: "app-cashbook",
	templateUrl: "./cashbook.component.html",
	styleUrls: ["./cashbook.component.css"]
})
export class CashbookComponent implements OnInit {
	@ViewChild(FormphieuchiComponent)
	myFormChiChild: FormphieuchiComponent;
	@ViewChild(FormphieuthuComponent)
	myFormThuChild: FormphieuthuComponent;
	selectedDonVi: String = "";
	LoaiDonVi = [
		{ label: "Shop 1", value: "CN1" },
		{ label: "Shop 2", value: "CN2" },
		{ label: "Shop 3", value: "CN3" },
		{ label: "Shop 4", value: "CN4" }
	];
	selectedLoaiDuLieu: String = "";
	LoaiDuLieu = [
		{ label: "PDF", value: "PDF" },
		{ label: "Image", value: "IMG" }
	];
	tuNgay: any;
	toiNgay: any;
	tonDauKi: any;
	tonCuoiKi: any;
	soTienThu: any;
	soTienChi: any;
	searchSoTienThu: any;
	searchSoTienChi: any;
	isShowDialogPhieuChi: boolean = false;
	isShowDialogPhieuThu: boolean = false;
	cols: any = [
		{ fleld: "ngayLap", header: "Ngày Lập" },
		{ field: "tenKhachHang", header: "Tên Khách Hàng" },
		{ field: "maPhieu", header: "Mã Phiếu" },
		{ field: "noidungPhieu", header: "Nội Dung Phiếu" },
		{ field: "sotienThu", header: "Số Tiền Thu" },
		{ field: "sotienChi", header: "Số Tiền Chi" }
		//{ field: 'congDon', header: 'Cộng Dồn'}
	];
	cashbook: any = [];
	selectedCashbook: any;
	dataPhieuChi: any;
	dataPhieuThu: any;
	isNewCashBook: boolean;
	idSelectedCashbook: any;
	cashbookTemp: any;

	constructor() { }

	ngOnInit() { }

	onShowDialogPhieuChi() {
		this.isShowDialogPhieuChi = true;
		this.isNewCashBook = true;
	}

	onGetIsShowDialogPhieuChi(data: any) {
		this.isShowDialogPhieuChi = data;
	}

	onGetDataPhieuChi(data: any) {
		let cashbook = [...this.cashbook];
		this.dataPhieuChi = data;
		if (this.isNewCashBook) {
			cashbook.push(this.dataPhieuChi);
		} else {
			cashbook[this.cashbook.indexOf(this.selectedCashbook)] = this.dataPhieuChi;
		}
		this.cashbook = cashbook;
		this.dataPhieuChi = null;
	}

	onGetDataPhieuThu(data:any) {
		let cashbook = [...this.cashbook];
		this.dataPhieuThu = data;
		if (this.isNewCashBook) {
			cashbook.push(this.dataPhieuThu);
		} else {
			cashbook[this.cashbook.indexOf(this.selectedCashbook)] = this.dataPhieuThu;
		}
		this.cashbook = cashbook;
		this.dataPhieuThu = null;
	}
	onShowDialogPhieuThu() {
		this.isShowDialogPhieuThu = true;
		this.isNewCashBook = true;
	}

	onGetIsShowDialogPhieuThu(data: any) {
		this.isShowDialogPhieuThu = data;
	}

	onRowSelect(event: any) {
		let PC = 'PC';
		let kieuMaPhieu = event.data['maPhieu'];
		let isPC = kieuMaPhieu.includes(PC);
		this.isNewCashBook = false;
		this.idSelectedCashbook = event.data.id;
		this.cashbookTemp = this.cloneCashbook(event.data);
		// item['hoTen'].toLowerCase().includes(this.keyword)
		if (isPC) {
			this.isShowDialogPhieuChi = true;
			this.myFormChiChild.dataPhieuChi = this.cashbookTemp;
		} else {
			this.isShowDialogPhieuThu = true;
			this.myFormThuChild.dataPhieuThu = this.cashbookTemp;
		}
		this.cashbookTemp = null;
		//if else ngay đây, lấy 2 kí tự đầu PT or PC để show popup, và gán dataPhieuChi or dataPHieuThu
	}

	// call in onSelectRow to through obj
	cloneCashbook(cashbook: any) {
		const cashbookToUpdate = {};
		// tslint:disable-next-line:forin
		for (const prop in cashbook) {
			cashbookToUpdate[prop] = cashbook[prop];
		}
		return cashbookToUpdate;
	}
}
