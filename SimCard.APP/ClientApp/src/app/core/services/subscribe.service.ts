import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable()
export class SubscribeService {
  private subscribes: Subject<any>[] = [];

  constructor() {}

  $subscribe(name: string): Observable<any> {
    this.initSubscribeByName(name);
    return this.subscribes[name].asObservable();
  }

  publish(name: string, result) {
    this.initSubscribeByName(name);
    return this.subscribes[name].next(result);
  }

  private initSubscribeByName(name: string) {
    if (!this.subscribes[name]) {
      this.subscribes[name] = new Subject<any>();
    }
  }
}
