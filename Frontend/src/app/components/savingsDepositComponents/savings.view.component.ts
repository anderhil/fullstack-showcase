import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { first } from 'rxjs/operators';
import {AuthService} from '../../services/auth.service';
import {SavingsDepositService} from '../../services/savingsDeposits.service';
import {User} from '../../models/user';
import {SavingsDeposit} from '../../models/savingsDeposit';
import {BehaviorSubject, Observable, Subscription} from 'rxjs';

@Component({templateUrl: 'savings.view.component.html', styleUrls: ['./savings.view.component.css']})
export class SavingsViewComponent implements OnInit {
  currentUser: User;
  currentUserSubscription: Subscription;
  savingsDeposits: SavingsDeposit[] = [];
  cachedSavingsDeposits: SavingsDeposit[] = [];
  banksDistinct: Set<string>;
  currentBank: string;

  adminMode = false;
  userName = '';
  minAmount: number;
  maxAmount: number;
  startDate: Date;
  endDate: Date;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private savingsService: SavingsDepositService
  ) {
    this.currentUserSubscription = this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
    });
  }

  filterBanks(filterVal: any) {
    // this.currentBankSelected = filterVal;
    if (filterVal === '0') {
      this.savingsDeposits = this.cachedSavingsDeposits;
    } else {
        this.savingsDeposits = this.cachedSavingsDeposits.filter((item) => item.bankName === filterVal);
    }
  }

  filter() {
    this.savingsDeposits = this.cachedSavingsDeposits;
    this.filterBanks(this.currentBank);
    if (this.minAmount) {
      this.savingsDeposits = this.savingsDeposits.filter(x => x.initialAmount >= this.minAmount);
    }
    if (this.maxAmount) {
      this.savingsDeposits = this.savingsDeposits.filter(x => x.initialAmount <= this.maxAmount);
    }
    if (this.startDate) {
      this.savingsDeposits = this.savingsDeposits.filter(x => x.startDate >= this.startDate);
    }
    if (this.endDate) {
      this.savingsDeposits = this.savingsDeposits.filter(x => x.endDate <= this.endDate);
    }
  }

  reset() {
    this.currentBank = '0';
    this.minAmount = null;
    this.maxAmount = null;
    this.startDate = null;
    this.endDate = null;
    this.savingsDeposits = this.cachedSavingsDeposits;

  }
  ngOnInit() {

    this.route.params.subscribe(params => {
      const userName = params['user'];
      this.loadAllSavings(userName);
    });

  }

  navigate(savingId) {
    if (this.adminMode) {
      this.router.navigate(['savingsEditor', savingId, {'userName': this.userName}]);
    } else {
      this.router.navigate(['savingsEditor', savingId]);
    }
  }

  private loadAllSavings(user?: string) {
    let request: Observable<SavingsDeposit[]>;
    if (!user) {
      request = this.savingsService.getAllSavings();
    } else {
      request = this.savingsService.getAllSavingsByUser(user);
      this.adminMode = true;
      this.userName = user;
    }
    request.pipe(first()).subscribe(deposits => {
      this.savingsDeposits = deposits;
      this.cachedSavingsDeposits = deposits;
      this.banksDistinct = new Set(deposits.map(x => x.bankName));
    });
  }

}
