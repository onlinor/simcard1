import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-search-box',
    templateUrl: './search-box.component.html',
    styleUrls: ['./search-box.component.css']
})
export class SearchBoxComponent implements OnInit {
    data: string;
    // tslint:disable-next-line:no-output-rename
    @Output('keyword') handleSearchKH = new EventEmitter<any>();

    constructor() { }

    ngOnInit() {
    }

    // emit data 
    onSearch() {
        this.handleSearchKH.emit(this.data);
    }
}
