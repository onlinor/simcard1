import { Component, OnInit, OnDestroy } from '@angular/core';
import { EventsService } from '../../core/services/events.service';
import { MessageService } from 'primeng/api';
import { Subscription } from 'rxjs/subscription';
import { LogService } from '../../shared/logging-services/log.service';

@Component({
    selector: 'app-events',
    templateUrl: './events.component.html',
    styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit, OnDestroy {
    subscription: Subscription;
    isDisplayButton: boolean;
    isNgayBatDauBlank: boolean;
    isNgayKetThucBlank: boolean;
    isValidNgayBatDau = true;
    isValidNgayKetThuc = true;
    newEvent: boolean;
    idSelectedEvent: any;
    dsEvent: any;
    selectedEvent: any;
    displayDialog: boolean;
    selectedLoaiSK: String = 'KM';
    lastIDRecord: any;
    LoaiSK = [
        { label: 'Khuyến Mãi', value: 'KM' },
        { label: 'Chiết Khấu', value: 'CK' },
    ];
    selectedDoiTuong: String = 'All';
    LoaiDoiTuong = [
        { label: 'Tất Cả Khách Hàng', value: 'All' },
        { label: 'Lợi Nhuận Cao', value: 'LNC' },
        { label: 'Doanh Số Cao', value: 'DSC' },
    ];
    eventUpdate: any = {
        loaiSK: '',
        maSK: '',
        tenSK: '',
        noiDung: '',
        doiTuong: '',
        dateCreated: new Date().toLocaleDateString(),
        tgBatDau: null,
        tgKetThuc: null,
        eventStatus: null,
        isNewEvent: null,
        isCompleteEvent: null
    };
    cols = [
        { header: 'Loại Sự Kiện', field: 'loaiSK' },
        { header: 'Mã Sự Kiện', field: 'maSK' },
        { header: 'Tên Sự Kiện', field: 'tenSK' },
        { header: 'Nội Dung', field: 'noiDung' },
        { header: 'Ngày Tạo', field: 'dateCreated' },
        { header: 'Thời Gian Bắt Đầu', field: 'tgBatDau' },
        { header: 'Thời Gian Kết Thúc', field: 'tgKetThuc' },
        { header: 'Đối Tượng', field: 'doiTuong' },
        { header: 'Trạng Thái', field: 'eventStatus'}
    ];
    constructor(private eventService: EventsService, private messageService: MessageService,
                      private logService: LogService) { }

    ngOnInit() {
        this.getAllEvent();
    }

    // parse date
    parseDate(dateString: string, prop: string): Date {
        if (dateString) {
            if (prop === 'tgBatDau') {
                this.isNgayBatDauBlank = false;
            }
            if (prop === 'tgKetThuc') {
                this.isNgayKetThucBlank = false;
            }
            this.eventUpdate[prop] = new Date(dateString);
            this.CompareDate();
        } else {
            if (prop === 'tgBatDau') {
                this.isNgayBatDauBlank = true;
            }
            if (prop === 'tgKetThuc') {
                this.isNgayKetThucBlank = true;
            }
            return null;
        }
    }

    // Notify submit success
    toastSuccess() {
        this.messageService.add({severity: 'success', detail: 'Dữ liệu đã được cập nhật'});
    }

    // Notify event update success
    toastUpdateEventSuccess() {
        this.messageService.add({severity: 'success', detail: 'Cập nhật trạng thái sự kiện'});
    }

    // get all event from
    getAllEvent() {
        this.subscription = this.eventService.getAllEvents()
            .subscribe(reponse => {
                this.dsEvent = reponse;
            }, error => {
                this.logService.error(error['message']);
            });
    }

    // get last id record to generate maKH with type: KH + id
    getLastIDEventRecord() {
        this.subscription = this.eventService.getLastIDEventRecord().subscribe(
            response => {
                this.lastIDRecord = response;
                this.onGenerateMaSK();
            }, error => {
                this.logService.error(error['message']);
            });
    }

    // generate ngayTao
    onGenerateNgayTao() {
      this.eventUpdate.dateCreated = new Date().toLocaleDateString();
    }

    // generate maSK
    onGenerateMaSK() {
        if (!this.lastIDRecord) {
            this.lastIDRecord = 0;
        }
        this.lastIDRecord = this.lastIDRecord + 1;
        const maSK = 'SK' + this.lastIDRecord;
        this.eventUpdate.maSK = maSK;
    }

    // select row on table
    onRowSelect(event) {
        this.displayDialog = true;
        this.newEvent = false;
        this.idSelectedEvent = event.data.id;
        this.eventUpdate = this.cloneEvent(event.data);
        this.isDisplayButton = true;
    }

    // call in onRowSelect, through data
    cloneEvent(eventParams: any) {
        const events = {};
        // tslint:disable-next-line:forin
        for (const prop in eventParams) {
            events[prop] = eventParams[prop];
        }
        return events;
    }

    // Open form
    showDialogToAdd() {
        this.eventUpdate.isNewEvent = true;
        this.displayDialog = true;
        this.getLastIDEventRecord();
        this.newEvent = true;
        this.eventUpdate = {};
        this.onGenerateMaSK();
        this.onGenerateNgayTao();
        this.isDisplayButton = false;
    }

    // Delete Event
    onDeleteEvent() {
        this.subscription = this.eventService.deleteEvent(this.idSelectedEvent)
            .subscribe(() => {
                this.toastSuccess();
                this.getAllEvent();
            }, error => {
                this.logService.error(error['message']);
            });
        this.displayDialog = false;
    }

    // Active Event
    onActiveEvent() {
        this.eventUpdate.isNewEvent = false;
        this.eventUpdate.eventStatus = !this.eventUpdate.eventStatus;
        this.subscription = this.eventService.updateStatusEvent(this.idSelectedEvent, this.eventUpdate)
        .subscribe(() => {
            this.toastUpdateEventSuccess();
            this.getAllEvent();
        }, error => {
            this.logService.error(error['message']);
        });
        this.displayDialog = false;
    }

    // Submit form
    onSubmit() {
        this.eventUpdate.loaiSK = this.selectedLoaiSK;
        this.eventUpdate.doiTuong = this.selectedDoiTuong;
        if (this.newEvent) {
            this.eventUpdate.isNewEvent = true;
            this.subscription = this.eventService.addEvent(this.eventUpdate)
            .subscribe(() => {
                this.toastSuccess();
                this.getAllEvent();
            }, error => {
                this.logService.error(error['message']);
            });
        } else {
            this.subscription = this.eventService.updateEvent(this.idSelectedEvent, this.eventUpdate)
                .subscribe(() => {
                    this.toastSuccess();
                    this.getAllEvent();
                }, error => {
                    this.logService.error(error['message']);
                });
        }
        this.eventUpdate = {};
        this.displayDialog = false;
    }

    // Validation for ngayTao, ngayDen, ngayKetThuc
    CompareDate() {
        const ngayTao = new Date(this.eventUpdate.dateCreated);
        const ngayBatDau = new Date(this.eventUpdate.tgBatDau);
        const ngayKetThuc = new Date(this.eventUpdate.tgKetThuc);
        if (ngayBatDau) {
            if ( ngayTao > ngayBatDau || ngayBatDau > ngayKetThuc ) {
                this.isValidNgayBatDau = false;
            } else {
                this.isValidNgayBatDau = true;
            }
        }
        if (ngayKetThuc) {
            if ( ngayTao > ngayKetThuc || ngayBatDau > ngayKetThuc ) {
                this.isValidNgayKetThuc = false;
            } else {
                this.isValidNgayKetThuc = true;
            }
        }
    }

    onCloseForm() {
        if (this.newEvent === false) {
            if (this.isNgayBatDauBlank === true) {
                this.isNgayBatDauBlank = false;
            }
            if (this.isNgayKetThucBlank === true) {
                this.isNgayKetThucBlank = false;
            }
            if (this.isValidNgayBatDau === false) {
                this.isValidNgayBatDau = true;
            }
            if (this.isValidNgayKetThuc === false) {
                this.isValidNgayKetThuc = true;
            }
        }
        this.eventUpdate = {};
        this.displayDialog = false;
    }
    ngOnDestroy() {
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }
}
