import { Component, OnInit } from '@angular/core';
import { PetPlayService, ToyModel } from 'src/app/services/petplay.service';
import { MatTableDataSource, MatDialogRef } from '@angular/material';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-select-toy-to-share',
  templateUrl: './select-toy-to-share.component.html',
  styleUrls: ['./select-toy-to-share.component.css']
})
export class SelectToyToShareComponent implements OnInit {
  currentUserId: string = "";
  selectedToy: ToyModel;

  myOwnToysSource = new MatTableDataSource();
  displayedOwnToysColumns: string[] = ['id', 'model'];
  ownUserToys: ToyModel[] = [];

  constructor(private apiService: PetPlayService,
              private authService: AuthService,
              private dialogRef: MatDialogRef<SelectToyToShareComponent>) { }

  ngOnInit() {
    this.currentUserId = this.authService.getUserId();
    this.apiService.apiAccessesGetUserAccessesByUserIdGet(this.currentUserId)
      .subscribe(result => {
        this.ownUserToys = result
          .filter(x => x.isOwner)
          .map(x => x.toy);
        
        this.myOwnToysSource.data = this.ownUserToys;
      }, error => {
        alert("An error occured!")
      });
  }

  selectToy = (toy) => {
    this.selectedToy = toy;
  }

  shareToy = () => {
    if (!this.selectedToy) return;

    this.dialogRef.close(this.selectedToy);
  }

  exit = () => {
    this.dialogRef.close();
  }
}
