import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { FormphieuchibankbookComponent } from '../../public/formphieuchibankbook/formphieuchibankbook.component';
import { FormphieuthubankbookComponent } from '../../public/formphieuthubankbook/formphieuthubankbook.component';
import { Subscription } from 'rxjs/subscription';
import { BankbookService } from '../../core/services/bankbook.service';

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
        { fleld: 'ngayLap', header: 'Ngày Lập'},
        { field: 'tenKhachHang', header: 'Tên Khách Hàng'},
        { field: 'maPhieu', header: 'Mã Phiếu'},
        { field: 'noiDungPhieu', header: 'Nội Dung Phiếu'},
        { field: 'soTienThu', header: 'Số Tiền Thu'},
        { field: 'soTienChi', header: 'Số Tiền Chi'}
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
    selectedBankbook: any;
	dataPhieuChi: any;
	dataPhieuThu: any;
	isNewCashBook: boolean;
	idSelectedBankbook: any;
	bankbookTemp: any;
	recieveBankbook: any;
	subscription: Subscription;

	constructor(private bankbookService: BankbookService) {}

	ngOnInit() {
		this.getAllBankbook();
	}

	getAllBankbook() {
		this.subscription = this.bankbookService.getAllBankbook()
			.subscribe(
				response => {
					this.bankbook = response;
				},
				error => {}
			)
	}
	
	onShowDialogPhieuChi() {
		this.isShowDialogPhieuChi = true;
		this.isNewCashBook = true;
	}

	onGetIsShowDialogPhieuChi(data: any) {
		this.isShowDialogPhieuChi = data;
	}

	onGetDataPhieuChi(data: any) {
		this.getAllBankbook();
		let bankbook = [...this.bankbook];
		this.dataPhieuChi = data;
		if(this.isNewCashBook) {
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
			if(this.bankbookTemp['hinhThucChi']) {
				checkHTChi = this.bankbookTemp['hinhThucChi'];
			}
			if (checkHTChi === 'TM,CK') {
				this.myFormChiChild.theATM = true;
			} else {
				this.myFormChiChild.theATM = false;
			}
			this.myFormChiChild.dataPhieuChi = this.bankbookTemp;
		} else {
			this.isShowDialogPhieuThu = true;
			let checkHTThu = '';
			if(this.bankbookTemp['hinhThucNop']) {
				checkHTThu = this.bankbookTemp['hinhThucNop'];
			}
			if (checkHTThu === 'TM,CK' ) {
				this.myFormThuChild.theATM = true;
			} else {
				this.myFormThuChild.theATM = false;
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

	ngOnDestroy() {
		if (this.subscription) {
			this.subscription.unsubscribe();
		}
	}
}
