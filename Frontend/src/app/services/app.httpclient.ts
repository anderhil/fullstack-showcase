import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {ServerEndpoints} from './serverendpoints';
import {User} from '../models/user';

export class AppHttpClient {

  baseAddress = 'http://localhost:5000';
  headers: HttpHeaders = new HttpHeaders();
  constructor(private http: HttpClient, protected user: User) {
    if (this.user && this.user.tokenString) {
      this.headers = new HttpHeaders({'Authorization': 'Bearer ' + this.user.tokenString});
    }
  }


  addBase(endpoint: ServerEndpoints) {
    return this.baseAddress + '/' + endpoint;
  }

  post<T>(endpoint: ServerEndpoints, body: any): Observable<T> {
    return this.http.post<T>(this.addBase(endpoint), body, {headers: this.headers});
  }

  get<T>(endpoint: ServerEndpoints, param?: any): Observable<T> {
    let path = this.addBase(endpoint) ;
    if (param) {
      path = path + '/' + param;
    }
    return this.http.get<T>(path, {headers: this.headers});
  }

}
