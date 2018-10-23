import { Component, OnInit } from '@angular/core';
import { PetPlayService, LoginViewModel } from 'src/app/services/petplay.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public login: string = "";
  public password: string = "";

  constructor(private authService: AuthService,
    private router: Router) { }

  ngOnInit() {
  }

  logIn = () => {
    const loginModel = {
      login: this.login,
      password: this.password
    } as LoginViewModel;
    
    this.authService.login(loginModel).subscribe(result => {
      if (result) {
        this.router.navigateByUrl('/profile');
      }
    });
  }

  navigateToRegister = () => {
    this.router.navigateByUrl('/register');
  }
}
