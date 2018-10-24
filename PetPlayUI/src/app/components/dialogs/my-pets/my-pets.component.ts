import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, MatDialog } from '@angular/material';
import { PetModel, AddNewPetViewModel, PetPlayService } from 'src/app/services/petplay.service';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-my-pets',
  templateUrl: './my-pets.component.html',
  styleUrls: ['./my-pets.component.css']
})
export class MyPetsComponent implements OnInit {
  pets: PetModel[] = [];
  dataSource = new MatTableDataSource();
  userId: string = "";
  displayedColumns: string[] = ['nickname', 'breed', 'kind', 'delete'];

  nickname: string = "";
  breed: string = "";
  kind: string = "";

  constructor(
    public dialogRef: MatDialogRef<MyPetsComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private apiService: PetPlayService,
    public dialog: MatDialog) {
      this.pets = data.userPets;
      this.dataSource.data = data.userPets;
      this.userId = data.userId;
    }

  ngOnInit() {
  }

  addNewPet = () => {
    const model = {
      nickname: this.nickname,
      breed: this.breed,
      kind: this.kind,
      userId: this.userId
    } as AddNewPetViewModel;

    this.apiService.apiPetsAddPetPost(model).subscribe(result => {
      //this.dataSource.data.push(result);
      this.pets.push(result);
      this.dataSource._updateChangeSubscription();
      this.nickname = "";
      this.breed = "";
    });
  }

  deletePet = (id: string) => {
    const deleteDialogRef = this.dialog.open(DeleteDialogComponent, {});

    deleteDialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.apiService.apiPetsDeletePetByPetIdDelete(id).subscribe(result => {
          const index = this.pets.findIndex(x => x.id == result.id);
    
          this.pets.splice(index, 1);
          this.dataSource.data = this.pets;
          this.dataSource._updateChangeSubscription();
        });
      }
    })
    
  }

  close = () => {
    this.dialogRef.close();
  }
}
