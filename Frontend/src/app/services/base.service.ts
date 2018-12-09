import {HttpClient, HttpHeaders} from '@angular/common/http';
import {AppHttpClient} from './app.httpclient';
import {BehaviorSubject, Observable} from 'rxjs';
import {User} from '../models/user';

export class BaseService {
  extendedHttp: AppHttpClient;
  protected currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) {
    const user = JSON.parse(localStorage.getItem('currentUser'));
    this.currentUserSubject = new BehaviorSubject<User>(user);
    this.currentUser = this.currentUserSubject.asObservable();
    this.extendedHttp = new AppHttpClient(http, this.currentUserValue);
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }
}
