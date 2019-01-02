import { Injectable } from '@angular/core';
import { LogPublishersService } from './log-publishers.service';
import { LogPublisher } from './log-publisher';
import { LogLevel } from './log-level.enum';

export class LogEntry {
    // Public Properties
    entryDate: Date = new Date();
    message: String = '';
    level: LogLevel = LogLevel.DEBUG;
    extraInfo: any[] = [];
    logWithDate: Boolean = true;

    buildLogString(): String {
        let ret: String = '';

        if (this.logWithDate) {
            ret = new Date() + ' - ';
        }

        ret = ret + 'Type: ' + LogLevel[this.level];
        ret = ret + ' - Message: ' + this.message;
        if (this.extraInfo.length) {
            ret = ret + ' - Extra Info: ' + this.formatParams(this.extraInfo);
        }
        return ret;
    }

    private formatParams(params: any[]): string {
        let ret: string = params.join(',');

        // Is there at least one object in the array?
        if (params.some(p => typeof p === 'object')) {
            ret = '';
            // Build comma-delimited string
            for (const item of params) {
                ret += JSON.stringify(item) + ',';
            }
        }
        return ret;
    }
}

@Injectable()
export class LogService {

    level: LogLevel = LogLevel.ALL;
    logWithDate: Boolean = true;
    publishers: LogPublisher[];

    constructor(private publishersService: LogPublishersService) {
        this.publishers = this.publishersService.publishers;
    }

    // check, compare parameter passed in with this.level that is set.
    private shouldLog(level: LogLevel): boolean {
        let flag = false;
        if ((level >= this.level && level !== LogLevel.OFF) || this.level === LogLevel.ALL) {
            flag = true;
        }
        return flag;
    }


    private writeToLog(msg: string, level: LogLevel, params: any[]) {
        if (this.shouldLog(level)) {
            // Build log string
            const entry: LogEntry = new LogEntry();
            entry.message = msg;
            entry.level = level;
            entry.extraInfo = params;
            entry.logWithDate = this.logWithDate;
            for (const logger of this.publishers) {
                logger.log(entry).subscribe(res => console.log(res));
            }
        }
    }

    debug(msg: string, ...optionalParams: any[]) {
        this.writeToLog(msg, LogLevel.DEBUG,
            optionalParams);
    }

    info(msg: string, ...optionalParams: any[]) {
        this.writeToLog(msg, LogLevel.INFO,
            optionalParams);
    }

    warn(msg: string, ...optionalParams: any[]) {
        this.writeToLog(msg, LogLevel.WARN,
            optionalParams);
    }

    error(msg: string, ...optionalParams: any[]) {
        this.writeToLog(msg, LogLevel.ERROR,
            optionalParams);
    }

    fatal(msg: string, ...optionalParams: any[]) {
        this.writeToLog(msg, LogLevel.FATAL,
            optionalParams);
    }

    log(msg: string, ...optionalParams: any[]) {
        this.writeToLog(msg, LogLevel.ALL,
            optionalParams);
    }
}
