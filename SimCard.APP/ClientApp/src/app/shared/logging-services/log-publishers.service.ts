import { Injectable } from '@angular/core';
import { LogPublisher, LogConsole, LogLocalStorage } from './log-publisher';

@Injectable()
export class LogPublishersService {
    constructor() {
        this.buildPublishers();
    }

    // properties
    publishers: LogPublisher[] = [];

    // Build publishers array
    buildPublishers() {
        // Create instance of LogConsole Class
        this.publishers.push(new LogConsole());
        // this.publishers.push(new LogLocalStorage());
    }
}
