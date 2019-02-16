import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-cashbook',
    templateUrl: './cashbook.component.html',
    styleUrls: ['./cashbook.component.css']
})
export class CashbookComponent implements OnInit {
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
    tuNgay: any;
    toiNgay: any;
    tonDauKi: any;
    tonCuoiKi: any;
    soTienThu: any;
    soTienChi: any;
    isShowDialogPhieuChi: boolean = false;
    isShowDialogPhieuThu: boolean = false;
    cols: any = [
        { fleld: 'ngayLap', header: 'Ngày Lập'},
        { field: 'tenKhachHang', header: 'Tên Khách Hàng'},
        { field: 'maPhieu', header: 'Mã Phiếu'},
        { field: 'noidungPhieu', header: 'Nội Dung Phiếu'},
        { field: 'sotienThu', header: 'Số Tiền Thu'},
        { field: 'sotienChi', header: 'Số Tiền Chi'}
        //{ field: 'congDon', header: 'Cộng Dồn'}
    ];
    cashbook: any = [];
    selectedCashbook: any;
    dataPhieuChi: any;
    dataPhieuThu: any;
    isNewCashBook: boolean;
    idSelectedCashbook: any;
    cashbookTemp: any;

    constructor() { }

    ngOnInit() { }

    onShowDialogPhieuChi() {
        this.isShowDialogPhieuChi = true;
        this.isNewCashBook = true;
    }

    onGetIsShowDialogPhieuChi(data: any) {
        this.isShowDialogPhieuChi = data;
    }

    onGetDataPhieuChi(data: any) {
        this.dataPhieuChi = data;
        this.cashbook.push(this.dataPhieuChi);
        console.log('phieuchi', this.dataPhieuChi);
        console.log('cashbook', this.cashbook);
    }

    onShowDialogPhieuThu() {
        this.isShowDialogPhieuThu = true;
    }

    onGetIsShowDialogPhieuThu(data: any) {
        this.isShowDialogPhieuThu = data;
    }
    
    onRowSelect(event: any) {
        this.isShowDialogPhieuChi = true;
        this.isNewCashBook = false;
        this.cashbookTemp = this.cloneCashbook(event.data);
        console.log('temp', this.cashbookTemp);
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
}
