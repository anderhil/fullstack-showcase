import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from 'rxjs';
import {NotifyService} from '../../services/notify.service';
import {NGXLogger} from 'ngx-logger';


@Component({
  selector: 'notifier',
  templateUrl: 'notification.component.html'
})

export class NotificationComponent implements OnInit, OnDestroy {
  private subscription: Subscription;
  message: any;

  constructor(private alertService: NotifyService, private logger: NGXLogger) { }

  ngOnInit() {
    this.subscription = this.alertService.getMessage().subscribe(msg => {

      if (msg) {
        const errorJsonObj = msg.errorResponse;
        this.logger.error(errorJsonObj);
        if (errorJsonObj.error) {
          msg.text = errorJsonObj.error;
          this.message = msg;
        } else {
          // for debug purposes
          msg.text = errorJsonObj.toString();
          this.message = msg;
        }
      } else {
        this.message = msg;
      }
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
