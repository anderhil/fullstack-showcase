import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject} from 'rxjs';
import {map} from 'rxjs/operators';

import {User} from '../models/user';
import {BaseService} from './base.service';
import {ServerEndpoints} from './serverendpoints';

@Injectable({ providedIn: 'root' })
export class AuthService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
  }

  login(username: string, password: string) {
    return this.extendedHttp.post<any>(ServerEndpoints.AUTHENTICATE, { username, password })
      .pipe(map(user => {
        if (user.tokenString) {
          // token in local storage
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
        }

        return user;
      }));
  }

  logout() {
    // remove user to logout
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
