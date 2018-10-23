import { Injectable } from '@angular/core';
import { PetPlayService, RegistrationViewModel, LoginViewModel } from './petplay.service';
import { map } from 'rxjs/operators';
import { Http, Headers, Jsonp } from '@angular/http';
import { environment } from '../../environments/environment';

const TOKEN = "AUTH_TOKEN";
const USER_ID = "USER_ID";
const API_URL = environment.API_BASE_URL;

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLogined: boolean = false;
  private userId: string = "";

  constructor(private apiService: PetPlayService, private http: Http) { 
    this.isLogined = !!this.getToken();

    if (this.isLogined) {
      this.userId = localStorage.getItem(USER_ID);
    }
  }

  public isUserLogined(): boolean {
    return this.isLogined;
  }
  
  public getUserId = () => this.userId;

  public logOut() {
    localStorage.removeItem(TOKEN);
    localStorage.removeItem(USER_ID);
    this.isLogined = false;
  }

  public getToken(): string {
    return localStorage.getItem(TOKEN);
  }

  register = (model: RegistrationViewModel) => {
    return this.apiService.apiAuthRegisterPost(model);
  }

  login = (model: LoginViewModel) => {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');

    return this.http.post(API_URL + '/api/auth/login', JSON.stringify(model), {
        headers
      })
      .pipe(
        map(res => res.json()),
        map(res => {
          this.isLogined = true;
          this.userId = res.user_id;
          localStorage.setItem(TOKEN, res.auth_token);
          localStorage.setItem(USER_ID, res.user_id);
          return true;
        })
      );
  }
}
