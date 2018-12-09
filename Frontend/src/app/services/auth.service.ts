import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import {User} from '../models/user';
import {BaseService} from './base.service';
import {ServerEndpoints} from './serverendpoints';

@Injectable({ providedIn: 'root' })
export class AuthService extends BaseService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(http: HttpClient) {
    super(http);
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
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
