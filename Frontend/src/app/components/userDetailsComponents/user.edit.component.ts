import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {FormBuilder, FormGroup, ValidationErrors, Validators} from '@angular/forms';
import { first } from 'rxjs/operators';
import {AuthService} from '../../services/auth.service';
import {UserService} from '../../services/user.service';
import {el} from '@angular/platform-browser/testing/src/browser_util';
import { Location } from '@angular/common';
import {User} from '../../models/user';

@Component({templateUrl: 'user.edit.component.html', styleUrls: ['./user.edit.component.css']})
export class UserEditComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;
  errorMessage = '';
  user: User;

  roles = ['user', 'manager', 'admin'];
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private userService: UserService,
    private location: Location
  ) {}

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      username: ['', Validators.required],
      role: ['', [Validators.required]],
      email: ['', [Validators.required]],
    });
    this.route.params.subscribe(params => {
      const user = params['user'];
      this.userService.getByUserName(user).subscribe(x => {
        this.user = x;
        this.registerForm.patchValue(this.user);
      });
    });
  }

  isInRole(role: string) {
    return role === this.user.role.toLowerCase();
  }

  get formControl() { return this.registerForm.controls; }

  get isError(): boolean {
    return !(this.errorMessage === '');
  }

  goBack(): void {
    this.location.back();
  }

  onSubmit() {
    this.errorMessage = '';
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    this.loading = true;
    this.userService.update(this.registerForm.value)
      .pipe(first())
      .subscribe(
        data => {
          this.location.back();
        },
        error => {
          this.loading = false;
          const message = error.error.error;
          this.errorMessage = message;
        });
  }
}
