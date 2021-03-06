import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute, Data} from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import {AuthService} from '../../services/auth.service';
import {ReportingService} from '../../services/reporting.service';
import {DateRangeReport} from '../../models/dateRangeReport';
import {DepositReport} from '../../models/depositReport';
import {NotifyService} from '../../services/notify.service';
import {errorObject} from 'rxjs/internal-compatibility';


@Component({templateUrl: 'report.component.html', styleUrls: ['report.component.css']})
export class ReportComponent implements OnInit {
  reportForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;


  startDate: Date;
  endDate: Date;

  dateRangeReport: DateRangeReport;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private reportingService: ReportingService,
    private notifier: NotifyService
  ) {
  }

  ngOnInit() {
    this.reportForm = this.formBuilder.group({
      startDate: ['', Validators.required],
      endDate: ['', Validators.required]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  genereateReport() {
    this.startDate = this.formControl.startDate.value;
    this.endDate = this.formControl.endDate.value;
    this.reportingService.generateReport(this.startDate, this.endDate)
      .subscribe(data => {
        this.dateRangeReport = data;
    }, error => {
        this.notifier.error(error);
      });
  }

  get formControl() { return this.reportForm.controls; }

  // onSubmit() {
  //   this.submitted = true;
  //
  //   if (this.reportForm.invalid) {
  //     return;
  //   }
  //
  //   this.loading = true;
  // }
}
