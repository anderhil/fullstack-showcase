import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import {AuthService} from '../services/auth.service';


@Injectable({ providedIn: 'root' })
export class AuthenticationGuard implements CanActivate {
  constructor(
    private router: Router,
    private authService: AuthService
  ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
   const currentUser = this.authService.currentUserValue;
    if (currentUser) {
      return true;
    }

    // not logged
    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
    return false;
  }
}
