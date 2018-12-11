import {Injectable} from '@angular/core';
import {BaseService} from './base.service';
import {BehaviorSubject, Observable} from 'rxjs';
import {User} from '../models/user';
import {HttpClient} from '@angular/common/http';
import {ServerEndpoints} from './serverendpoints';
import {map} from 'rxjs/operators';
import {SavingsDeposit} from '../models/savingsDeposit';

@Injectable({ providedIn: 'root' })
export class SavingsDepositService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
  }

  public getAllSavings() {
    return this.extendedHttp.get<SavingsDeposit[]>(ServerEndpoints.USERSAVINGS);
  }

  public getSavingsDeposit(id: number) {
    return this.extendedHttp.get<SavingsDeposit>(ServerEndpoints.USERSAVINGDEPOSIT, id);
  }
}
