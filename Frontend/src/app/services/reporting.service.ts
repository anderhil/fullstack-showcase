import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {BehaviorSubject} from 'rxjs';
import {map} from 'rxjs/operators';

import {User} from '../models/user';
import {BaseService} from './base.service';
import {ServerEndpoints} from './serverendpoints';

@Injectable({ providedIn: 'root' })
export class ReportingService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
  }

  generateReport(startDate: Date, endDate: Date) {

    const params = new HttpParams();
    params.append('startDate', startDate.toJSON());
    params.append('endDate', endDate.toJSON());
    return this.extendedHttp.getWithParams<any>(ServerEndpoints.REPORT, '', params)
      .subscribe(x => {
          console.log(x);
      });
  }

  logout() {
    // remove user to logout
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
