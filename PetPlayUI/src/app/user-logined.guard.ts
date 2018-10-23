import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from './services/auth.service';

@Injectable()
export class UserLoginedGuard implements CanActivate {
  constructor(private authService: AuthService,
              private router: Router) {}

  canActivate() {

    if(this.authService.isUserLogined())
    {
       this.router.navigate(['/profile']);
       return false;
    }

    return true;
  }
}