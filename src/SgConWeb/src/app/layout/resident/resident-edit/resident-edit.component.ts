import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

// service
import { ResidentService } from './../../../shared/services/resident.service';
import { TowerService } from '../../../shared/services/tower.service';
import { CondominiumService } from '../../../shared/services/condominium.service';
import { ApartmentService } from '../../../shared/services/apartment.service';

// models
import { ResidentModel } from './../../../shared/entities/resident.model';
import { TowerModel } from '../../../shared/entities/tower.model';
import { CondominiumModel } from '../../../shared/entities/condominium.model';
import { ApartmentModel } from '../../../shared/entities/apartment.model';

@Component({
  selector: 'app-resident-edit',
  templateUrl: './resident-edit.component.html',
  styleUrls: ['./resident-edit.component.scss']
})
export class ResidentEditComponent implements OnInit {

  public residentForm: FormGroup;
  residentModel: ResidentModel = new ResidentModel();
  residentId: number;

  listOfCondominium: CondominiumModel[] = new Array<CondominiumModel>();
  listOfTower: TowerModel[] = new Array<TowerModel>();
  listOfApartment: ApartmentModel[] = new Array<ApartmentModel>();

  constructor(
    private _residentService: ResidentService,
    private _towerService: TowerService,
    private _condominiumService: CondominiumService,
    private _apartmentService: ApartmentService,
    private form: FormBuilder,
    private _route: ActivatedRoute,
    private _router: Router
  ) { }

  ngOnInit() {
    this.setDefaultValuesForm();

    this._route.params.subscribe(params => {

      if (params['id']) {
        this.residentId = +params['id'];
        this.getResident(this.residentId);
      }
    });

    this.getAllCondominium();
  }
  // check ngValidatos
  applyCss(field: string) {
    if (this.residentForm.get(field).valid && this.residentForm.get(field).touched) {
      return {
        'has-success': this.residentForm.get(field).valid && this.residentForm.get(field).touched,
        // 'has-feedback': this.residentForm.get(field).valid && this.residentForm.get(field).touched,
        'form-control-success': this.residentForm.get(field).valid && this.residentForm.get(field).touched
      };
    } else {
      return {
        'has-danger': !this.residentForm.get(field).valid && this.residentForm.get(field).touched,
        // 'has-feedback': !this.residentForm.get(field).valid && this.residentForm.get(field).touched,
        'form-control-danger': this.residentForm.get(field).valid && this.residentForm.get(field).touched
      };
    }
  }

  setDefaultValuesForm() {

    this.residentForm = this.form.group({
      id: 0,
      active: true,
      createdAt: Date.now,
      updatedAt: Date.now,
      createdBy: null,
      updatedBy: null,
      name: [null, [Validators.required, Validators.minLength(3)]],
      email: [null, [Validators.email, Validators.required]],
      cpf: [null, [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      dddComercialPhone: [null, [Validators.required, Validators.maxLength(2), Validators.minLength(2)]],
      comercialPhone: [null, [Validators.required, Validators.maxLength(8), Validators.minLength(8)]],
      dddCellPhone: [null, [Validators.maxLength(2), Validators.minLength(2)]],
      cellPhone: [null, [Validators.maxLength(9), Validators.minLength(9)]],
      userName: [null, [Validators.required, Validators.minLength(4)]],
      password: [null, [Validators.required, Validators.minLength(4)]],
      condominiumId: [null, [Validators.required]],
      towerId: [null, [Validators.required]],
      apartmentId: [null, [Validators.required]],
    });
  }

  consultingCep(cep) {

    this._residentService.consultingCep(cep)
      .map(data => data.json())
      .subscribe(data => this.populateAddressForm(data, this.residentForm));
  }

  populateAddressForm(data, residentForm) {
    this.residentForm.patchValue({
      cep: data.cep,
      city: data.localidade,
      complement: data.complemento,
      neighborhood: data.bairro,
      street: data.logradouro,
      uf: data.uf
    })
  }

  populateForm(data: ResidentModel) {

    this.residentForm.patchValue({
      id: data.id,
      active: data.active,
      createdAt: data.createdAt,
      updatedAt: data.updatedAt,
      createdBy: data.createdBy,
      updatedBy: data.updatedBy,
      name: data.name,
      email: data.email,
      cpf: data.cpf,
      dddComercialPhone: data.dddComercialPhone,
      comercialPhone: data.comercialPhone,
      dddCellPhone: data.dddCellPhone,
      cellPhone: data.cellPhone,
      userName: data.userName,
      password: data.passWord,
      condominiumId: data.condominiumId,
      towerId: data.towerId,
      apartmentId: data.apartmentId,

    });

  }

  onSubmit() {

    this.residentModel = this.residentForm.value;

    if (!this.residentId) {
      this.postResident();
    } else {
      this.updateResident();
    }
  }

  getResident(id) {

    this._residentService.getResidentById(id)
      .subscribe(response => {
        this.residentModel = response;
        console.log(response);
        this.populateForm(this.residentModel);
      }, error => {
        console.log(error);
    });
  }

  updateResident() {

    this._residentService.updateResident(this.residentModel, this.residentId)
      .subscribe(response => {
        this.residentModel = response;
        alert('Dados atualizados com sucesso');
        this._router.navigate(['resident/residentList']);
      }, error => {
        console.log(error);
    });

  }

  deleteResident() {

    this._residentService.deleteResident(this.residentId)
      .subscribe(response => {
        console.log(response);
      }, error => {
        console.log(error);
    });
  }

  postResident() {

    this._residentService.postResident(this.residentModel)
      .subscribe(response => {
        this.residentModel = response;
        // message success
        alert('Dados salvos com sucesso!');
        // reset dataForm
        this.residentForm.reset();

        this._router.navigate(['resident/residentList']);
      }, error => {
        console.log(error);
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

    this._towerService.getTowerByCondominiumId(this.residentForm.value.condominiumId)
      .subscribe(response => {
        this.listOfTower = response;
      }, error => {
        console.log(error);
    });
  }

  getApartmentsByTowerId() {

    this._apartmentService.getApartmentTowerId(this.residentForm.value.towerId)
      .subscribe(response => {
        this.listOfApartment = response;
    }, error => console.log(error));
  }
}
