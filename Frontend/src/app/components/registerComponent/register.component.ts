import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormControl, FormGroup, ValidationErrors, Validators} from '@angular/forms';
import { first } from 'rxjs/operators';
import {AuthService} from '../../services/auth.service';
import {UserService} from '../../services/user.service';
import {el} from '@angular/platform-browser/testing/src/browser_util';
import { Location } from '@angular/common';

@Component({templateUrl: 'register.component.html', styleUrls: ['./register.component.css']})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;
  errorMessage = '';
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private userService: UserService,
    private location: Location
  ) {
    if (this.authService.currentUserValue) {
      if (this.authService.currentUserValue.role.toLowerCase() !== 'admin') {
        this.router.navigate(['/']);
      }
    }
  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', [Validators.required]],
      email: ['', [Validators.required]],
    });
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
    const user = this.registerForm.value;
    this.userService.register(user)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['/login']);
        },
        error => {
          this.loading = false;
          const message = error.error.error;
          if (message.includes('Password')) {
            this.formControl.password.setErrors({'passwordError': message});
          } else {
            this.errorMessage = message;
          }

        });
  }
}
