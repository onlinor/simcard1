import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";
import { CashbookService } from "../../core/services/cashbook.service";
import { BankbookService } from "../../core/services/bankbook.service";
import { DebtbookService } from "../../core/services/debtbook.service";

@Component({
  selector: 'app-formphieuthu',
  templateUrl: './formphieuthu.component.html',
  styleUrls: ['./formphieuthu.component.css']
})
export class FormphieuthuComponent implements OnInit, OnDestroy {
	LoaiNganHang = [
		{ label: 'Chon', value: 'default'},
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

	dataPhieuThu: any = {
		loaiNganHang: '',
		maPhanBo: '',
		tenKhachHang: '',
		donViNhan: '',
		donViNop: '',
		maKhachHang: '',
		ghiChu: '',
		hinhThucChi: '',
		hinhThucNop: '',
		maPhieu: 'PT',
		nguoiChi: '',
		nguoiThu: '',
		ngayLap: new Date().toLocaleDateString(),
		dateCreated: new Date().toLocaleDateString(),
		noiDungPhieu: '',
		soTienChi: 0,
		soTienThu: 0,
		congDon: 0,
		shopId: 0
	};
	isATM: boolean = false;
	payByBank: number = 0;
	isCash: boolean = false;
	payByCash: number = 0;
	dsKhachHang: any = [];
	subscription: Subscription;
	dataPhieuThuArray: any;
	customerList: any;
	countPT: number = 0;
	debtbookData: any = [];

	@Input("isShowDialogPhieuThu") isShowDialogPhieuThu: boolean;
	@Input("isNewCashBook") isNewCashBook: boolean;
	@Input("idSelectedCashbook") idSelectedCashbook;
	@Output("outIsShowDialogPhieuThu") emitShowDialogPhieuThu = new EventEmitter<any>();
	@Output("outDataPhieuThu") emitDataPhieuThu = new EventEmitter<any>();

	constructor(private cashbookService: CashbookService,
					private bankbookService: BankbookService,
					private debtbookService: DebtbookService) {
	}

	ngOnInit() {
	}

	onChangePaybank() {
		this.dataPhieuThu.soTienThu = this.payByBank + this.payByCash;
	}

	onChangePayCash() {
		this.dataPhieuThu.soTienThu = this.payByBank + this.payByCash;
	}

	checkedATM() {
		if (this.isATM) {
			this.dataPhieuThu.hinhThucNop = 'CK';
		}
		if (!this.isATM) {
			this.dataPhieuThu.hinhThucNop = '';
			this.dataPhieuThu.soTienThu = this.dataPhieuThu.soTienThu - this.payByBank;
			this.payByBank = 0;
			this.dataPhieuThu.loaiNganHang = '';
		}
		if (this.isATM && this.isCash) {
			this.dataPhieuThu.hinhThucNop = 'CK,TM';
		}
		if (!this.isATM && this.isCash) {
			this.dataPhieuThu.hinhThucNop = 'TM';
		}
	}

	checkedCash() {
		if (this.isCash) {
			this.dataPhieuThu.hinhThucNop = 'TM';
		}
		if (!this.isCash) {
			this.dataPhieuThu.hinhThucNop = '';
			this.dataPhieuThu.soTienThu = this.dataPhieuThu.soTienThu - this.payByCash;
			this.payByCash = 0;
		}
		if (this.isCash && this.isATM) {
			this.dataPhieuThu.hinhThucNop = 'CK,TM';
		}
		if (!this.isCash && this.isATM) {
			this.dataPhieuThu.hinhThucNop = 'CK';
		}
	}

	setMaPhieuPayATM() {
		if (this.dataPhieuThu.loaiNganHang === 'default' || !this.dataPhieuThu.loaiNganHang) {
			this.dataPhieuThu.loaiNganHang = 'VCB';
		}
		let ngayTao = new Date();
		let date = ngayTao.getDate();
		let month = ngayTao.getMonth() + 1;
		let year = ngayTao.getFullYear();
		let maPhieu = 'PT' + year + month + date  + '.' + this.countPT + '/' + this.dataPhieuThu.loaiNganHang;
		this.dataPhieuThu.maPhieu = maPhieu;
		
	}
	setMaPhieuPayCash() {
		let ngayTao = new Date();
		let date = ngayTao.getDate();
		let month = ngayTao.getMonth() + 1;
		let year = ngayTao.getFullYear();
		let maPhieu = 'PT' + year + month + date  + '.' + this.countPT;
		this.dataPhieuThu.maPhieu = maPhieu;
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
		var debtbookData = {
			STT: STT,
			dateCreated: this.dataPhieuThu.ngayLap,
			tenKhachHang: this.dataPhieuThu.tenKhachHang,
			maKhachHang: this.dataPhieuThu.maKhachHang,
			soPhieu: this.dataPhieuThu.maPhieu,
			noiDungPhieu: this.dataPhieuThu.noiDungPhieu,
			noKhach: this.dataPhieuThu.soTienThu,
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
		this.isShowDialogPhieuThu = false;
		this.dataPhieuThu.dateCreated = new Date();
		this.emitShowDialogPhieuThu.emit(this.isShowDialogPhieuThu);
		if (this.isNewCashBook) {
			if(this.isATM) {
				this.setMaPhieuPayATM();
				this.dataPhieuThu.soTienThu = this.payByBank;
				this.subscription = this.bankbookService.addBankbook(this.dataPhieuThu)
					.subscribe(() => {
						this.emitDataPhieuThu.emit({ ...this.dataPhieuThu });
					}, error => {
						
					})
			}
			if(this.isCash) {
				this.setMaPhieuPayCash();
				this.dataPhieuThu.soTienThu = this.payByCash;
				this.subscription = this.cashbookService.addCashbook(this.dataPhieuThu)
					.subscribe(() => {
						this.emitDataPhieuThu.emit({ ...this.dataPhieuThu });
					}, error => {
						}
					);
			}
		} else {
			if(this.isATM) {
				this.subscription = this.bankbookService.updateBankbook(this.idSelectedCashbook, this.dataPhieuThu)
					.subscribe(() => {
						this.emitDataPhieuThu.emit({ ...this.dataPhieuThu });
						}, error => {} 
				);
			}
			if(this.isCash) {
				this.subscription = this.cashbookService.updateCashbook(this.idSelectedCashbook, this.dataPhieuThu)
					.subscribe(() => {
						this.emitDataPhieuThu.emit({ ...this.dataPhieuThu });
					}, error => {
						}
					);
			}
		}
		var tenKH = this.dataPhieuThu.tenKhachHang;
		var tenkhChecked = this.dsKhachHang.some((item) =>  item['value'] === tenKH);
		if(tenkhChecked && this.dataPhieuThu.maPhanBo === 'NO') {
			this.addDebtbook();
		}
		this.resetForm();
		this.isATM = false;
		this.isCash = false;
	}
	
	resetForm() {
		this.dataPhieuThu = {};
		this.dataPhieuThu.loaiNganHang = '';
		this.dataPhieuThu.maPhieu = 'PT'
		this.dataPhieuThu.hinhThucNop = '';
		this.dataPhieuThu.soTienThu = 0;
		this.payByCash = 0;
		this.payByBank = 0;
		this.dataPhieuThu.ngayLap = new Date().toLocaleDateString();
		this.dataPhieuThu.dateCreated = new Date().toLocaleDateString();
		this.dsKhachHang = [];
	}

	onClose() {
		this.resetForm();
		this.isATM = false;
		this.isCash = false;
		this.isShowDialogPhieuThu = false;
		this.emitShowDialogPhieuThu.emit(this.isShowDialogPhieuThu);
	}

	onClearForm() {
		this.resetForm();
		this.isATM = false;
		this.isCash = false;
	}

	onChangeNguoiNopTien() {
		var maKH = 'KH0';
		var tenKH = this.dataPhieuThu.tenKhachHang;
		var dataKH = this.dsKhachHang.find(item => item['value'] === tenKH);
		if(dataKH) {
			maKH = dataKH['maKH'];
		}
		this.dataPhieuThu.maKhachHang = maKH;
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
