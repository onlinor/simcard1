import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { FormphieuchibankbookComponent } from '../../public/formphieuchibankbook/formphieuchibankbook.component';
import { FormphieuthubankbookComponent } from '../../public/formphieuthubankbook/formphieuthubankbook.component';
import { Subscription } from 'rxjs/subscription';
import { BankbookService } from '../../core/services/bankbook.service';
import { CustomerService } from '../../core/services/customer.service';

@Component({
	selector: 'app-bankbook',
	templateUrl: './bankbook.component.html',
	styleUrls: ['./bankbook.component.css']
})
export class BankbookComponent implements OnInit, OnDestroy {
	@ViewChild(FormphieuchibankbookComponent)
	myFormChiChild: FormphieuchibankbookComponent;
	@ViewChild(FormphieuthubankbookComponent)
	myFormThuChild: FormphieuthubankbookComponent;
	selectedDonVi: String = '';
	LoaiDonVi = [
		{ label: 'Shop 1', value: 'CN1' },
		{ label: 'Shop 2', value: 'CN2' },
		{ label: 'Shop 3', value: 'CN3' },
		{ label: 'Shop 4', value: 'CN4' }
	];
	selectedNganHang: String = '';
	LoaiNganHang = [
		{ label: 'Vietcombank', value: 'VCB' },
		{ label: 'Agribank', value: 'AGB' },
		{ label: 'Techcombank', value: 'TCB' }
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
	searchSoTienThu: any;
	searchSoTienChi: any;
	isShowDialogPhieuChi: boolean = false;
	isShowDialogPhieuThu: boolean = false;
	bankbook: any = [];
	initialBankbook: any;
	selectedBankbook: any;
	dataPhieuChi: any;
	dataPhieuThu: any;
	isNewCashBook: boolean;
	idSelectedBankbook: any;
	bankbookTemp: any;
	recieveBankbook: any;
	subscription: Subscription;
	customerList: any;

	constructor(private bankbookService: BankbookService,
		private customerService: CustomerService) { }

	ngOnInit() {
		this.getAllBankbook();
		this.subscription = this.customerService.getAllCustomer()
		.subscribe(
			response => {
				this.customerList = response;
			},
			error => {}
		);
	}

	getAllBankbook() {
		this.subscription = this.bankbookService.getAllBankbook()
			.subscribe(
				response => {
					this.bankbook = response;
					this.initialBankbook = response;
				},
				error => { }
			)
	}

	onShowDialogPhieuChi() {
		this.isShowDialogPhieuChi = true;
		this.isNewCashBook = true;
		this.myFormChiChild.customerList = this.customerList;
		this.myFormChiChild.fillDropdownCustomer();
	}

	onGetIsShowDialogPhieuChi(data: any) {
		this.isShowDialogPhieuChi = data;
	}

	onGetDataPhieuChi(data: any) {
		this.getAllBankbook();
		let bankbook = [...this.bankbook];
		this.dataPhieuChi = data;
		if (this.isNewCashBook) {
			bankbook.push(this.dataPhieuChi);
		} else {
			bankbook[this.bankbook.indexOf(this.selectedBankbook)] = this.dataPhieuChi;
		}
		this.bankbook = bankbook;
		this.dataPhieuChi = null;
	}

	onGetDataPhieuThu(data: any) {
		this.getAllBankbook();
		let bankbook = [...this.bankbook];
		this.dataPhieuThu = data;
		if (this.isNewCashBook) {
			bankbook.push(this.dataPhieuThu);
		} else {
			bankbook[this.bankbook.indexOf(this.selectedBankbook)] = this.dataPhieuThu;
		}
		this.bankbook = bankbook;
		this.dataPhieuThu = null;
	}

	onShowDialogPhieuThu() {
		this.isShowDialogPhieuThu = true;
		this.isNewCashBook = true;
		this.myFormThuChild.customerList = this.customerList;
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
		this.bankbookTemp = this.cloneBankbook(event.data);
		this.idSelectedBankbook = event.data.id;
		if (isPC) {
			this.isShowDialogPhieuChi = true;
			let checkHTChi = '';
			if (this.bankbookTemp['hinhThucChi']) {
				checkHTChi = this.bankbookTemp['hinhThucChi'];
			}
			if (checkHTChi === 'TM') {
				this.myFormChiChild.cash = true;
				this.myFormChiChild.theATM = false;
			}
			if (checkHTChi === 'CK,TM') {
				this.myFormChiChild.theATM = true;
				this.myFormChiChild.cash = true;
			}
			if (checkHTChi === 'CK') {
				this.myFormChiChild.cash = false;
				this.myFormChiChild.theATM = true;
			}
			if (checkHTChi === '') {
				this.myFormChiChild.cash = false;
				this.myFormChiChild.theATM = false;
			}
			this.myFormChiChild.dataPhieuChi = this.bankbookTemp;
		} else {
			this.isShowDialogPhieuThu = true;
			let checkHTThu = '';
			if (this.bankbookTemp['hinhThucNop']) {
				checkHTThu = this.bankbookTemp['hinhThucNop'];
			}
			if (checkHTThu === 'TM') {
				this.myFormThuChild.theATM = false;
				this.myFormThuChild.cash = true;
			}
			if (checkHTThu === 'CK,TM') {
				this.myFormThuChild.theATM = true;
				this.myFormThuChild.cash = true;
			}
			if (checkHTThu === 'CK') {
				this.myFormThuChild.theATM = true;
				this.myFormThuChild.cash = false;
			}
			if (checkHTThu === '') {
				this.myFormThuChild.theATM = false;
				this.myFormThuChild.cash = false;
			}
			this.myFormThuChild.dataPhieuThu = this.bankbookTemp;
		}
	}
	// call in onSelectRow to through obj
	cloneBankbook(bankbook: any) {
		const bankbookToUpdate = {};
		// tslint:disable-next-line:forin
		for (const prop in bankbook) {
			bankbookToUpdate[prop] = bankbook[prop];
		}
		return bankbookToUpdate;
	}

	onSearch() {
		let arrayResult = [];
		this.bankbook = this.initialBankbook;
		this.searchSoTienThu = 0;
		this.searchSoTienChi = 0;
		let tuNgay = new Date(this.tuNgay);
		let toiNgay = new Date(this.toiNgay);
		if (!tuNgay || !toiNgay) {
			return this.bankbook;
		} else {
			for (const item of this.bankbook) {
				let ngayLap = new Date(item.ngayLap);
				if (tuNgay <= ngayLap && ngayLap < toiNgay) {
					arrayResult.push(item);
					this.searchSoTienChi = this.searchSoTienChi + item.soTienChi;
					this.searchSoTienThu = this.searchSoTienThu + item.soTienThu;
				}
				this.bankbook = arrayResult;
			}
		}
	}

	ngOnDestroy() {
		if (this.subscription) {
			this.subscription.unsubscribe();
		}
	}
}
