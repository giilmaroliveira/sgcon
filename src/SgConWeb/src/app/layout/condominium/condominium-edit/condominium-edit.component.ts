import { Component, OnInit } from '@angular/core';

import { FormGroup, FormBuilder } from '@angular/forms';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
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
    private _condominiumService: CondominiumService
  ) { }

  ngOnInit() {
    this.condominiumForm = this.form.group({
      name: [null],
      email: [null],
      cnpj: [null],
      dddComercialPhone: [null],
      comercialPhone: [null],
      dddCelPhone: [null],
      celPhone: [null],
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
      .subscribe(data => this.populadataForm(data, this.condominiumForm));
  }

  populadataForm(data, condominiumForm) {
    this.condominiumForm.patchValue({
      cep: data.cep,
      city: data.localidade,
      complement: data.complemento,
      neighborhood: data.bairro,
      street: data.logradouro,
      uf: data.uf
    })
  }
  onSubmit() {
    console.log(this.condominiumForm.value);
  }

  getCondominium(id) {

    this._condominiumService.getCondominiumById(id)
      .subscribe(response => {
        this.condominiumModel = response;
        console.log(response);
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
