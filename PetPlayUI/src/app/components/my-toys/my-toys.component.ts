import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { PetPlayService, ToyModel, AccessModel, GrantedToyViewModel } from 'src/app/services/petplay.service';
import { RegisterToyDialogComponent } from '../dialogs/register-toy-dialog/register-toy-dialog.component';
import { HostListener } from '@angular/core';

@Component({
  selector: 'app-my-toys',
  templateUrl: './my-toys.component.html',
  styleUrls: ['./my-toys.component.css']
})
export class MyToysComponent implements OnInit {

  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === 'Escape') {
      this.selectedToy = undefined;
    }
  }

  myOwnToysSource = new MatTableDataSource();
  displayedOwnToysColumns: string[] = ['id', 'model'];

  myGrantedAccessesSource = new MatTableDataSource();
  displayedGrantedAccessesColumns: string[] = ['model', 'friendName'];
  
  ownUserToys: ToyModel[] = [];
  grantedUserAccesses: GrantedToyViewModel[] = [];
  selectedToy: ToyModel;

  constructor(private authService: AuthService,
    private petPlayService: PetPlayService,
    private dialog: MatDialog) {
     }

  ngOnInit() {
    this.petPlayService.apiAccessGetUserAccessesByUserIdGet(this.authService.getUserId())
      .subscribe(result => {
        for (let access of result) {
          if (access.isOwner)
            this.ownUserToys.push(access.toy);
        }
        this.myOwnToysSource.data = this.ownUserToys;
      }, error => {
        alert("An error occured!")
      });
    
    this.petPlayService.apiAccessGetUserGrantedToysByUserIdGet(this.authService.getUserId())
      .subscribe(result => {
        this.grantedUserAccesses = result;
        this.myGrantedAccessesSource.data = this.grantedUserAccesses;
      });
      
  }

  openToyRegister = () => {
    const dialogRef = this.dialog.open(RegisterToyDialogComponent, {
      width: '500px',
      data: {
        userId: this.authService.getUserId(),
        userToys: this.ownUserToys
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.ownUserToys.push(result);
        this.myOwnToysSource._updateChangeSubscription();
      }
    });
  }

  selectToy = (toy) => {
    this.selectedToy = toy;
  }

  selectGrantedToy = (grantedModel) => {
    this.selectedToy = grantedModel.toy;
  }
}
