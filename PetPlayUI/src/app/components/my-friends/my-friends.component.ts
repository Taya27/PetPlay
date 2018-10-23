import { Component, OnInit } from '@angular/core';
import { PetPlayService, UserModel } from 'src/app/services/petplay.service';
import { FormControl } from '@angular/forms';
import {map, startWith} from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-my-friends',
  templateUrl: './my-friends.component.html',
  styleUrls: ['./my-friends.component.css']
})
export class MyFriendsComponent implements OnInit {
  users: UserModel[] = [];

  myControl = new FormControl();
  filteredOptions: Observable<UserModel[]>;

  constructor(private apiService: PetPlayService) { }

  ngOnInit() {
    this.apiService.apiUsersGetAllUsersGet().subscribe(result => {
      this.users = result;
    });

    this.filteredOptions = this.myControl.valueChanges
      .pipe(
        startWith<string | UserModel>(''),
        map(value => typeof value === 'string' ? value : value.nickname),
        map(name => name ? this._filter(name) : this.users.slice())
      );
  }

  displayFn(user?: UserModel): string | undefined {
    return user ? user.nickname : undefined;
  }

  private _filter(name: string): UserModel[] {
    const filterValue = name.toLowerCase();

    return this.users.filter(option => option.nickname.toLowerCase().startsWith(filterValue));
  }

  test = () => {
    alert(this.myControl.value.Id)
  }
}
