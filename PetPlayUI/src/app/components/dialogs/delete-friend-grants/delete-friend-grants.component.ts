import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-delete-friend-grants',
  templateUrl: './delete-friend-grants.component.html',
  styleUrls: ['./delete-friend-grants.component.css']
})
export class DeleteFriendGrantsComponent implements OnInit {
  userName: string = "";
  toyModel: string = "";
  
  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef < DeleteDialogComponent > ) {
      const user = data.user;
      this.userName = user.firstName + " " + user.lastName + "'s";
      this.toyModel = data.toyModel;
  }

  ngOnInit() {
  }

  close() {
    this.dialogRef.close(true);
  }
}
