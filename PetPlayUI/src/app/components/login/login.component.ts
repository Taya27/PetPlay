import { Component, OnInit, HostListener } from '@angular/core';
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
  errorText: string = "";

  constructor(private authService: AuthService,
    private router: Router) { }

  ngOnInit() {
  }

  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === 'Enter') {
      this.logIn();
    }
  }

  logIn = () => {
    if (!this.login || !this.password) {
      this.errorText = "Fill all fields, please";
      return;
    }

    this.errorText = "";
    const loginModel = {
      login: this.login,
      password: this.password
    } as LoginViewModel;
    
    this.authService.login(loginModel).subscribe(result => {
      if (result) {
        this.router.navigateByUrl(result);
      }
    }, error => this.errorText = "Invalid password or user");
  }

  navigateToRegister = () => {
    this.router.navigateByUrl('/register');
  }
}
