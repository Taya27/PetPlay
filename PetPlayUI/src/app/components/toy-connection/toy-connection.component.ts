import { Component, OnInit, HostListener } from '@angular/core';
import { PetPlayService, ConnectionModel, LedQueryInfo } from 'src/app/services/petplay.service';
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

  sendSignal = () => {
    this.petService.apiRemoteTurnOnRingPost(2).subscribe();
  }

  upState = 0;
  downState = 0;
  leftState = 0;
  rightState = 0;

  toyRun = (direction: number, state?: number) => {
    let dir = direction as Direction;
    let ledInfo = {led: direction} as LedQueryInfo;

    if (dir == Direction.Up) {
      if (this.upState == 0) {
        ledInfo.state = 1;
        this.upState = 1;
      }
      else {
        ledInfo.state = 0;
        this.upState = 0;
      }
    }
    else if (dir == Direction.Down) {
      if (this.downState == 0) {
        ledInfo.state = 1;
        this.downState = 1;
      }
      else {
        ledInfo.state = 0;
        this.downState = 0;
      }
    }
    else if (dir == Direction.Right) {
      if (this.rightState == 0) {
        ledInfo.state = 1;
        this.rightState = 1;
      }
      else {
        ledInfo.state = 0;
        this.rightState = 0;
      }
    }
    else if (dir == Direction.Left) {
      if (this.leftState == 0) {
        ledInfo.state = 1;
        this.leftState = 1;
      }
      else {
        ledInfo.state = 0;
        this.leftState = 0;
      }
    }

    if (state) ledInfo.state = state;

    this.petService.apiRemoteSetStatePost(ledInfo).subscribe();
  }

  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key == "ArrowUp") {
      if (this.upState == 1) return;
      this.toyRun(Direction.Up, 1);
    } else if (event.key == "ArrowRight") {
      if (this.rightState == 1) return;
      this.toyRun(Direction.Right, 1);
    } else if (event.key == "ArrowDown") {
      if (this.downState == 1) return;
      this.toyRun(Direction.Down, 1);
    } else if (event.key == "ArrowLeft") {
      if (this.leftState == 1) return;
      this.toyRun(Direction.Left, 1);
    }
  }

  @HostListener('window:keyup', ['$event'])
  handleKeyUp(event: KeyboardEvent) {
    if (event.key == "ArrowUp") {
      if (this.upState == 0) return;
      this.toyRun(Direction.Up, 0);
    } else if (event.key == "ArrowRight") {
      if (this.rightState == 0) return;
      this.toyRun(Direction.Right, 0);
    } else if (event.key == "ArrowDown") {
      if (this.downState == 0) return;
      this.toyRun(Direction.Down, 0);
    } else if (event.key == "ArrowLeft") {
      if (this.leftState == 0) return;
      this.toyRun(Direction.Left, 0);
    }
  }
}

enum Direction {
  Up = 10,
  Down = 5,
  Left = 3,
  Right = 9,
}