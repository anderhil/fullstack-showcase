import { Routes, RouterModule } from '@angular/router';

import {LoginComponent} from './components/loginComponent/login.component';
import {RegisterComponent} from './components/registerComponent/register.component';
import {HomeComponent} from './components/homeComponent/home.component';
import {AuthenticationGuard} from './guards/AuthenticationGuard';

const appRoutes: Routes = [
   { path: '', component: HomeComponent, canActivate: [AuthenticationGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
