import { Observable, of } from 'rxjs';
import { LogEntry } from './log.service';

/* LogPublisher is abstract class with 2 methods
    1.Log: Write log
    2.Clear: Clear log
 */

export abstract class LogPublisher {
  location: string;
  abstract log(record: LogEntry): Observable<boolean>;
  abstract clear(): Observable<boolean>;
}

/* LogConsole Class */
export class LogConsole extends LogPublisher {

    log(entry: LogEntry): Observable<boolean> {
      console.log(entry.buildLogString());
      return of(true);
    }

    clear(): Observable<boolean> {
      console.clear();
      return of(true);
    }
}

/* LogLocalStorage Class */
export class LogLocalStorage extends LogPublisher {
    constructor() {
        // Must call super() from derived classes
        super();
        // Set location
        this.location = 'logging';
    }

    log(entry: LogEntry): Observable<boolean> {
        let ret = false;
        let values: LogEntry[];
        try {
            // Get previous values from local storage
            values = JSON.parse(localStorage.getItem(this.location)) || [];
            // Add new log entry to array
            values.push(entry);
            // Store array into local storage
            localStorage.setItem(this.location, JSON.stringify(values));
            // Set return value
            ret = true;
        } catch (ex) {
            // Display error in console
            console.log(ex);
        }
        return of(ret);
    }

    clear(): Observable<boolean> {
        localStorage.removeItem(this.location);
        return of(true);
    }
}
