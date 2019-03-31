import { Component, OnInit, ViewChild } from '@angular/core';

import { FormphieuthuComponent } from '../../public/formphieuthu/formphieuthu.component';
import {
  Product,
  ExportReceipt,
  Customer,
  Shop
} from '../../core/models';
import { PhieuxuatService, ProductService, ShopService } from '../../core/services';

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

	shopList: Array<Shop> = [];

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
		private phieuxuatSerivce: PhieuxuatService,
		private shopService: ShopService

	) { }

	ngOnInit() {
		this.getAllProducts();
		this.getAllShops();
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

	onDropdownValueChange(event: any) {
		this.exportReceipt.shopId = event.value.id;
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
			} else {
				selectedProduct.soLuong += event.data.exportnumber;
				selectedProduct.thanhTien = selectedProduct.donGia * selectedProduct.soLuong;
			}
		}
		this.updateTotalMoney();
	}

	updateTotalMoney() {
		this.totalMoney = 0;
		this.tableProducts.forEach(line => {
			this.totalMoney += line.soLuong * (line.menhGia - line.menhGia * line.chietKhau / 100);
		});
		this.vatMoney = (this.totalMoney * 10) / 100;
		this.total = this.totalMoney + this.vatMoney;
	}

	onProductTableEditCompleted(event: any) {
		const selectedProduct = this.tableProducts.find(
			x => x.ma === event.data.ma);
		selectedProduct.donGia = (selectedProduct.menhGia / 100) * (100 - selectedProduct.chietKhau);
		selectedProduct.thanhTien = selectedProduct.donGia * selectedProduct.soLuong;
		this.updateTotalMoney();
	}

	generateProductCode() {
		this.phieuxuatSerivce.getProductCode().subscribe(resp => {
			this.exportReceipt.ma = resp.ma;
		});
	}

	dataExportProductBinding() {
		this.myFormThuChild.dataPhieuThu.loaiNganHang = this.loaiNganHang;
		this.myFormThuChild.dataPhieuThu.nguoiThu = this.exportReceipt.nhanVienLap;
		this.myFormThuChild.dataPhieuThu.tenKhachHang = this.exportReceipt.nguoiDaiDien;
		this.myFormThuChild.dataPhieuThu.soTienThu = this.thanhToan;
		this.myFormThuChild.theATM = this.isPaybankChecked;
		this.myFormThuChild.cash = this.isPaycashChecked;
		this.myFormThuChild.checkedATM();
		this.myFormThuChild.checkedCash();
		this.myFormThuChild.isNewCashBook = true;
		this.isShowDialogPhieuThu = true;
	}

	// get all customers from db
	getAllShops() {
	this.shopService.getAll().subscribe(
		response => {
		this.shopList = response;
		console.log(response);
		}
	);
	}

	save() {
		this.tableProducts.forEach(p => {
		  p.shopId = 2;
		  p.supplierId = 1;
		});
		this.productService.save(this.tableProducts).subscribe(() => {
		 /*  this.savePhieuxuat();
		  this.dataExportProductBinding(); */
		});
	  }
	
	  savePhieuxuat() {
		this.exportReceipt.prefix = this.exportReceipt.ma.substring(0, 10);
		this.exportReceipt.suffix = Number(this.exportReceipt.ma.substr(11));
		this.exportReceipt.tienThanhToan = this.thanhToan;
		this.exportReceipt.tienConLai = this.total - this.thanhToan;
		this.exportReceipt.products = this.tableProducts;
		// this.exportReceipt.addPhieuxuat(this.exportReceipt).subscribe(() => { });
	  }
}
