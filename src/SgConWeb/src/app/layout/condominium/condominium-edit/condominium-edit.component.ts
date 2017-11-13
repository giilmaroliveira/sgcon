import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { ActivatedRoute } from '@angular/router';

// Services
import { CondominiumService } from '../../../shared/services/condominium.service';

// Models
import { CondominiumModel } from '../../../shared/entities/condominium.model';

@Component({
  selector: 'app-condominium-edit',
  templateUrl: './condominium-edit.component.html',
  styleUrls: ['./condominium-edit.component.scss']
})
export class CondominiumEditComponent implements OnInit {

  public condominiumForm: FormGroup;
  condominiumModel: CondominiumModel = new CondominiumModel();
  condominiumId: number;

  constructor(
    private form: FormBuilder,
    private _condominiumService: CondominiumService,
    private _route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.setDefaultValuesForm();

    this._route.params.subscribe(params => {

      if (params['id']) {
        this.condominiumId = +params['id'];
        this.getCondominium(this.condominiumId);
      }
    });

  }

  setDefaultValuesForm() {

    this.condominiumForm = this.form.group({
      name: [null],
      email: [null],
      cnpj: [null],
      DDDComercialPhone: [null],
      comercialPhone: [null],
      DDDCellPhone: [null],
      cellPhone: [null],
      street: [null],
      number: [null],
      cep: [null],
      complement: [null],
      neighborhood: [null],
      city: [null],
      uf: [null]
    });
  }

  consultingCep(cep) {

    this._condominiumService.consultingCep(cep)
      .map(data => data.json())
      .subscribe(data => this.populateAddressForm(data, this.condominiumForm));
  }

  populateAddressForm(data, condominiumForm) {
    this.condominiumForm.patchValue({
      cep: data.cep,
      city: data.localidade,
      complement: data.complemento,
      neighborhood: data.bairro,
      street: data.logradouro,
      uf: data.uf
    })
  }

  populateForm(data: CondominiumModel) {

    this.condominiumForm.patchValue({
      name: data.name,
      email: data.email,
      cnpj: data.cnpj,
      DDDComercialPhone: data.dddComercialPhone,
      comercialPhone: data.comercialPhone,
      DDDCellPhone: data.dddCellPhone,
      cellPhone: data.cellPhone,
      cep: data.cep,
      street: data.street,
      number: data.number,
      neighborhood: data.neighborhood,
      city: data.city,
      complement: data.complement,
      uf: data.uf
    });

  }

  onSubmit() {

    this.condominiumModel = this.condominiumForm.value;

    if (!this.condominiumId) {
      this._condominiumService.postCondominium(this.condominiumModel)
        .subscribe(response => {
          this.condominiumModel = response;
          console.log('salvo com sucesso');
        }, error => {
          console.log(error);
        });
    } else {
      this._condominiumService.updateCondominium(this.condominiumModel, this.condominiumId)
        .subscribe(response => {
          this.condominiumModel = response;
          console.log('atualizado com sucesso');
        }, error => {
          console.log(error);
        });
    }
  }

  getCondominium(id) {

    this._condominiumService.getCondominiumById(id)
      .subscribe(response => {
        this.condominiumModel = response;
        this.populateForm(this.condominiumModel);
      }, error => {
        console.log(error);
      });
  }

  updateCondomium() {

    this._condominiumService.updateCondominium(this.condominiumModel, this.condominiumId)
      .subscribe(response => {
        this.condominiumModel = response;
        console.log(response);
      }, error => {
        console.log(error);
      });

  }

  deleteCondominium() {

    this._condominiumService.deleteCondominium(this.condominiumId)
      .subscribe(response => {
        console.log(response);
      }, error => {
        console.log(error);
      });
  }

  postCondominium() {

    this._condominiumService.postCondominium(this.condominiumModel)
      .subscribe(response => {
        console.log(response);
      }, error => {
        console.log(error);
      });
  }
}
