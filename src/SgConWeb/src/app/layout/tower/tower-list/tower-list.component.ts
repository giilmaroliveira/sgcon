import { Component, OnInit } from '@angular/core';

// service
import { TowerService } from '../../../shared/services/tower.service';

// models
import { TowerModel } from '../../../shared/entities/tower.model';

@Component({
  selector: 'app-tower-list',
  templateUrl: './tower-list.component.html',
  styleUrls: ['./tower-list.component.scss']
})
export class TowerListComponent implements OnInit {
  towerList: TowerModel[] = new Array<TowerModel>();

  constructor(private _towerService: TowerService) { }

  ngOnInit() {
    this.getAllTower();
  }
  getAllTower() {
    this._towerService.getAllTower().subscribe(
      response => {
        this.towerList = response;
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }
}
