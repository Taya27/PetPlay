import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router';

import { AppComponent } from './app.component';
import { PetPlayService, API_BASE_URL } from './services/petplay.service';
import { environment } from 'src/environments/environment';
import { HeaderComponent } from './components/header/header.component';
import { LoginComponent } from './components/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutes } from './app.routes';
import { MainComponent } from './components/main/main.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { RegisterComponent, SnackBarComponent } from './components/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    MainComponent,
    AboutUsComponent,
    ContactsComponent,
    RegisterComponent,
    SnackBarComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(AppRoutes),
    FormsModule,
    MatInputModule,
    MatButtonModule,
    MatSnackBarModule,
    LoadingBarHttpClientModule,
    LoadingBarRouterModule
  ],
  providers: [
    { provide: API_BASE_URL, useValue: environment.API_BASE_URL},
    PetPlayService
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    SnackBarComponent
  ]
})
export class AppModule { }
