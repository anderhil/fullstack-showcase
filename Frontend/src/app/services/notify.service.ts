import { Injectable } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import {HttpErrorResponse} from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class NotifyService {
  private subject = new Subject<any>();

  constructor(private router: Router) {

    router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
          this.subject.next();
      }
    });
  }

  success(message: string) {
    this.subject.next({ type: 'success', text: message });
  }

  // error(message: string) {
  //   this.subject.next({ type: 'error', text: message });
  // }

  error(response: HttpErrorResponse) {
    this.subject.next({ type: 'error', errorResponse: response.error });
  }

  getMessage(): Observable<any> {
    return this.subject.asObservable();
  }
}
