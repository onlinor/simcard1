import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { FormphieuchiComponent } from '../../public/formphieuchi/formphieuchi.component';
import { FormphieuthuComponent } from '../../public/formphieuthu/formphieuthu.component';
import { Subscription } from 'rxjs/subscription';
import { CashbookService } from '../../core/services/cashbook.service';

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
		//{ field: 'congDon', header: 'Cộng Dồn'}
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
	cashbook: any = [];
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
				// this.initialCustomer = response;
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
			if (checkHTChi === 'TM,CK') {
				this.myFormChiChild.theATM = true;
			} else {
				this.myFormChiChild.theATM = false;
			}
			this.myFormChiChild.dataPhieuChi = this.cashbookTemp;
		} else {
			this.isShowDialogPhieuThu = true;
			let checkHTThu = '';
			if(this.cashbookTemp['hinhThucNop']) {
				checkHTThu = this.cashbookTemp['hinhThucNop'];
			}
			if (checkHTThu === 'TM,CK' ) {
				this.myFormThuChild.theATM = true;
			} else {
				this.myFormThuChild.theATM = false;
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

	ngOnDestroy() {
		if (this.subscription) {
			this.subscription.unsubscribe();
		}
	}
}
