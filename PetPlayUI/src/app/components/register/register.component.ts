import { Component, OnInit } from '@angular/core';
import { PetPlayService, RegistrationViewModel } from 'src/app/services/petplay.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  email: string;
  password: string;
  confirmPassword: string;
  nickname: string;
  firstName: string;
  lastName: string;

  constructor(private authService: AuthService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  register = () => {
    const model = {
      email: this.email,
      password: this.password,
      nickname: this.nickname,
      firstName: this.firstName,
      lastName: this.lastName
    } as RegistrationViewModel;

    this.authService.register(model).subscribe(_ => {
      this.openSnackBar();
    }, error => {
      alert("An error occured!");
    });
  }

  openSnackBar(): void {
    this.snackBar.openFromComponent(SnackBarComponent, {
      duration: 2000,
    });
  }
}

@Component({
  selector: 'snack-bar-component',
  template: 'You have succesfully registered! <a class="example-pizza-party" (click)="navigate()">Go to login</a>',
  styles: [`
    .example-pizza-party {
      color: hotpink;
      cursor: pointer;
    }
  `],
})
export class SnackBarComponent {
  constructor(private router: Router) {}

  navigate = () => {
    this.router.navigateByUrl("/login");
  }
}
