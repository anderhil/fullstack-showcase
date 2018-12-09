import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ServerEndpoints} from './serverendpoints';

export class AppHttpClient {

  baseAddress = 'http://localhost:5000';

  constructor(private http: HttpClient) {
  }


  addBase(endpoint: ServerEndpoints) {
    return this.baseAddress + '/' + endpoint;
  }

  post<T>(endpoint: ServerEndpoints, body: any): Observable<T> {

    return this.http.post<T>(this.addBase(endpoint), body);
  }

  get<T>(endpoint: ServerEndpoints, param: any): Observable<T> {
    const path = this.addBase(endpoint) + '/' + param;
    return this.http.get<T>(path);
  }

}
