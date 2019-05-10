import {
	Component,
	OnInit,
	Input,
	Output,
	EventEmitter,
	OnDestroy
} from '@angular/core';
import { Subscription } from 'rxjs/subscription';
import { BankbookService } from '../../core/services/bankbook.service';
import { CashbookService } from '../../core/services/cashbook.service';
import { DebtbookService } from '../../core/services/debtbook.service';

@Component({
  selector: 'app-formphieuchibankbook',
  templateUrl: './formphieuchibankbook.component.html',
  styleUrls: ['./formphieuchibankbook.component.css']
})
export class FormphieuchibankbookComponent implements OnInit, OnDestroy {
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
		donViNhan: 'Cong Ty',
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
	customerList: any;
	countPC: number = 0;
	debtbookData: any = [];

	@Input('isShowDialogPhieuChi') isShowDialogPhieuChi: boolean;
	@Input('isNewCashBook') isNewCashBook: boolean;
	@Input('idSelectedBankbook') idSelectedBankbook;
	@Output('outIsShowDialogPhieuChi') emitShowDialogPhieuChi = new EventEmitter<any>();
	@Output('outDataPhieuChi') emitDataPhieuChi = new EventEmitter<any>();

	constructor(private bankbookService: BankbookService,
			private cashbookService: CashbookService,
			private debtbookService: DebtbookService) { }

	ngOnInit() { }

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

	addDebtbook() {
		var STT = 0;
		this.subscription = this.debtbookService.getAllDebtbook()
			.subscribe(
				response => {
					this.debtbookData = response;
					STT = this.debtbookData.length;
				},
				error => {}
			)
			debugger;
		var debtbookData = {
			STT: STT,
			dateCreated: this.dataPhieuChi.ngayLap,
			tenKhachHang: this.dataPhieuChi.tenKhachHang,
			maKhachHang: this.dataPhieuChi.maKhachHang,
			soPhieu: this.dataPhieuChi.maPhieu,
			noiDungPhieu: this.dataPhieuChi.noiDungPhieu,
			noKhach: this.dataPhieuChi.soTienThu,
			khachNo: 0,
			congDon: 0
		}

		this.subscription = this.debtbookService.addDebtbook(debtbookData)
			.subscribe (
				response => {
					console.log('success');
				}, error => {}
			)
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
				this.subscription = this.bankbookService.updateBankbook(this.idSelectedBankbook, this.dataPhieuChi)
					.subscribe(() => {
						this.emitDataPhieuChi.emit({ ...this.dataPhieuChi });
						}, error => {} 
				);
			}
			if(this.isCash) {
				this.subscription = this.cashbookService.updateCashbook(this.idSelectedBankbook, this.dataPhieuChi)
					.subscribe(() => {
						this.emitDataPhieuChi.emit({ ...this.dataPhieuChi });
					}, error => {
						}
					);
			}
		}
		var tenKH = this.dataPhieuChi.tenKhachHang;
		var tenkhChecked = this.dsKhachHang.some((item) =>  item['value'] === tenKH);
		if(tenkhChecked && this.dataPhieuChi.loaiPhanBo === 'NO') {
			this.addDebtbook();
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
