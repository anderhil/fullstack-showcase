import { Routes, RouterModule } from '@angular/router';

import {LoginComponent} from './components/loginComponent/login.component';
import {RegisterComponent} from './components/registerComponent/register.component';
import {HomeComponent} from './components/homeComponent/home.component';
import {AuthenticationGuard} from './guards/AuthenticationGuard';
import {SavingsViewComponent} from './components/savingsDepositComponents/savings.view.component';
import {SavingsEditorComponent} from './components/savingsDepositComponents/savings.editor.component';
import {UsersViewComponent} from './components/userDetailsComponents/users.view.component';

const appRoutes: Routes = [
   { path: '', component: HomeComponent, canActivate: [AuthenticationGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'savingsView', component: SavingsViewComponent },
  { path: 'savingsEditor/:savingsDeposit', component: SavingsEditorComponent,
    children: [  { path: 'user/:userName', component: SavingsEditorComponent}] },
  { path: 'usersView', component: UsersViewComponent },
  { path: 'savingsView/:user', component: SavingsViewComponent },



  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
