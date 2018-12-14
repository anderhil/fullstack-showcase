import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import {AuthService} from '../../services/auth.service';
import {SavingsDepositService} from '../../services/savingsDeposits.service';
import {User} from '../../models/user';
import {SavingsDeposit} from '../../models/savingsDeposit';
import {BehaviorSubject, Observable, Subscription} from 'rxjs';
import {UserService} from '../../services/user.service';
import {NotifyService} from '../../services/notify.service';
import { Location } from '@angular/common';

@Component({templateUrl: 'users.view.component.html', styleUrls: ['./user.edit.component.css']})
export class UsersViewComponent implements OnInit {
  currentUser: User;
  currentUserSubscription: Subscription;
  users: User[] = [];
  cachedSavingsDeposits: User[] = [];

  constructor(
    private router: Router,
    private authService: AuthService,
    private userService: UserService,
    private notifier: NotifyService,
    private location: Location
  ) {
    this.currentUserSubscription = this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
    });
  }

  ngOnInit() {
    this.loadAllUsers();
  }

  deleteUser(username: string) {

    if (!confirm('Are you sure you want to remove : ' + username)) {
      return;
    }

    this.userService.delete(username).subscribe( data => {
          const index = this.users.findIndex(x => x.username === username);
          this.users.splice(index, 1);
          }, error => {this.notifier.error(error);
    });
  }

  goBack(): void {
    this.location.back();
  }

  navigateTo(userName: string) {
    this.router.navigate(['savingsEditor', 0, {'userName': userName}]);
  }

  private loadAllUsers() {
    this.userService.getAll().pipe(first()).subscribe(users => {
      this.users = users;
    }, error => {
      this.notifier.error(error);
    });
  }

}
