import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {ServerEndpoints} from './serverendpoints';
import {User} from '../models/user';

export class AppHttpClient {

  baseAddress = 'http://localhost:5000';
  constructor(private http: HttpClient, protected user: BehaviorSubject<User>) {

  }

  headers(): HttpHeaders {
    if (this.user.value && this.user.value.tokenString) {
      return new HttpHeaders({'Authorization': 'Bearer ' + this.user.value.tokenString});
    }
    return new HttpHeaders();
  }

  addBase(endpoint: ServerEndpoints) {
    return this.baseAddress + '/' + endpoint;
  }

  post<T>(endpoint: ServerEndpoints, body: any): Observable<T> {
    return this.http.post<T>(this.addBase(endpoint), body, {headers: this.headers()});
  }

  postWithParam<T>(endpoint: ServerEndpoints, param: any, body: any): Observable<T> {
    let path = this.addBase(endpoint) ;
    if (param) {
      path = path + '/' + param;
    }
    return this.http.post<T>(path, body, {headers: this.headers()});
  }

  delete<T>(endpoint: ServerEndpoints, id: T) {
    return this.http.delete<T>(this.addBase(endpoint) + '/' + id, {headers: this.headers()});
  }

  put<T>(endpoint: ServerEndpoints, body: any, param?: any): Observable<T> {
    let path = this.addBase(endpoint) ;
    if (param) {
      path = path + '/' + param;
    }
    return this.http.put<T>(path, body, {headers: this.headers()});
  }

  get<T>(endpoint: ServerEndpoints, param?: any): Observable<T> {
    let path = this.addBase(endpoint) ;
    if (param) {
      path = path + '/' + param;
    }
    return this.http.get<T>(path, {headers: this.headers()});
  }

  getWithParams<T>(endpoint: ServerEndpoints, pathParam: any, qParams?: HttpParams | {
    [param: string]: string | string[];
  }): Observable<T> {
    let path = this.addBase(endpoint) ;
    if (pathParam) {
      path = path + '/' + pathParam;
    }
    return this.http.get<T>(path, {headers: this.headers(), params: qParams});
  }

  getWithTwoParams<T>(endpoint: ServerEndpoints, pathParam: any, pathParam2: any): Observable<T> {
    let path = this.addBase(endpoint) ;
    if (pathParam) {
      path = path + '/' + pathParam;
    }
    if (pathParam2) {
      path = path + '/' + pathParam2;
    }
    return this.http.get<T>(path, {headers: this.headers()});
  }

}
