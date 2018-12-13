import {Component, Input, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { first } from 'rxjs/operators';
import {AuthService} from '../../services/auth.service';
import {SavingsDepositService} from '../../services/savingsDeposits.service';
import {User} from '../../models/user';
import {SavingsDeposit} from '../../models/savingsDeposit';
import {Observable, Subscription} from 'rxjs';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { Location } from '@angular/common';
import {el} from '@angular/platform-browser/testing/src/browser_util';

@Component({templateUrl: 'savings.editor.component.html'})
export class SavingsEditorComponent implements OnInit {
  currentUser: User;
  currentUserSubscription: Subscription;
  savingEditorForm: FormGroup;
  savingsDeposit: SavingsDeposit = new SavingsDeposit();

  submitted = false;
  loading = false;

  isCreateView = false;

  userNameEdited: string;

  constructor(
    private router: Router,
    private authService: AuthService,
    private savingsService: SavingsDepositService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private location: Location
) {
    this.currentUserSubscription = this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
    });
  }

  get formControl() { return this.savingEditorForm.controls; }

  ngOnInit() {

    this.savingEditorForm = this.formBuilder.group({
      id: [], // ['', Validators.required],
      bankName: new FormControl(this.savingsDeposit.bankName, [Validators.required]), // ['', Validators.required],
      accountNumber: ['', [Validators.required, Validators.pattern(/\d+/)]],
      taxPercentage: ['', [Validators.required, Validators.min(0), Validators.max(100)]],
      yearlyInterestPercentage: ['', [Validators.required, Validators.min(-100), Validators.max(100)]],
      initialAmount: ['', [Validators.required, Validators.pattern(/\d+/)]],
      startDate: ['', [Validators.required]],
      endDate: ['', [Validators.required]]

    });

    this.route.params.subscribe(params => {
      const savingId = params['savingsDeposit'];
      const user = params['userName'];

      this.userNameEdited = user;

      let serverRequest: Observable<SavingsDeposit>;

      if (savingId > 0) {
        // if user is set -> this is admin mode
        if (user) {
          serverRequest = this.savingsService.getSavingsDepositByUser(savingId, user);
        } else {
          serverRequest = this.savingsService.getSavingsDeposit(savingId);
        }

        serverRequest.subscribe(x => {
            this.savingsDeposit = x;
            this.savingEditorForm.patchValue(this.savingsDeposit);
          });

      } else {
        this.isCreateView = true;
        this.savingsDeposit.id = 0;
        this.savingsDeposit.bankName = '';
        this.savingEditorForm.patchValue(this.savingsDeposit);
      }
    });
  }


  goBack(): void {
    this.location.back();
  }

  createOwnRecord() {
      return this.savingsService.createSavingsDeposit(this.savingsDeposit);
  }

  createByAdmin() {
      return this.savingsService.createSavingsDepositForUser(this.userNameEdited, this.savingsDeposit);
  }

  onSubmit() {

    this.submitted = true;

    if (this.savingEditorForm.invalid) {
      return;
    }

    this.loading = true;

    const id = this.savingsDeposit.id;
    this.savingsDeposit = this.savingEditorForm.value;
    this.savingsDeposit.id = id;

    // editing record
    // same for admin and user manager
    if (this.savingsDeposit.id > 0) {
      this.savingsService.updateSavingsDeposit(this.savingsDeposit).pipe(first())
        .subscribe( x => {
            this.goBack();
          },
          error => {
          this.loading = false;
        });

    } else {

      // creating new record
      // depends which user is doing this
      let createObservable;
      if (this.userNameEdited) {
        createObservable = this.createByAdmin();
      } else {
        createObservable = this.createOwnRecord();
      }

      createObservable.pipe(first())
        .subscribe(
          next => { this.goBack(); },
          error => {this.loading = false; });
    }
  }

}
