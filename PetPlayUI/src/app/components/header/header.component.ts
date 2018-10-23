import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(public authService: AuthService,
    private router: Router) { }

  ngOnInit() {
  }

  logOut = () => {
    this.authService.logOut();
    this.router.navigateByUrl('/login');
  }
}
