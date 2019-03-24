import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs/subscription";
import { CashbookService } from "../../core/services/cashbook.service";

@Component({
	selector: "app-formphieuthu",
	templateUrl: "./formphieuthu.component.html",
	styleUrls: ["./formphieuthu.component.css"]
})
export class FormphieuthuComponent implements OnInit, OnDestroy {
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

	dataPhieuThu: any = {
		loaiNganHang: '',
		loaiPhanBo: '',
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
		noiDungPhieu: '',
		soTienChi: 0,
		soTienThu: 0,
		congDon: 0
	};
	theATM: boolean = false;
	cash: boolean = false;
	dsKhachHang: any;
	subscription: Subscription;
	dataPhieuThuArray: any;

	@Input("isShowDialogPhieuThu") isShowDialogPhieuThu: boolean;
	@Input("isNewCashBook") isNewCashBook: boolean;
	@Input("idSelectedCashbook") idSelectedCashbook;
	@Output("outIsShowDialogPhieuThu") emitShowDialogPhieuThu = new EventEmitter<any>();
	@Output("outDataPhieuThu") emitDataPhieuThu = new EventEmitter<any>();

	constructor(private cashbookService: CashbookService) {

	}

	ngOnInit() { }

	checkedATM() {
		if (this.theATM) {
			this.dataPhieuThu.hinhThucNop = 'CK';
		}
		if (!this.theATM) {
			this.dataPhieuThu.hinhThucNop = '';
		}
		if (this.theATM && this.cash) {
			this.dataPhieuThu.hinhThucNop = 'CK,TM';
		}
		if (!this.theATM && this.cash) {
			this.dataPhieuThu.hinhThucNop = 'TM';
		}
	}

	checkedCash() {
		if (this.cash) {
			this.dataPhieuThu.hinhThucNop = 'TM';
		}
		if (!this.cash) {
			this.dataPhieuThu.hinhThucNop = '';
		}
		if (this.cash && this.theATM) {
			this.dataPhieuThu.hinhThucNop = 'CK,TM';
		}
		if (!this.cash && this.theATM) {
			this.dataPhieuThu.hinhThucNop = 'CK';
		}
	}

	onSubmit() {
		let ngayLap = new Date().toLocaleDateString();
		if (this.theATM && this.dataPhieuThu.loaiNganHang !== 'default') {
			this.dataPhieuThu.maPhieu = 'PT' + ngayLap + '/' + this.dataPhieuThu.loaiNganHang;
		} else {
			this.dataPhieuThu.maPhieu = 'PT' + ngayLap;
		}
		this.isShowDialogPhieuThu = false;
		this.emitShowDialogPhieuThu.emit(this.isShowDialogPhieuThu);
		if (this.isNewCashBook) {
			this.subscription = this.cashbookService.addCashbook(this.dataPhieuThu)
				.subscribe(() => {
					this.emitDataPhieuThu.emit({ ...this.dataPhieuThu });
				}, error => {
				}
				);
		} else {
			this.subscription = this.cashbookService.updateCashbook(this.idSelectedCashbook, this.dataPhieuThu)
				.subscribe(() => {
					this.emitDataPhieuThu.emit({ ...this.dataPhieuThu });
				}, error => {
				}
				);
		}
		this.dataPhieuThu = {};
		this.dataPhieuThu.loaiNganHang = '';
		this.dataPhieuThu.maPhieu = 'PT'
		this.dataPhieuThu.hinhThucNop = '';
		this.dataPhieuThu.soTienThu = 0;
		this.dataPhieuThu.ngayLap = new Date().toLocaleDateString();
		this.theATM = false;
	}


	onClose() {
		this.dataPhieuThu = {};
		this.dataPhieuThu.dateCreated = new Date().toLocaleDateString();
		this.dataPhieuThu.maPhieu = 'PT';
		this.dataPhieuThu.hinhThucNop = '';
		this.theATM = false;
		this.dataPhieuThu.soTienThu = 0;
		this.isShowDialogPhieuThu = false;
		this.emitShowDialogPhieuThu.emit(this.isShowDialogPhieuThu);
	}

	onClearForm() {
		this.dataPhieuThu = {};
		this.dataPhieuThu.dateCreated = new Date().toLocaleDateString();
		this.dataPhieuThu.maPhieu = 'PT';
		this.dataPhieuThu.hinhThucNop = '';
		this.theATM = false;
		this.dataPhieuThu.soTienThu = 0;
	}

	ngOnDestroy() {
		if (this.subscription) {
			this.subscription.unsubscribe();
		}
	}
}
