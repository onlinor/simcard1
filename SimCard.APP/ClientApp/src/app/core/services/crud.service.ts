import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable()
export class CrudService {
  private saveResultSubject = new Subject<any>();
  private createSubject = new Subject<any>();
  private editSubject = new Subject<any>();
  private deleteSubject = new Subject<any>();
  private loadSubject = new Subject<any>();
  private actionSubject = new Subject<any>();

  constructor() {}

  get $saveResult(): Observable<any> {
    return this.saveResultSubject.asObservable();
  }

  saveResult(result: any) {
    this.saveResultSubject.next(result);
  }

  get $create(): Observable<any> {
    return this.createSubject.asObservable();
  }

  create(result: any) {
    this.createSubject.next(result);
  }

  get $load(): Observable<any> {
    return this.loadSubject.asObservable();
  }

  load(result: any) {
    this.loadSubject.next(result);
  }

  get $edit(): Observable<any> {
    return this.editSubject.asObservable();
  }

  edit(id: any) {
    this.editSubject.next(id);
  }

  get $delete(): Observable<any> {
    return this.deleteSubject.asObservable();
  }

  delete(id: any) {
    this.deleteSubject.next(id);
  }

  get $action(): Observable<any> {
    return this.actionSubject.asObservable();
  }

  action(id: any) {
    this.actionSubject.next(id);
  }
}
