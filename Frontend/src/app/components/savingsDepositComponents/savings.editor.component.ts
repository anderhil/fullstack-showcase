import {Component, Input, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { first } from 'rxjs/operators';
import {AuthService} from '../../services/auth.service';
import {SavingsDepositService} from '../../services/savingsDeposits.service';
import {User} from '../../models/user';
import {SavingsDeposit} from '../../models/savingsDeposit';
import {Subscription} from 'rxjs';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({templateUrl: 'savings.editor.component.html'})
export class SavingsEditorComponent implements OnInit {
  currentUser: User;
  currentUserSubscription: Subscription;
  savingEditorForm: FormGroup;
  savingsDeposit: SavingsDeposit = new SavingsDeposit();


  constructor(
    private router: Router,
    private authService: AuthService,
    private savingsService: SavingsDepositService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder
  ) {
    this.currentUserSubscription = this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
    });
  }


  get formControl() { return this.savingEditorForm.controls; }

  ngOnInit() {
    this.savingEditorForm = this.formBuilder.group({
      bankName: ['', Validators.required],
      accountNumber: ['', [Validators.required, Validators.pattern('\d+')]],
      taxPercentage: ['', [Validators.required, Validators.min(0), Validators.max(100)]],
      yearlyInterestPercentage: ['', [Validators.required, Validators.min(-100), Validators.max(100)]],
      initialAmount: ['', [Validators.required, Validators.pattern('\d+')]],
      startDate: ['', [Validators.required]],
      endDate: ['', [Validators.required]]

    });
    this.route.params.subscribe(params => {
      const savingId = params['savingsDeposit'];
      this.savingsService.getSavingsDeposit(savingId).subscribe(x => {
        this.savingsDeposit = x;
      });
    });
  }

  onSubmit() {
  }

}
