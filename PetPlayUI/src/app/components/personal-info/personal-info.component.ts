import { Component, OnInit } from '@angular/core';
import { PetPlayService, UserModel } from 'src/app/services/petplay.service';
import { AuthService } from 'src/app/services/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { MyPetsComponent } from '../dialogs/my-pets/my-pets.component';

@Component({
  selector: 'app-personal-info',
  templateUrl: './personal-info.component.html',
  styleUrls: ['./personal-info.component.css']
})
export class PersonalInfoComponent implements OnInit {
  currentUser: UserModel;

  constructor(private apiService: PetPlayService, 
      private authService: AuthService,
      public dialog: MatDialog) { }

  ngOnInit() {
    this.apiService.apiUsersGetUserByIdGet(this.authService.getUserId()).subscribe(result => {
      this.currentUser = result;
      console.log(this.authService.getUserId())
    });
  }
  
  openMyPets = () => {
    const dialogRef = this.dialog.open(MyPetsComponent, {
      width: '500px',
      data: {
        userPets: this.currentUser.pets,
        userId: this.authService.getUserId()
      }
    });
  }

}
