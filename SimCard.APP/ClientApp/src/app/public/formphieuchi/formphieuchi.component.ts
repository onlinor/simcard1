import {
  Component,
  OnInit,
  Input,
  Output,
  EventEmitter,
  OnDestroy
} from '@angular/core';
import { Subscription } from 'rxjs';
import { CashbookService } from '../../core/services/cashbook.service';
import { BankbookService } from '../../core/services/bankbook.service';
import { DebtbookService } from '../../core/services/debtbook.service';

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
		maPhanBo: '',
		tenKhachHang: '',
		donViNhan: 'Công Ty',
		donViNop: '',
		maKhachHang: '',
		ghiChu: '',
		hinhThucChi: '',
		hinhThucNop: '',
		maPhieu: 'PC',
		nguoiChi: '',
		nguoiThu: '',
		ngayLap: new Date().toLocaleDateString(),
		dateCreated: new Date().toLocaleDateString(),
		noiDungPhieu: 'Nhập hàng từ nhà cung cấp',
		soTienChi: 0,
		soTienThu: 0,
		congDon: 0
	};

	isATM: boolean = false;
	payByBank: number = 0;
	isCash: boolean = false;
	payByCash: number = 0;
	dsKhachHang: any = [];
	subscription: Subscription;
	dataPhieuChiArray: any;
	countPhieuChiArray = [];
	customerList: any;
	countPC: number;
	debtbookData: any;
	debtbookParams: any = {
		stt: 0,
		tenKhachHang: '',
		maKhachHang: '',
		soPhieu:'',
		noiDungPhieu: '',
		noKhach: 0,
		khachNo: 0,
		congDon: 0
	};

	@Input('isShowDialogPhieuChi') isShowDialogPhieuChi: boolean;
	@Input('isNewCashBook') isNewCashBook: boolean;
	@Input('idSelectedCashbook') idSelectedCashbook;
	@Output('outIsShowDialogPhieuChi') emitShowDialogPhieuChi = new EventEmitter<any>();
	@Output('outDataPhieuChi') emitDataPhieuChi = new EventEmitter<any>();

	constructor(
		private cashbookService: CashbookService, 
		private bankbookService: BankbookService,
		private debtbookService: DebtbookService) {
	}

	ngOnInit() {
		this.getAllDebtbook();
	}

	onChangePaybank() {
		this.dataPhieuChi.soTienChi = this.payByBank + this.payByCash;
	}

	onChangePayCash() {
		this.dataPhieuChi.soTienChi = this.payByBank + this.payByCash;
	}

	checkedATM() {
		if (this.isATM) {
			this.dataPhieuChi.hinhThucChi = 'CK';
		}
		if (!this.isATM) {
			this.dataPhieuChi.hinhThucChi = '';
			this.dataPhieuChi.soTienChi = this.dataPhieuChi.soTienChi - this.payByBank;
			this.payByBank = 0;
			this.dataPhieuChi.loaiNganHang = '';
		}
		if (this.isATM && this.isCash) {
			this.dataPhieuChi.hinhThucChi = 'CK,TM';
		}
		if (!this.isATM && this.isCash) {
			this.dataPhieuChi.hinhThucChi = 'TM';
		}
	}

	checkedCash() {
		if (this.isCash) {
			this.dataPhieuChi.hinhThucChi = 'TM';
		}
		if (!this.isCash) {
			this.dataPhieuChi.hinhThucChi = '';
			this.dataPhieuChi.soTienChi = this.dataPhieuChi.soTienChi - this.payByCash;
			this.payByCash = 0;
		}
		if (this.isCash && this.isATM) {
			this.dataPhieuChi.hinhThucChi = 'CK,TM';
		}
		if (!this.isCash && this.isATM) {
			this.dataPhieuChi.hinhThucChi = 'CK';
		}
	}
	
	setMaPhieuPayATM() {
		if (this.dataPhieuChi.loaiNganHang === 'default' || !this.dataPhieuChi.loaiNganHang) {
			this.dataPhieuChi.loaiNganHang = 'VCB';
		}
		let ngayTao = new Date();
		let date = ngayTao.getDate();
		let month = ngayTao.getMonth() + 1;
		let year = ngayTao.getFullYear();
		let maPhieu = 'PC' + year + month + date  + '.' + this.countPC + '/' + this.dataPhieuChi.loaiNganHang;
		this.dataPhieuChi.maPhieu = maPhieu;
	}

	setMaPhieuPayCash() {
		let ngayTao = new Date();
		let date = ngayTao.getDate();
		let month = ngayTao.getMonth() + 1;
		let year = ngayTao.getFullYear();
		let maPhieu = 'PC' + year + month + date  + '.' + this.countPC;
		this.dataPhieuChi.maPhieu = maPhieu;
	}

	getAllDebtbook() {
		this.subscription = this.debtbookService.getAllDebtbook()
			.subscribe(
				response => {
					this.debtbookData = response;
					this.debtbookParams.stt = this.debtbookData.length;
				},
				error => {}
			)
	}

	callApiAddDebtbook(debtbookParams: any) {
		this.subscription = this.debtbookService.addDebtbook(debtbookParams)
			.subscribe (
				response => {
					console.log('success debt');
				}, error => {
					console.log('eorr', error);
				}
			)
	}
	
	initialDebtbookData() {
		this.debtbookParams.tenKhachHang= this.dataPhieuChi.tenKhachHang;
		this.debtbookParams.maKhachHang= this.dataPhieuChi.maKhachHang;
		this.debtbookParams.soPhieu= this.dataPhieuChi.maPhieu;
		this.debtbookParams.noiDungPhieu= this.dataPhieuChi.noiDungPhieu;
		this.debtbookParams.noKhach= this.dataPhieuChi.soTienChi;
		this.debtbookParams.khachNo= 0;
		this.debtbookParams.congDon= 0;
	}

	onSubmit() {
		this.isShowDialogPhieuChi = false;
		this.dataPhieuChi.dateCreated = new Date();
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
		if (this.isNewCashBook) {
			if(this.isATM) {
				this.setMaPhieuPayATM();
				this.dataPhieuChi.soTienChi = this.payByBank;
				this.subscription = this.bankbookService.addBankbook(this.dataPhieuChi)
					.subscribe(() => {
						this.emitDataPhieuChi.emit({ ...this.dataPhieuChi });
					}, error => {
						
					})
			}
			if(this.isCash) {
				this.setMaPhieuPayCash();
				this.dataPhieuChi.soTienChi = this.payByCash;
				this.subscription = this.cashbookService.addCashbook(this.dataPhieuChi)
					.subscribe(() => {
						this.emitDataPhieuChi.emit({ ...this.dataPhieuChi });
					}, error => {
					}
				);
			}
		} else {
			if(this.isATM) {
				this.subscription = this.bankbookService.updateBankbook(this.idSelectedCashbook, this.dataPhieuChi)
					.subscribe(() => {
						this.emitDataPhieuChi.emit({ ...this.dataPhieuChi });
						}, error => {} 
				);
			}
			if(this.isCash) {
				this.subscription = this.cashbookService.updateCashbook(this.idSelectedCashbook, this.dataPhieuChi)
					.subscribe(() => {
						this.emitDataPhieuChi.emit({ ...this.dataPhieuChi });
					}, error => {
						}
					);
			}
		}
		var tenKH = this.dataPhieuChi.tenKhachHang;
		var tenkhChecked = this.dsKhachHang.some((item) =>  item['value'] === tenKH);
		if(tenkhChecked && this.dataPhieuChi.maPhanBo === 'NO') {
			this.initialDebtbookData();
			this.callApiAddDebtbook(this.debtbookParams);
		}
		this.resetForm();
		this.isATM = false;
		this.isCash = false;
	}
	
	resetForm() {
		this.dataPhieuChi = {};
		this.dataPhieuChi.loaiNganHang = '';
		this.dataPhieuChi.maPhieu = 'PC';
		this.dataPhieuChi.donViNhan = 'Công Ty',
		this.dataPhieuChi.noiDungPhieu =  'Nhập hàng từ nhà cung cấp',
		this.dataPhieuChi.hinhThucChi = '';
		this.dataPhieuChi.soTienChi = 0;
		this.payByCash = 0;
		this.payByBank = 0;
		this.dataPhieuChi.dateCreated = new Date().toLocaleDateString();
		this.dataPhieuChi.ngayLap = new Date().toLocaleDateString();
		this.dsKhachHang = [];
	}

	onClose() {
		this.resetForm();
		this.isATM = false;
		this.isCash = false;
		this.isShowDialogPhieuChi = false;
		this.emitShowDialogPhieuChi.emit(this.isShowDialogPhieuChi);
	}

	onClearForm() {
		this.resetForm();
		this.isATM = false;
		this.isCash = false;
	}

	onChangeNguoiNopTien() {
		var maKH = 'KH0';
		var tenKH = this.dataPhieuChi.tenKhachHang;
		var dataKH = this.dsKhachHang.find(item => item['value'] === tenKH);
		if(dataKH) {
			maKH = dataKH['maKH'];
		}
		this.dataPhieuChi.maKhachHang = maKH;
	}

	fillDropdownCustomer() {
		this.customerList.map((item) => {
			let obj = {
				label: item.hoTen, 
				value: item.hoTen,
				maKH: item.maKH
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
