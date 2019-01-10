import { HttpParams } from '@angular/common/http';

export class PagingModel {
  currentPage: number;
  totalRecords: number;
  pageSize: number;
  totalPages: number;

  constructor() {
    this.currentPage = 1;
    this.totalRecords = 1;
    this.pageSize = 10;
    this.totalPages = 1;
  }
}

export class PagingQueryModel {
  search: string;
  page: number;
  pageSize: number;

  constructor() {
    this.search = '';
    this.page = 1;
    this.pageSize = 10;
  }

  getHttpParams() {
    return new HttpParams()
      .set('page', this.page.toString())
      .set('pageSize', this.pageSize.toString())
      .set('search', this.search);
  }
}
