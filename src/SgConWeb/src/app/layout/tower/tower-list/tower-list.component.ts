import { Component, OnInit } from '@angular/core';

// service
import { TowerService } from '../../../shared/services/tower.service';

// models
import { TowerModel } from '../../../shared/entities/tower.model';
import { CondominiumModel } from '../../../shared/entities/condominium.model';
import { CondominiumService } from '../../../shared/services/condominium.service';

@Component({
  selector: 'app-tower-list',
  templateUrl: './tower-list.component.html',
  styleUrls: ['./tower-list.component.scss']
})
export class TowerListComponent implements OnInit {
  towerList: TowerModel[] = new Array<TowerModel>();
  listOfCondominium: CondominiumModel[] = new Array<CondominiumModel>();
  condominiumId: number;

  constructor(
    private _towerService: TowerService,
    private _condominiumService: CondominiumService
  ) {}

  ngOnInit() {
    this.getAllCondominium();
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

  getAllCondominium() {
    this._condominiumService.getAllCondominium().subscribe(
      response => {
        this.listOfCondominium = response;
      },
      error => {
        console.log(error);
      }
    );
  }
}
