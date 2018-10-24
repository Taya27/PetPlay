import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { MyPetsComponent } from '../my-pets/my-pets.component';
import { PetPlayService, AccessViewModel, ToyModel } from 'src/app/services/petplay.service';

@Component({
  selector: 'app-register-toy-dialog',
  templateUrl: './register-toy-dialog.component.html',
  styleUrls: ['./register-toy-dialog.component.css']
})
export class RegisterToyDialogComponent implements OnInit {
  toyId: string = "";
  userId: string = "";

  constructor(public dialogRef: MatDialogRef<MyPetsComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private apiService: PetPlayService) {
      this.userId = data.userId;  
    }

  ngOnInit() {
  }

  addNewToy = () => {
    const model: AccessViewModel = {
      userId: this.userId,
      toyId: this.toyId,
      isOwner: true
    };

    this.apiService.apiAccessAddAccessPost(model).subscribe(result => {
      if (result === "Access was granted!") {
        this.apiService
          .apiAccessGetAccessByUserIdAndToyIdByUserIdByToyIdGet(this.userId, this.toyId)
          .subscribe(result => {
            this.dialogRef.close(result.toy);
          });
      }
    })
  }
}
