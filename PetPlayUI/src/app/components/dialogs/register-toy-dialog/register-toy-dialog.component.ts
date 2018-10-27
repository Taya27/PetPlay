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
  errorText: string = "";

  constructor(public dialogRef: MatDialogRef<MyPetsComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private apiService: PetPlayService) {
      this.userId = data.userId;  
    }

  ngOnInit() {
  }

  addNewToy = () => {
    if (!this.isGuid(this.toyId)) {
      this.errorText = "Invalid toy id format";
      return;
    }
    this.errorText = "";

    const model: AccessViewModel = {
      userId: this.userId,
      toyId: this.toyId,
      isOwner: true
    };

    this.apiService.apiAccessesAddAccessPost(model).subscribe(result => {
      if (result === "Access was granted!") {
        this.apiService
          .apiAccessesGetAccessByUserIdAndToyIdByUserIdByToyIdGet(this.userId, this.toyId)
          .subscribe(result => {
            this.dialogRef.close(result.toy);
          });
      }
    }, error => this.errorText = error)
  }

  exit = () => {
    this.dialogRef.close();
  }

  isGuid(stringToTest) {
    if (stringToTest[0] === "{") {
        stringToTest = stringToTest.substring(1, stringToTest.length - 1);
    }
    const regexGuid = /^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$/gi;
    return regexGuid.test(stringToTest);
}
}
