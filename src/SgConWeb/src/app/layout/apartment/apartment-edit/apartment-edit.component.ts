import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

// modules
import { ApartmentModel } from '../../../shared/entities/apartment.model';
import { CondominiumModel } from '../../../shared/entities/condominium.model';
import { TowerModel } from '../../../shared/entities/tower.model';

// services
import { ApartmentService } from '../../../shared/services/apartment.service';
import { CondominiumService } from '../../../shared/services/condominium.service';
import { TowerService } from '../../../shared/services/tower.service';

@Component({
  selector: 'app-apartment-edit',
  templateUrl: './apartment-edit.component.html',
  styleUrls: ['./apartment-edit.component.scss']
})
export class ApartmentEditComponent implements OnInit {

  public apartmentForm: FormGroup;
  apartmentModel: ApartmentModel = new ApartmentModel();
  listOfCondominium: CondominiumModel[] = new Array<CondominiumModel>();
  listOfTower: TowerModel[] = new Array<TowerModel>();

  apartmentId: number;

  constructor(
    private form: FormBuilder,
    private _apartmentService: ApartmentService,
    private _route: ActivatedRoute,
    private _condominiumService: CondominiumService,
    private _towerService: TowerService,
    private _router: Router
  ) { }

  ngOnInit() {
    this.setDefaultValuesForm();

    this._route.params.subscribe(params => {
      if (params['id']) {
        this.apartmentId = +params['id'];
        this.getApartment(this.apartmentId);
      }
    });

    this.getAllCondominium();


  }
  // check ngValidatos
  applyCss(field: string) {
    if (this.apartmentForm.get(field).valid && this.apartmentForm.get(field).touched) {
      return {
        'has-success': this.apartmentForm.get(field).valid && this.apartmentForm.get(field).touched,
        // 'has-feedback': this.apartmentForm.get(field).valid && this.apartmentForm.get(field).touched,
        'form-control-success': this.apartmentForm.get(field).valid && this.apartmentForm.get(field).touched
      };
    } else {
      return {
        'has-danger': !this.apartmentForm.get(field).valid && this.apartmentForm.get(field).touched,
        // 'has-feedback': !this.apartmentForm.get(field).valid && this.apartmentForm.get(field).touched,
        'form-control-danger': !this.apartmentForm.get(field).valid && this.apartmentForm.get(field).touched
      };
    }
  }

  setDefaultValuesForm() {
    this.apartmentForm = this.form.group({
      id: 0,
      active: true,
      createdAt: Date.now,
      updatedAt: Date.now,
      createdBy: null,
      updatedBy: null,
      number: [null, [Validators.required, Validators.minLength(1)]],
      floor: [null, [Validators.required, Validators.minLength(1)]],
      towerId: [null, [Validators.required]],
      condominiumId: [null, [Validators.required]]
    });
  }

  populateForm(data: ApartmentModel) {
    this.apartmentForm.patchValue({
      id: data.id,
      active: data.active,
      createdAt: data.createdAt,
      updatedAt: data.updatedAt,
      createdBy: data.createdBy,
      updatedBy: data.updatedBy,
      number: data.number,
      floor: data.floor,
      condominiumId: data.tower.condominium.id,
      towerId: data.towerId
    });

    this.getTowerByCondominiumId();
  }

  onSubmit() {
    this.apartmentModel = this.apartmentForm.value;

    if (!this.apartmentId) {
      this.postApartment();
    } else {
      this.updateApartment();
    }
  }

  getApartment(id) {
    this._apartmentService.getApartmentById(id).subscribe(
      response => {
        this.apartmentModel = response;
        console.log(this.apartmentModel);
        this.populateForm(this.apartmentModel);
      },
      error => {
        console.log(error);
      }
    );
  }

  updateApartment() {
    this._apartmentService.updateApartment(this.apartmentModel, this.apartmentId)
      .subscribe( response => {
        this.apartmentModel = response;
        alert('Dados atualizados com sucesso');
        console.log(response);
        // Voltar página
        this._router.navigate(['apartment/apartmentList']);
      },
      error => {
        console.log(error);
      }
    );
  }

  deleteApartment() {
    this._apartmentService.deleteApartment(this.apartmentId).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }

  postApartment() {

    this._apartmentService.postApartment(this.apartmentModel).subscribe(
      response => {
        this.apartmentModel = response;
        // message success
        alert('Dados salvos com sucesso!');
        // Voltar página
        this._router.navigate(['apartment/apartmentList']);
      },
      error => {
        console.log(error);
      }
    );
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

    this._towerService.getTowerByCondominiumId(this.apartmentForm.value.condominiumId)
      .subscribe(response => {
        this.listOfTower = response;
      }, error => {
        console.log(error);
    });
  }
}
