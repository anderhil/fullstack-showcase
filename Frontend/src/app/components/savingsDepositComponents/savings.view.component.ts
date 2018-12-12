import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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

  minAmount: number;
  maxAmount: number;
  startDate: Date;
  endDate: Date;

  constructor(
    private router: Router,
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
    this.loadAllSavings();
  }

  private loadAllSavings() {
    this.savingsService.getAllSavings().pipe(first()).subscribe(deposits => {
      this.savingsDeposits = deposits;
      this.cachedSavingsDeposits = deposits;
      this.banksDistinct = new Set(deposits.map(x => x.bankName));
    });
  }

}
