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
    return this.extendedHttp.get<SavingsDeposit[]>(ServerEndpoints.USERSAVINGSAPIALL);
  }

  public deleteSaving(savingsId: number) {
    return this.extendedHttp.delete(ServerEndpoints.USERSAVINGDSAPI, savingsId);
  }

  public getAllSavingsByUser(userName: string) {
    return this.extendedHttp.get<SavingsDeposit[]>(ServerEndpoints.USERSAVINGSAPIALL, userName);
  }

  public getSavingsDeposit(id: number) {
    return this.extendedHttp.get<SavingsDeposit>(ServerEndpoints.USERSAVINGDSAPI, id);
  }
  public getSavingsDepositByUser(id: number, user: string) {
    return this.extendedHttp.getWithTwoParams<SavingsDeposit>(ServerEndpoints.USERSAVINGDSAPI, id, user);
  }

  public createSavingsDeposit(savingDeposit: SavingsDeposit) {
    return this.extendedHttp.post(ServerEndpoints.USERSAVINGDSAPI, savingDeposit);
  }

  public createSavingsDepositForUser(userName: string, savingDeposit: SavingsDeposit) {
    return this.extendedHttp.postWithParam(ServerEndpoints.USERSAVINGDSAPI, userName, savingDeposit);
  }

  public updateSavingsDeposit(savingDeposit: SavingsDeposit) {
    return this.extendedHttp.put(ServerEndpoints.USERSAVINGDSAPI, savingDeposit, savingDeposit.id);
  }
}
