import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { MatTableDataSource, MatDialog, MatSnackBar } from '@angular/material';
import { PetPlayService, ToyModel, GrantedToyViewModel, ConnectionModel } from 'src/app/services/petplay.service';
import { RegisterToyDialogComponent } from '../dialogs/register-toy-dialog/register-toy-dialog.component';
import { HostListener } from '@angular/core';
import { ToyConnectAdviceComponent } from '../dialogs/toy-connect-advice/toy-connect-advice.component';
import { Router } from '@angular/router';
import { DeleteToyComponent } from '../dialogs/delete-toy/delete-toy.component';

@Component({
  selector: 'app-my-toys',
  templateUrl: './my-toys.component.html',
  styleUrls: ['./my-toys.component.css']
})
export class MyToysComponent implements OnInit {
  currentUserId: string = "";
  myOwnToysSource = new MatTableDataSource();
  displayedOwnToysColumns: string[] = ['id', 'model', 'delete'];

  myGrantedAccessesSource = new MatTableDataSource();
  displayedGrantedAccessesColumns: string[] = ['model', 'friendName'];
  
  ownUserToys: ToyModel[] = [];
  grantedUserAccesses: GrantedToyViewModel[] = [];
  selectedToy: ToyModel;

  connectionError: string = "";

  constructor(private authService: AuthService,
              private petPlayService: PetPlayService,
              private dialog: MatDialog,
              private router: Router,
              private snackBar: MatSnackBar) {}

  ngOnInit() {
    this.currentUserId = this.authService.getUserId();
    this.petPlayService.apiAccessesGetUserAccessesByUserIdGet(this.currentUserId)
      .subscribe(result => {
        this.ownUserToys = result
          .filter(x => x.isOwner)
          .map(x => x.toy);
          
        this.myOwnToysSource.data = this.ownUserToys;
      }, error => {
        alert("An error occured!")
      });
    
    this.petPlayService.apiAccessesGetUserGrantedToysByUserIdGet(this.currentUserId)
      .subscribe(result => {
        this.grantedUserAccesses = result;
        this.myGrantedAccessesSource.data = this.grantedUserAccesses;
      });
  }

  openToyRegister = () => {
    const dialogRef = this.dialog.open(RegisterToyDialogComponent, {
      width: '500px',
      data: {
        userId: this.currentUserId,
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
    const snackRef = this.snackBar
      .open("You have selected " + toy.model + ". To undo this action press Escape", "Click me to connect");

    snackRef.onAction().subscribe(_ => {
        this.connectToToy();
    });
  }

  selectGrantedToy = (grantedModel) => {
    this.selectedToy = grantedModel.toy;

    const snackRef = this.snackBar
      .open("You have selected " + grantedModel.toy.model + ". To undo this action press Escape", "Click me to connect");

    snackRef.onAction().subscribe(_ => {
        this.connectToToy();
    });
  }

  deleteToy = (toyId) => {
    const dialogRef = this.dialog.open(DeleteToyComponent, {
      width: '500px',
    })

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.petPlayService.apiAccessesDeleteAccessByUserIdAndToyIdByUserIdByToyIdDelete(this.currentUserId, toyId)
        .subscribe(_ => {
          const index = this.ownUserToys.findIndex(x => x.id === toyId);
          this.ownUserToys.splice(index, 1);
          this.myOwnToysSource.data = this.ownUserToys;
          this.myOwnToysSource._updateChangeSubscription();
        }, error => {});
      }
    });
  }

  connectToToy = () => {
    this.connectionError = "";

    if (!this.selectedToy) {
      this.dialog.open(ToyConnectAdviceComponent, {
        width: '600px'
      });
      return;
    }

    this.petPlayService.apiConnectionsAddConnectionPost({
      toyId: this.selectedToy.id,
      userId: this.currentUserId      
    } as ConnectionModel).subscribe(result => {
      this.router.navigateByUrl('/toy-connection');
    }, error => {
      this.connectionError = error;
    });
  }

  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === 'Escape') {
      this.selectedToy = undefined;
    }
  }
}
