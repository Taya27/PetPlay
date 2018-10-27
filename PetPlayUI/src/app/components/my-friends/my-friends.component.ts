import { Component, OnInit } from '@angular/core';
import { PetPlayService, UserModel, GrantedToyViewModel, ToyModel, AccessViewModel } from 'src/app/services/petplay.service';
import { FormControl } from '@angular/forms';
import {map, startWith} from 'rxjs/operators';
import { Observable } from 'rxjs';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { AuthService } from 'src/app/services/auth.service';
import { DeleteFriendGrantsComponent } from '../dialogs/delete-friend-grants/delete-friend-grants.component';
import { SelectToyToShareComponent } from '../dialogs/select-toy-to-share/select-toy-to-share.component';

@Component({
  selector: 'app-my-friends',
  templateUrl: './my-friends.component.html',
  styleUrls: ['./my-friends.component.css']
})
export class MyFriendsComponent implements OnInit {
  users: UserModel[] = [];
  shareToyError: string = "";

  selectedToy: ToyModel;
  optionToShow: string = "Select toy to share";
  myControl = new FormControl();
  filteredOptions: Observable<UserModel[]>;

  myToysGrants = new MatTableDataSource();
  displayedToysGrantsColumns: string[] = ['toyModel', 'friendName', 'delete'];
  toysGrants: GrantedToyViewModel[] = [];

  constructor(private apiService: PetPlayService,
              private authService: AuthService,
              private dialog: MatDialog) { }

  ngOnInit() {
    this.apiService.apiAccessesGetUserToyGrantsByUserIdGet(this.authService.getUserId()).subscribe(result => {
      this.toysGrants = result;
      this.myToysGrants.data = this.toysGrants;
    })

    this.apiService.apiUsersGetAllUsersGet().subscribe(result => {
      this.users = result.filter(x => x.id != this.authService.getUserId());
    });

    this.filteredOptions = this.myControl.valueChanges
      .pipe(
        startWith<string | UserModel>(''),
        map(value => typeof value === 'string' ? value : value.nickname),
        map(name => name ? this._filter(name) : this.users.slice())
      );
  }

  selectToy = () => {
    const dialogRef = this.dialog.open(SelectToyToShareComponent, {
      width: '800px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.selectedToy = result;
        this.optionToShow = result.model;
      }
    });
  }

  share = () => {
    if (!this.selectedToy || !this.myControl.value) {
      this.shareToyError = "Fill all fields, please";
      return;
    }

    if (!this.myControl.value.id) {
      this.shareToyError = "Please select user from autocomplete field";
      return;
    }

    this.shareToyError = "";

    const model = {
      toyId: this.selectedToy.id,
      userId: this.myControl.value.id,
      isOwner: false
    } as AccessViewModel;

    this.apiService.apiAccessesAddAccessPost(model).subscribe(result => {
      this.shareToyError = "";
      if (result === 'Access was granted!') {
        this.apiService.apiAccessesGetUserToyGrantsByUserIdGet(this.authService.getUserId()).subscribe(result => {
          this.toysGrants = result;
          this.myToysGrants.data = this.toysGrants;
        });
      }
    }, error => this.shareToyError = error);
  }

  deleteAccess = (toy, user) => {
    
    const dialogRef = this.dialog.open(DeleteFriendGrantsComponent, {
      data: {
        user: user,
        toyModel: toy.model
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.apiService.apiAccessesDeleteAccessByUserIdAndToyIdByUserIdByToyIdDelete(user.id, toy.id).subscribe(_ => {
          let index = this.toysGrants.findIndex(x => x.toy.id == toy.id && x.user.id == user.id);
          this.toysGrants.splice(index, 1);
          this.myToysGrants.data = this.toysGrants;
          this.myToysGrants._updateChangeSubscription();
        }, error => alert(error));
      }
    });
  }
 
  displayFn(user?: UserModel): string | undefined {
    return user ? "@" + user.nickname : undefined;
  }

  private _filter(name: string): UserModel[] {
    const filterValue = name.toLowerCase();
    this.selectedToy = undefined;
    this.optionToShow = "Select toy to share";
    this.shareToyError = "";

    return this.users.filter(option => option.nickname.toLowerCase().startsWith(filterValue));
  }
}
