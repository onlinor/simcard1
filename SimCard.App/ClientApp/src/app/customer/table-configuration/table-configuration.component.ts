import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import $ from 'jquery';

declare var $: any;

@Component({
    selector: 'app-table-configuration',
    templateUrl: './table-configuration.component.html',
    styleUrls: ['./table-configuration.component.css']
})
export class TableConfigurationComponent implements OnInit {
    keyName: any;
    // tslint:disable-next-line:no-input-rename
    listColumnTable = {
        maKH: true,
        tenCH: true,
        diachiCH: true,
        hoTen: true,
        sdt1: true,
        sdt2: false,
        ngaySinh: true,
        gioiTinh: true,
        email: false,
        fb: false,
        zalo: false,
        tenCongTy: false,
        masoThue: false,
        diachiHoaDon: true,
        nguonDen: false,
        ngayDen: true,
        ngGioiThieu: false,
        matheTV: false
    };
    // tslint:disable-next-line:no-output-rename
    @Output('listColumnTable') handleField = new EventEmitter<any>();
    constructor() { }

    ngOnInit() { }

    onSave() {
        this.handleField.emit({
            ...this.listColumnTable // gán obj cũ qua obj mới
        });
        this.onCloseModal();
    }
    // OPEN MODAL
    onOpenModal() {
        $('#field-modal').modal('show');
    }
    // CLOSE MODAL
    onCloseModal() {
        $('#field-modal').modal('hide');
    }
}
