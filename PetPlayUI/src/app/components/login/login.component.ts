import { Component, OnInit } from '@angular/core';
import { PetPlayService, LoginViewModel } from 'src/app/services/petplay.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public login: string = "";
  public password: string = "";

  constructor(private petplayService: PetPlayService) { }

  ngOnInit() {
  }

  logIn = () => {
    const loginModel = {
      login: this.login,
      password: this.password
    } as LoginViewModel;
    
    this.petplayService.apiUsersLoginPost(loginModel).subscribe(result => {
      alert(result);
    })
  }
}
