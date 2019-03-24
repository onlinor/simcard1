import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { FormphieuchiComponent } from '../../public/formphieuchi/formphieuchi.component';
import { FormphieuthuComponent } from '../../public/formphieuthu/formphieuthu.component';
import { Subscription } from 'rxjs/subscription';
import { CashbookService } from '../../core/services/cashbook.service';
import { Customer } from './../../core/models/customer.model';

@Component({
	selector: 'app-cashbook',
	templateUrl: './cashbook.component.html',
	styleUrls: ['./cashbook.component.css']
})
export class CashbookComponent implements OnInit, OnDestroy {
	@ViewChild(FormphieuchiComponent)
	myFormChiChild: FormphieuchiComponent;
	@ViewChild(FormphieuthuComponent)
	myFormThuChild: FormphieuthuComponent;
	selectedDonVi: String = '';
	LoaiDonVi = [
		{ label: 'Shop 1', value: 'CN1' },
		{ label: 'Shop 2', value: 'CN2' },
		{ label: 'Shop 3', value: 'CN3' },
		{ label: 'Shop 4', value: 'CN4' }
	];
	selectedLoaiDuLieu: String = '';
	LoaiDuLieu = [
		{ label: 'PDF', value: 'PDF' },
		{ label: 'Image', value: 'IMG' }
	];

	cols: any = [
		{ fleld: 'dateCreated', header: 'Ngày Lập' },
		{ field: 'tenKhachHang', header: 'Tên Khách Hàng' },
		{ field: 'maPhieu', header: 'Mã Phiếu' },
		{ field: 'noiDungPhieu', header: 'Nội Dung Phiếu' },
		{ field: 'soTienThu', header: 'Số Tiền Thu' },
		{ field: 'soTienChi', header: 'Số Tiền Chi' }
		// { field: 'congDon', header: 'Cộng Dồn'}
	];

	tuNgay: any;
	toiNgay: any;
	tonDauKi: any;
	tonCuoiKi: any;
	soTienThu: any;
	soTienChi: any;
	searchSoTienThu: number = 0;
	searchSoTienChi: number = 0;
	isShowDialogPhieuChi: boolean = false;
	isShowDialogPhieuThu: boolean = false;
	cashbook: any = [];
	initialCashbook: any = [];
	selectedCashbook: any;
	dataPhieuChi: any;
	dataPhieuThu: any;
	isNewCashBook: boolean;
	idSelectedCashbook: any;
	cashbookTemp: any;
	recieveCashbook: any;
	subscription: Subscription;

	constructor(private cashbookService: CashbookService) { }

	ngOnInit() { 
		this.getAllCashbook();
	}

	// get all customers from db
	getAllCashbook() {
		this.subscription = this.cashbookService.getAllCashbook().subscribe(
			response => {
				this.cashbook = response;
				this.initialCashbook = response;
			},
			error => {}
		);
	}

	onShowDialogPhieuChi() {
		this.isShowDialogPhieuChi = true;
		this.isNewCashBook = true;
	}

	onGetIsShowDialogPhieuChi(data: any) {
		this.isShowDialogPhieuChi = data;
	}

	onGetDataPhieuChi(data: any) {
		this.getAllCashbook();
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

	onGetDataPhieuThu(data: any) {
		this.getAllCashbook();
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
		this.cashbookTemp = this.cloneCashbook(event.data);
		this.idSelectedCashbook = event.data.id;
		if (isPC) {
			this.isShowDialogPhieuChi = true;
			let checkHTChi = '';
			if(this.cashbookTemp['hinhThucChi']) {
				checkHTChi = this.cashbookTemp['hinhThucChi'];
			}
			if(checkHTChi === 'TM') {
				this.myFormChiChild.cash = true;
				this.myFormChiChild.theATM = false;
			}
			if (checkHTChi === 'CK,TM') {
				this.myFormChiChild.theATM = true;
				this.myFormChiChild.cash = true;
			} 
			if(checkHTChi === 'CK') {
				this.myFormChiChild.cash = false;
				this.myFormChiChild.theATM = true;
			} 
			if(checkHTChi === '' ) {
				this.myFormChiChild.cash = false;
				this.myFormChiChild.theATM = false;
			}
			this.myFormChiChild.dataPhieuChi = this.cashbookTemp;
		} else {
			this.isShowDialogPhieuThu = true;
			let checkHTThu = '';
			if(this.cashbookTemp['hinhThucNop']) {
				checkHTThu = this.cashbookTemp['hinhThucNop'];
			}
			if(checkHTThu === 'TM') {
				this.myFormThuChild.theATM = false;
				this.myFormThuChild.cash = true;
			}
			if (checkHTThu === 'CK,TM' ) {
				this.myFormThuChild.theATM = true;
				this.myFormThuChild.cash = true;
			} 
			if(checkHTThu === 'CK') {
				this.myFormThuChild.theATM = true;
				this.myFormThuChild.cash = false;
			}
			if(checkHTThu === '' ) {
				this.myFormThuChild.theATM = false;
				this.myFormThuChild.cash = false;
			}
			this.myFormThuChild.dataPhieuThu = this.cashbookTemp;
		}
		this.cashbookTemp = null;
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

	onSearch() {
		let arrayResult = [];
		this.cashbook = this.initialCashbook;
		this.searchSoTienThu = 0;
		this.searchSoTienChi = 0;
		let tuNgay = new Date(this.tuNgay);
		let toiNgay = new Date(this.toiNgay);
		if (!tuNgay || !toiNgay) {
			return this.cashbook;
		} else {
			for (const item of this.cashbook) {
				let ngayLap = new Date(item.ngayLap);
				if(tuNgay <= ngayLap && ngayLap < toiNgay) {
					arrayResult.push(item);
					this.searchSoTienChi = this.searchSoTienChi + item.soTienChi;
					this.searchSoTienThu = this.searchSoTienThu + item.soTienThu;
				}
				this.cashbook = arrayResult;
			}
		}
	}

	ngOnDestroy() {
		if (this.subscription) {
			this.subscription.unsubscribe();
		}
	}
}
