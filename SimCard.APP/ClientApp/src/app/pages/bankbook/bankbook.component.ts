import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bankbook',
  templateUrl: './bankbook.component.html',
  styleUrls: ['./bankbook.component.css']
})
export class BankbookComponent implements OnInit {
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
        { field: 'stt', header: 'STT' },
        { fleld: 'ngayLap', header: 'Ngày Lập'},
        { field: 'tenKhachHang', header: 'Tên Khách Hàng'},
        { field: 'maPhieu', header: 'Mã Phiếu'},
        { field: 'noidungPhieu', header: 'Nội Dung Phiếu'},
        { field: 'sotienThu', header: 'Số Tiền Thu'},
        { field: 'sotienChi', header: 'Số Tiền Chi'},
        { field: 'congDon', header: 'Cộng Dồn'}
    ];
	tuNgay: any;
	toiNgay: any;
	tonDauKi: any;
    tonCuoiKi: any;
    soTienThu: any;
	soTienChi: any;
	bankBook: any = [];
    selectedBankbook: any;
	isShowDialogPhieuChi: boolean = false;
	isShowDialogPhieuThu: boolean = false;
	constructor() {}

	ngOnInit() {}
	
	onShowDialogPhieuChi() {
		this.isShowDialogPhieuChi = true;
	}

	onGetIsShowDialogPhieuChi(data: any) {
		this.isShowDialogPhieuChi = data;
	}

	onShowDialogPhieuThu() {
		this.isShowDialogPhieuThu = true;
	}

	onGetIsShowDialogPhieuThu(data: any) {
		this.isShowDialogPhieuThu = data;
	}

	onGetDataPhieuChi(data: any) {

	}

	onRowSelect(data: any) {

    }
}
