import { Component, OnInit, OnDestroy } from '@angular/core';
import { ConfigurationService } from '../../core/services/configuration.service';
import { MessageService } from 'primeng/api';
import { Subscription } from 'rxjs/subscription';

@Component({
  selector: 'app-configuration',
  templateUrl: './configuration.component.html',
  styleUrls: ['./configuration.component.css']
})
export class ConfigurationComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  configInfo: any;
  selectedConfig: any;
  displayDialog: any;
  configUpdate: any = {
    maCH: '',
    tenCH: '',
    giaTri: '',
    dateCreated: '',
    ghiChu: ''
  };
  cols = [
    { header: 'Mã Cấu Hình', field: 'maCH' },
    { header: 'Tên Cấu Hình', field: 'tenCH' },
    { header: 'Giá Trị', field: 'giaTri' },
    { header: 'Ngày Tạo', field: 'dateCreated' },
    { header: 'Ghi Chú', field: 'ghiChu' }
  ];
  constructor(
    private configurationService: ConfigurationService,
    private messageService: MessageService
  ) {}

  // notify when submit success
  toastSuccess() {
    this.messageService.add({
      severity: 'success',
      detail: 'Cập nhật thành công'
    });
  }

  ngOnInit() {
    this.getAllConfiguration();
  }

  // get all config from db
  getAllConfiguration() {
    this.subscription = this.configurationService
      .getAllConfiguration()
      .subscribe(
        response => {
          this.configInfo = response;
        },
        error => {}
      );
  }

  // submit (update) event
  onSubmit() {
    this.subscription = this.configurationService
      .updateConfiguration(this.configUpdate.id, this.configUpdate)
      .subscribe(
        () => {
          this.toastSuccess();
          this.getAllConfiguration();
        },
        error => {}
      );
    this.displayDialog = false;
  }

  // select row on table
  onRowSelect(event) {
    this.configUpdate = this.cloneConfig(event.data);
    this.displayDialog = true;
  }

  // call in onRowSelect
  cloneConfig(cf: any) {
    const config = {};
    // tslint:disable-next-line:forin
    for (const prop in cf) {
      config[prop] = cf[prop];
    }
    return config;
  }

  onCloseForm() {
    this.displayDialog = false;
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
