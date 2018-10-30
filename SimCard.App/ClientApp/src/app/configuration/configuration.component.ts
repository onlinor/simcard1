import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../_services/configuration-service/configuration.service';
import { MessageService } from 'primeng/api';

@Component({
    selector: 'app-configuration',
    templateUrl: './configuration.component.html',
    styleUrls: ['./configuration.component.css']
})
export class ConfigurationComponent implements OnInit {
    configInfo: any;
    selectedConfig: any;
    displayDialog: any;
    configUpdate: any = {
        maCH: '',
        tenCH: '',
        giaTri: '',
        ngayTao: '',
        ghiChu: ''
    };
    cols = [
        { header: 'Mã Cấu Hình', field: 'maCH'},
        { header: 'Tên Cấu Hình', field: 'tenCH'},
        { header: 'Giá Trị', field: 'giaTri'},
        { header: 'Ngày Tạo', field: 'ngayTao'},
        { header: 'Ghi Chú', field: 'ghiChu'}
    ];
    constructor(
        private configurationService: ConfigurationService,
        private messageService: MessageService
    ) { }

    toastSuccess() {
        this.messageService.add({severity: 'success', detail: 'Cập nhật thành công'});
    }

    toastError() {
        this.messageService.add({severity: 'error', detail: 'Cập nhật thất bại'});
    }

    ngOnInit() {
        this.getAllConfiguration();
    }

    getAllConfiguration() {
        this.configurationService.getAllConfiguration().subscribe(
            response => {
                this.configInfo = response;
                console.log('info', this.configInfo);
            },
            error => {
                console.log(error);
            }
        );
    }

    onSubmit() {
        this.configurationService.updateCustomer(this.configUpdate.id, this.configUpdate)
            .subscribe(() => {
                this.toastSuccess();
                this.getAllConfiguration();
            }, error => {
                console.log(error);
            });
        this.displayDialog = false;
    }

    onRowSelect(event) {
        this.configUpdate = this.cloneConfig(event.data);
        this.displayDialog = true;
    }
    cloneConfig(cf: any) {
        const config = {};
        // tslint:disable-next-line:forin
        for (const prop in cf) {
            config[prop] = cf[prop];
        }
        return config;
    }
}
