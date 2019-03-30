import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/subscription';
import { CashbookService } from '../../core/services/cashbook.service';

@Component({
	selector: 'app-formphieuchi',
	templateUrl: './formphieuchi.component.html',
	styleUrls: ['./formphieuchi.component.css']
})
export class FormphieuchiComponent implements OnInit, OnDestroy {
	LoaiNganHang = [
		{ label: 'Chọn', value: 'default' },
		{ label: 'Agribank', value: 'AGB' },
		{ label: 'Vietcombank', value: 'VCB' },
		{ label: 'Viettinbank', value: 'VTB' },
		{ label: 'VPbank', value: 'VPB' },
		{ label: 'Techcombank', value: 'TCB' },
		{ label: 'Shinhanbank', value: 'SHB' },
		{ label: 'Sacombank', value: 'SCB' },
		{ label: 'DongABank', value: 'DAB' },
		{ label: 'AChauBank', value: 'ACB' }
	];

	LoaiPhanBo = [
		{ label: 'Chi Phí', value: 'CP' },
		{ label: 'Thu Chi Khác', value: 'TC' },
		{ label: 'Không', value: 'NO' }
	];

	dataPhieuChi: any = {
		loaiNganHang: '',
		loaiPhanBo: '',
		tenKhachHang: '',
		donViNhan: 'Công Ty',
		donViNop: '',
		maKhachHang: 'KH0',
		ghiChu: '',
		hinhThucChi: '',
		hinhThucNop: '',
		maPhieu: 'PC',
		nguoiChi: '',
		nguoiThu: '',
		ngayLap: new Date().toLocaleDateString(),
		dateCreated: null,
		noiDungPhieu: 'Nhập hàng từ nhà cung cấp',
		soTienChi: 0,
		soTienThu: 0,
		congDon: 0
	};

	theATM: boolean = false;
	cash: boolean = false;
	dsKhachHang: any = [];
	subscription: Subscription;
	dataPhieuChiArray: any;
	countPhieuChiArray = [];
	customerList: any;


	@Input('isShowDialogPhieuChi') isShowDialogPhieuChi: boolean;
	@Input('bindingData') dataProductBingding: any;
	@Input('isNewCashBook') isNewCashBook: boolean;
	@Input('idSelectedCashbook') idSelectedCashbook;
	@Output('outIsShowDialogPhieuChi') emitShowDialogPhieuChi = new EventEmitter<any>();
	@Output('outDataPhieuChi') emitDataPhieuChi = new EventEmitter<any>();

	constructor(
		private cashbookService: CashbookService) {
	}

	ngOnInit() {
	}

	checkedATM() {
		if (this.theATM) {
			this.dataPhieuChi.hinhThucChi = 'CK';
		}
		if (!this.theATM) {
			this.dataPhieuChi.hinhThucChi = '';
		}
		if (this.theATM && this.cash) {
			this.dataPhieuChi.hinhThucChi = 'CK,TM';
		}
		if (!this.theATM && this.cash) {
			this.dataPhieuChi.hinhThucChi = 'TM';
		}
	}

	checkedCash() {
		if (this.cash) {
			this.dataPhieuChi.hinhThucChi = 'TM';
		}
		if (!this.cash) {
			this.dataPhieuChi.hinhThucChi = '';
		}
		if (this.cash && this.theATM) {
			this.dataPhieuChi.hinhThucChi = 'CK,TM';
		}
		if (!this.cash && this.theATM) {
			this.dataPhieuChi.hinhThucChi = 'CK';
		}
	}

	setMaPhieu() {
		let ngayLap = new Date().toLocaleDateString();
		if (this.theATM && this.dataPhieuChi.loaiNganHang !== 'default') {
			this.dataPhieuChi.maPhieu = 'PC' + ngayLap + '/' + this.dataPhieuChi.loaiNganHang;
		} else {
			this.dataPhieuChi.maPhieu = 'PC' + ngayLap;
		}
	}

	onSubmit() {
		this.setMaPhieu();
		this.isShowDialogPhieuChi = false;
		this.dataPhieuChi.dateCreated = new Date();
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
		console.log('sm', this.dataPhieuChi);
		if (this.isNewCashBook) {
			this.subscription = this.cashbookService.addCashbook(this.dataPhieuChi)
				.subscribe(() => {
					this.emitDataPhieuChi.emit({ ...this.dataPhieuChi });
				}, error => {
				}
				);
		} else {
			this.subscription = this.cashbookService.updateCashbook(this.idSelectedCashbook, this.dataPhieuChi)
				.subscribe(() => {
					this.emitDataPhieuChi.emit({ ...this.dataPhieuChi });
				}, error => {
				}
				);
		}
		this.resetForm();
		this.theATM = false;
		this.cash = false;
	}
	
	resetForm() {
		this.dataPhieuChi = {};
		this.dataPhieuChi.loaiNganHang = '';
		this.dataPhieuChi.maPhieu = 'PC';
		this.dataPhieuChi.donViNhan = 'Công Ty',
		this.dataPhieuChi.maKhachHang =  'KH0',
		this.dataPhieuChi.noiDungPhieu =  'Nhập hàng từ nhà cung cấp',
		this.dataPhieuChi.hinhThucChi = '';
		this.dataPhieuChi.soTienChi = 0;
		this.dataPhieuChi.dateCreated = null;
		this.dataPhieuChi.ngayLap = new Date().toLocaleDateString();
	}

	onClose() {
		this.resetForm();
		this.theATM = false;
		this.cash = false;
		this.isShowDialogPhieuChi = false;
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
	}

	onClearForm() {
		this.resetForm();
		this.theATM = false;
		this.cash = false;
	}

	fillDropdownCustomer() {
		this.customerList.map((item) => {
			let obj = {
				label: item.hoTen, 
				value: item.hoTen
			}
			this.dsKhachHang.push(obj);
		});
	}

	ngOnDestroy() {
		if (this.subscription) {
			this.subscription.unsubscribe();
		}
	}
}
