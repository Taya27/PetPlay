import { Component, OnInit } from '@angular/core';
import { PetPlayService, ConnectionModel } from 'src/app/services/petplay.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-toy-connection',
  templateUrl: './toy-connection.component.html',
  styleUrls: ['./toy-connection.component.css']
})
export class ToyConnectionComponent implements OnInit {
  private userId: string = "";
  currentConnection: ConnectionModel;

  constructor(private petService: PetPlayService,
              private authService: AuthService) { }

  ngOnInit() {
    this.userId = this.authService.getUserId();

    this.petService.apiConnectionsGetUserConnectionByUserIdGet(this.userId)
      .subscribe(result => {
        if (result) {
          this.currentConnection = result;
        }
      }, error => {
       // alert(error); You are currently not connected to any toy. But you can do it in your personal account
      })
  }

  disconnect = () => {
    this.petService.apiConnectionsDisconnectByToyIdPut(this.currentConnection.toyId)
      .subscribe(_ => {
        this.currentConnection = undefined;
      }, error => alert(error));
  }
}
