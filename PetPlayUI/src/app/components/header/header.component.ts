import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  lang = "УКРАЇНСЬКА";

  constructor(public authService: AuthService,
    private router: Router,
    private translate: TranslateService) { }

  ngOnInit() {
  }

  changeLang = () => {
    if (this.lang === "УКРАЇНСЬКА") {
      this.lang = "ENGLISH";
      this.translate.use('ua');
    } else if (this.lang === "ENGLISH") {
      this.lang = "УКРАЇНСЬКА";
      this.translate.use('en');
    }
  }
  
  logOut = () => {
    this.authService.logOut();
    this.router.navigateByUrl('/login');
  }
}
