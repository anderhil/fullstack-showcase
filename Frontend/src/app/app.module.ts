import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {routing} from './app.routing';
import {LoginComponent} from './components/loginComponent/login.component';
import {ReactiveFormsModule} from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {RegisterComponent} from './components/registerComponent/register.component';
import {HomeComponent} from './components/homeComponent/home.component';
import {SavingsViewComponent} from './components/savingsDepositComponents/savings.view.component';
import {SavingsEditorComponent} from './components/savingsDepositComponents/savings.editor.component';
import {LoggerModule, NgxLoggerLevel} from 'ngx-logger';
import {UsersViewComponent} from './components/userDetailsComponents/users.view.component';
import {UsersEditorComponent} from './components/userDetailsComponents/users.editor.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    SavingsViewComponent,
    SavingsEditorComponent,
    UsersViewComponent,
    UsersEditorComponent
  ],
  imports: [
    BrowserModule,
    routing,
    ReactiveFormsModule,
    HttpClientModule,
    LoggerModule.forRoot({disableConsoleLogging: false, level: NgxLoggerLevel.DEBUG, serverLogLevel: NgxLoggerLevel.DEBUG})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
