import { Component, OnInit } from '@angular/core';
import { PetPlayService, ToyModel, ToyViewModel } from 'src/app/services/petplay.service';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  panelOpenState = true;
  myOwnToysSource = new MatTableDataSource();
  displayedOwnToysColumns: string[] = ['id', 'model', 'qr', 'isOwned'];
  toyName: string = "";

  constructor(private api: PetPlayService) { }

  ngOnInit() {
    this.api.apiToysGetAllToysGet().subscribe(result => {
      console.log(result);
      
      this.myOwnToysSource.data = result;
    });
  }

  addToy = () => {
    this.api.apiToysAddToyPost({model: this.toyName} as ToyViewModel)
      .subscribe(result => {        
        this.myOwnToysSource.data.push(result);
        this.myOwnToysSource._updateChangeSubscription();
      })
  }

  watchQr = (url) => {
    window.open(url, '_blank');
  }
}
