import { Component, OnInit, Output, EventEmitter} from '@angular/core';


@Component({
    selector: 'app-date-input',
    templateUrl: './date-input.component.html',
    styleUrls: ['./date-input.component.css']
})
export class DateInputComponent implements OnInit {
    arr31days = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31];
    arr30days = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30];
    arr28days = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28];
    arrNgaySinh = this.arr31days;
    day: any;
    month: any;
    @Output('day') onHandleDay = new EventEmitter<string>();
    @Output('month') onHandleMonth = new EventEmitter<string>();

    constructor() { }

    ngOnInit() {
    }

    onChangeMonth(month) {
        this.month = month;
        if (month === '2') {
            this.arrNgaySinh = this.arr28days;
        } else if (month === '4' || month === '6' || month === '9' || month === '11') {
            this.arrNgaySinh = this.arr30days;
        } else {
            this.arrNgaySinh = this.arr31days;
        }
        this.onHandleMonth.emit(this.month);
    }

    onChangeDay(day) {
        this.day = day;
        this.onHandleDay.emit(this.day);
    }

}
