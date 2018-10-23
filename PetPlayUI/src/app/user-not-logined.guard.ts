import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from './services/auth.service';

@Injectable()
export class UserNotLoginedGuard implements CanActivate {
  constructor(private authService: AuthService,
              private router: Router) {}

  canActivate() {

    if(!this.authService.isUserLogined())
    {
       this.router.navigate(['/login']);
       return false;
    }

    return true;
  }
}