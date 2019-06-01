import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { FormphieuchiComponent } from '../../public/formphieuchi/formphieuchi.component';
import { FormphieuthuComponent } from '../../public/formphieuthu/formphieuthu.component';
import { Subscription } from 'rxjs';
import { CashbookService, CustomerService } from '../../core/services';

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
		{ fleld: 'ngayLap', header: 'Ngày Lập' },
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
	customerList: any;
	countPC: number = 0;
	countPT: number = 0;

	constructor(private cashbookService: CashbookService,
		private customerService: CustomerService) { }

	ngOnInit() { 
		this.getAllCashbook();
		this.subscription = this.customerService.getAllCustomer()
		.subscribe(
			response => {
				this.customerList = response;
			},
			error => {}
		);
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

	countMaPhieuChi() {
		debugger;
		this.cashbook.map(item => {
			let checkMaPhieuChi = item['maPhieu'].includes('PC');
			if(checkMaPhieuChi) {
				this.countPC++;
			}
		})
		this.myFormChiChild.countPC = this.countPC;
	}

	countMaPhieuThu() {
		this.cashbook.map(item => {
			let checkMaPhieuThu = item['maPhieu'].includes('PT');
			if(checkMaPhieuThu) {
				this.countPT ++;
			}
		})
		this.myFormThuChild.countPT = this.countPT;
	}

	onShowDialogPhieuChi() {
		this.isShowDialogPhieuChi = true;
		this.isNewCashBook = true;
		this.myFormChiChild.customerList = this.customerList;
		this.countMaPhieuChi();
		this.myFormChiChild.fillDropdownCustomer();
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
		this.myFormThuChild.customerList = this.customerList;
		this.countMaPhieuThu();
		this.myFormThuChild.fillDropdownCustomer();
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
		console.log('this.caste', this.cashbookTemp);
		this.idSelectedCashbook = event.data.id;
		if (isPC) {
			this.isShowDialogPhieuChi = true;
			let checkHTChi = '';
			if(this.cashbookTemp['hinhThucChi']) {
				checkHTChi = this.cashbookTemp['hinhThucChi'];
			}
			if(checkHTChi === 'TM') {
				this.myFormChiChild.isCash = true;
				this.myFormChiChild.isATM = false;
			}
			if (checkHTChi === 'CK,TM') {
				this.myFormChiChild.isATM = true;
				this.myFormChiChild.isCash = true;
			} 
			if(checkHTChi === 'CK') {
				this.myFormChiChild.isCash = false;
				this.myFormChiChild.isATM = true;
			} 
			if(checkHTChi === '' ) {
				this.myFormChiChild.isCash = false;
				this.myFormChiChild.isATM = false;
			}
			this.myFormChiChild.dataPhieuChi = this.cashbookTemp;
		} else {
			this.isShowDialogPhieuThu = true;
			let checkHTThu = '';
			if(this.cashbookTemp['hinhThucNop']) {
				checkHTThu = this.cashbookTemp['hinhThucNop'];
			}
			if(checkHTThu === 'TM') {
				this.myFormThuChild.isATM = false;
				this.myFormThuChild.isCash = true;
			}
			if (checkHTThu === 'CK,TM' ) {
				this.myFormThuChild.isATM = true;
				this.myFormThuChild.isCash = true;
			} 
			if(checkHTThu === 'CK') {
				this.myFormThuChild.isATM = true;
				this.myFormThuChild.isCash = false;
			}
			if(checkHTThu === '' ) {
				this.myFormThuChild.isATM = false;
				this.myFormThuChild.isCash = false;
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
				let ngayLap = new Date(item.dateCreated);
				if(tuNgay <= ngayLap && ngayLap < toiNgay) {
					arrayResult.push(item);
					this.searchSoTienChi = this.searchSoTienChi + item.soTienChi;
					this.searchSoTienThu = this.searchSoTienThu + item.soTienThu;
				}
			}
			this.cashbook = arrayResult;
		}
	}

	ngOnDestroy() {
		if (this.subscription) {
			this.subscription.unsubscribe();
		}
	}
}
