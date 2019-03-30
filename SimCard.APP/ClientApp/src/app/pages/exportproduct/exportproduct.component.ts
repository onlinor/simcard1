import { Component, OnInit, ViewChild } from '@angular/core';

import { FormphieuthuComponent } from '../../public/formphieuthu/formphieuthu.component';
import {
  Product,
  Supplier,
  ProductExport,
  ExportType,
  Bank,
  ExportReceipt,
  Customer
} from '../../core/models';
import { PhieuxuatService, ProductService, CustomerService } from '../../core/services';

@Component({
	selector: 'app-exportproduct',
	templateUrl: './exportproduct.component.html',
	styleUrls: ['./exportproduct.component.css']
})
export class ExportProductComponent implements OnInit {
	@ViewChild(FormphieuthuComponent)
	myFormThuChild: FormphieuthuComponent;
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
	loaiNganHang: String = '';

	tabviewProducts: Array<Product> = [];

	tableProducts: Array<Product> = [];

	exportReceipt: ExportReceipt = new ExportReceipt();

	totalMoney = 0;

	vatMoney = 0;

	total = 0;

	thanhToan = 0;

	payBank = 0;
	isPaybankChecked = false;

	payCash = 0;
	isPaycashChecked = false;

	isShowDialogPhieuThu: boolean = false;

	constructor(
		private productService: ProductService,
		private phieuxuatSerivce: PhieuxuatService
	) { }

	ngOnInit() {
		this.getAllProducts();
	}

	onChangePaybank() {
		this.thanhToan = this.payBank + this.payCash;
	}

	onChangePaycash() {
		this.thanhToan = this.payBank + this.payCash;
	}

	onGetIsShowDialogPhieuThu(data: any) {
		this.isShowDialogPhieuThu = data;
	}

	getAllProducts() {
		this.productService.getAll().subscribe(response => {
			this.tabviewProducts = response;
		});
	}

	rowEditCompleted(event: any) {
		if (event.data.soluongnhap === 0 || event.data.soluongnhap === null) {
			// I will do something later :)
		} else {
			const selectedProduct = this.tableProducts.find(
				x => x.ma === event.data.ma
			);
			if (!selectedProduct) {
				const newProduct: Product = {
					id: event.data.id,
					ma: event.data.ma,
					ten: event.data.ten,
					soLuong: event.data.exportnumber,
					menhGia: event.data.menhgia,
					chietKhau: (event.data.menhgia - event.data.donGia) * 100 / event.data.menhgia,
					donGia: event.data.donGia,
					thanhTien: event.data.exportnumber * event.data.donGia
				};
				this.tableProducts.push(newProduct);
			}
			selectedProduct.soLuong += event.data.exportnumber;
			selectedProduct.thanhTien = selectedProduct.donGia * selectedProduct.soLuong;
		}
	}

	onProductTableEditCompleted(event: any) {
		const selectedProduct = this.tableProducts.find(
			x => x.ma === event.data.ma);
		selectedProduct.donGia = (selectedProduct.menhGia / 100) * (100 - selectedProduct.chietKhau);
		selectedProduct.thanhTien = selectedProduct.donGia * selectedProduct.soLuong;
	}

	generateProductCode() {
		this.phieuxuatSerivce.getProductCode().subscribe(resp => {
			this.exportReceipt.ma = resp.ma;
		});
	}

	dataExportProductBinding() {
		this.myFormThuChild.dataPhieuThu.loaiNganHang = this.loaiNganHang;
		//this.myFormThuChild.dataPhieuThu.nguoiThu = this.importReceipt.nhanVienLap,
		//this.myFormThuChild.dataPhieuThu.tenKhachHang = this.importReceipt.nguoiDaiDien,
		this.myFormThuChild.dataPhieuThu.soTienThu = this.thanhToan,
		this.myFormThuChild.theATM = this.isPaybankChecked,
		this.myFormThuChild.cash = this.isPaycashChecked
		this.myFormThuChild.checkedATM();
		this.myFormThuChild.checkedCash();
		this.myFormThuChild.isNewCashBook = true;
		this.isShowDialogPhieuThu = true;
	}
}
