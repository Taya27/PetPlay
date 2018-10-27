import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-delete-toy',
  templateUrl: './delete-toy.component.html',
  styleUrls: ['./delete-toy.component.css']
})
export class DeleteToyComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef < DeleteToyComponent > ) {
  }

  ngOnInit() {
  }

  close() {
    this.dialogRef.close(true);
  }

}
