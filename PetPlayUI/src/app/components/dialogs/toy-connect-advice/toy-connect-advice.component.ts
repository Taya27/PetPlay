import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-toy-connect-advice',
  templateUrl: './toy-connect-advice.component.html',
  styleUrls: ['./toy-connect-advice.component.css']
})
export class ToyConnectAdviceComponent implements OnInit {

  constructor(private matDialogRef: MatDialogRef<ToyConnectAdviceComponent>) { }

  ngOnInit() {
  }

  exit = () => {
    this.matDialogRef.close();
  }
}
