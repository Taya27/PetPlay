import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule}  from '@angular/material/expansion';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import {MatAutocompleteModule} from '@angular/material/autocomplete';

import { AppComponent } from './app.component';
import { PetPlayService, API_BASE_URL } from './services/petplay.service';
import { environment } from 'src/environments/environment';
import { HeaderComponent } from './components/header/header.component';
import { LoginComponent } from './components/login/login.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutes } from './app.routes';
import { MainComponent } from './components/main/main.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { RegisterComponent, SnackBarComponent } from './components/register/register.component';
import { AuthService } from './services/auth.service';
import { AuthInterceptor } from './auth.interceptor';
import { ProfileComponent } from './components/profile/profile.component';
import { UserLoginedGuard } from './user-logined.guard';
import { UserNotLoginedGuard } from './user-not-logined.guard';
import { HttpModule } from '@angular/http';
import { PersonalInfoComponent } from './components/personal-info/personal-info.component';
import { MyPetsComponent } from './components/dialogs/my-pets/my-pets.component';
import { DeleteDialogComponent } from './components/dialogs/delete-dialog/delete-dialog.component';
import { MyFriendsComponent } from './components/my-friends/my-friends.component';
import { MyToysComponent } from './components/my-toys/my-toys.component';
import { RegisterToyDialogComponent } from './components/dialogs/register-toy-dialog/register-toy-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    MainComponent,
    AboutUsComponent,
    ContactsComponent,
    RegisterComponent,
    SnackBarComponent,
    ProfileComponent,
    PersonalInfoComponent,
    MyPetsComponent,
    DeleteDialogComponent,
    MyFriendsComponent,
    MyToysComponent,
    RegisterToyDialogComponent
  ],
  imports: [
    HttpClientModule,
    HttpModule,
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(AppRoutes),
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatSnackBarModule,
    LoadingBarHttpClientModule,
    LoadingBarRouterModule,
    MatExpansionModule,
    MatCardModule,
    MatDialogModule,
    MatTableModule,
    MatAutocompleteModule
  ],
  providers: [
    { provide: API_BASE_URL, useValue: environment.API_BASE_URL},
    PetPlayService,
    UserLoginedGuard,
    UserNotLoginedGuard,
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    SnackBarComponent,
    MyPetsComponent,
    RegisterToyDialogComponent,
    DeleteDialogComponent
  ]
})
export class AppModule { }
