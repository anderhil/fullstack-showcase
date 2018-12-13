import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import {AuthService} from '../../services/auth.service';
import {SavingsDepositService} from '../../services/savingsDeposits.service';
import {User} from '../../models/user';
import {SavingsDeposit} from '../../models/savingsDeposit';
import {BehaviorSubject, Observable, Subscription} from 'rxjs';
import {UserService} from '../../services/user.service';

@Component({templateUrl: 'users.view.component.html', styleUrls: ['./users.view.component.css']})
export class UsersViewComponent implements OnInit {
  currentUser: User;
  currentUserSubscription: Subscription;
  users: User[] = [];
  cachedSavingsDeposits: User[] = [];

  constructor(
    private router: Router,
    private authService: AuthService,
    private userService: UserService
  ) {
    this.currentUserSubscription = this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
    });
  }

  ngOnInit() {
    this.loadAllUsers();
  }

  private loadAllUsers() {
    this.userService.getAll().pipe(first()).subscribe(users => {
      this.users = users;
      this.cachedSavingsDeposits = users;
    });
  }

}
