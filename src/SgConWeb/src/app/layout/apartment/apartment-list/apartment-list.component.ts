import { Component, OnInit } from '@angular/core';

// service
import { ApartmentService } from './../../../shared/services/apartment.service';
import { CondominiumService } from './../../../shared/services/condominium.service';
import { TowerService } from './../../../shared/services/tower.service';

// models
import { ApartmentModel } from './../../../shared/entities/apartment.model';
import { CondominiumModel } from './../../../shared/entities/condominium.model';
import { TowerModel } from './../../../shared/entities/tower.model';

@Component({
  selector: 'app-apartment-list',
  templateUrl: './apartment-list.component.html',
  styleUrls: ['./apartment-list.component.scss']
})
export class ApartmentListComponent implements OnInit {

  listOfApartment: ApartmentModel[] = new Array<ApartmentModel>();
  listOfCondominium: CondominiumModel[] = new Array<CondominiumModel>();
  listOfTower: TowerModel[] = new Array<TowerModel>();
  condominiumId: number;
  towerId: number;

  constructor(
    private _towerService: TowerService,
    private _condominiumService: CondominiumService,
    private _apartmentService: ApartmentService
  ) { }

  ngOnInit() {
    this.getAllCondominium();
  }

  getAllCondominium() {
    this._condominiumService.getAllCondominium().subscribe(
      response => {
        this.listOfCondominium = response;
      }, error => {
        console.log(error);
      });
  }

  getTowerByCondominiumId() {

    this._towerService.getTowerCondominiumId(this.condominiumId)
      .subscribe(response => {
        this.listOfTower = response;
      }, error => {
        console.log(error);
      });
  }

  getApartmentByTowerId() {
    console.log('busca apartamentos');
    this._apartmentService.getApartmentTowerId(this.towerId)
    .subscribe(response => {
      this.listOfApartment = response;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }
}
