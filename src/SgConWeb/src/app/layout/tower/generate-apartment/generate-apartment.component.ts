import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { ActivatedRoute, Router } from '@angular/router';

// models
import { TowerModel } from '../../../shared/entities/tower.model';
import { CondominiumModel } from '../../../shared/entities/condominium.model';
import { GenerateApartment } from '../../../shared/entities/generate-apartment.model';

// services
import { TowerService } from '../../../shared/services/tower.service';
import { CondominiumService } from '../../../shared/services/condominium.service';

@Component({
  selector: 'app-generate-apartment',
  templateUrl: './generate-apartment.component.html',
  styleUrls: ['./generate-apartment.component.scss']
})
export class GenerateApartmentComponent implements OnInit {

  public generateForm: FormGroup;
  generateApartment: GenerateApartment = new GenerateApartment();
  listOfCondominium: CondominiumModel[] = new Array<CondominiumModel>();
  listOfTower: TowerModel[] = new Array<TowerModel>();

  constructor(
    private form: FormBuilder,
    private _towerService: TowerService,
    private _route: ActivatedRoute,
    private _condominiumService: CondominiumService,
    private _router: Router
  ) { }

  ngOnInit() {
    this.setDefaultValuesForm();

    this.getAllCondominium();
  }

  // check ngValidatos
  applyCss(field: string) {
    if (this.generateForm.get(field).valid && this.generateForm.get(field).touched) {
      return {
        'has-success': this.generateForm.get(field).valid && this.generateForm.get(field).touched,
        'has-feedback': this.generateForm.get(field).valid && this.generateForm.get(field).touched,
        'form-control-success': this.generateForm.get(field).valid && this.generateForm.get(field).touched
      };
    } else {
      return {
        'has-danger': !this.generateForm.get(field).valid && this.generateForm.get(field).touched,
        'has-feedback': !this.generateForm.get(field).valid && this.generateForm.get(field).touched,
        'form-control-danger': !this.generateForm.get(field).valid && this.generateForm.get(field).touched
      };
    }
  }

  setDefaultValuesForm() {
    this.generateForm = this.form.group({
      id: 0,
      active: true,
      createdAt: Date.now,
      updatedAt: Date.now,
      createdBy: null,
      updatedBy: null,
      condominiumId: [null, [Validators.required]],
      towerId: [null, [Validators.required]],
      quantityByFloor: [null, [Validators.required]],
      floor: [null, [Validators.required]]
    });
  }

  getAllCondominium() {

    this._condominiumService.getAllCondominium()
      .subscribe(response => {
        this.listOfCondominium = response;
      }, error => {
        console.log(error);
    })
  }

  getTowerByCondominiumId() {

    const condominiumId = this.generateForm.value.condominiumId;

    this._towerService.getTowerByCondominiumId(condominiumId)
      .subscribe(response => {
        this.listOfTower = response;
      }, error => {
        console.log(error);
    });
  }

  onSubmit() {

    this.generateApartment.condominiumId = this.generateForm.value.condominiumId;
    this.generateApartment.towerId = this.generateForm.value.towerId;
    this.generateApartment.floor = this.generateForm.value.floor;
    this.generateApartment.quantityByFloor = this.generateForm.value.quantityByFloor;

    this._towerService.generateApartment(this.generateApartment)
      .subscribe(response => {
        alert('Apartamentos gerados com sucesso!');

        this._router.navigate(['tower/towerList']);
      }, error => console.log(error));

  }

}
