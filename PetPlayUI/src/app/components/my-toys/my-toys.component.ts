import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { PetPlayService, ToyModel } from 'src/app/services/petplay.service';
import { RegisterToyDialogComponent } from '../dialogs/register-toy-dialog/register-toy-dialog.component';

@Component({
  selector: 'app-my-toys',
  templateUrl: './my-toys.component.html',
  styleUrls: ['./my-toys.component.css']
})
export class MyToysComponent implements OnInit {
  dataSource = new MatTableDataSource();
  displayedColumns: string[] = ['id', 'model'];
  userToys: ToyModel[] = [];
  
  constructor(private authService: AuthService,
    private petPlayService: PetPlayService,
    private dialog: MatDialog) {
     }

  ngOnInit() {
    this.petPlayService.apiAccessGetUserAccessesByUserIdGet(this.authService.getUserId())
      .subscribe(result => {
        for (let access of result) {
          this.userToys.push(access.toy)
        }
        this.dataSource.data = this.userToys;
      }, error => {
        alert("An error occured!")
      });
  }

  openToyRegister = () => {
    const dialogRef = this.dialog.open(RegisterToyDialogComponent, {
      width: '500px',
      data: {
        userId: this.authService.getUserId(),
        userToys: this.userToys
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.userToys.push(result);
      this.dataSource._updateChangeSubscription();
    });
  }

}
