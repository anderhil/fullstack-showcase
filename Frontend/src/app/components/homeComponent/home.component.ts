import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import {AuthService} from '../../services/auth.service';
import {SavingsDepositService} from '../../services/savingsDeposits.service';
import {User} from '../../models/user';
import {SavingsDeposit} from '../../models/savingsDeposit';
import {Subscription} from 'rxjs';

@Component({templateUrl: 'home.component.html', styleUrls: ['home.component.css']})
export class HomeComponent implements OnInit {
  currentUser: User;
  currentUserSubscription: Subscription;
  savingsDeposits: SavingsDeposit[] = [];

  constructor(
    private router: Router,
    private authService: AuthService,
    private savingsService: SavingsDepositService
  ) {
    this.currentUserSubscription = this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
    });
  }

  ngOnInit() {
    this.loadAllSavings();
  }

  private loadAllSavings() {
    this.savingsService.getAllSavings().pipe(first()).subscribe(deposits => {
      this.savingsDeposits = deposits;
    });
  }

}
