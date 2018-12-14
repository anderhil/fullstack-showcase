import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {BehaviorSubject} from 'rxjs';
import {map} from 'rxjs/operators';

import {User} from '../models/user';
import {BaseService} from './base.service';
import {ServerEndpoints} from './serverendpoints';
import {DateRangeReport} from '../models/dateRangeReport';

@Injectable({ providedIn: 'root' })
export class ReportingService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
  }

  generateReport(startDate: Date, endDate: Date) {

    const params = new HttpParams().set('startDate', startDate.toString()).set('endDate', endDate.toString());
    return this.extendedHttp.getWithParams<DateRangeReport>(ServerEndpoints.REPORT, '', params);
  }

  logout() {
    // remove user to logout
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
