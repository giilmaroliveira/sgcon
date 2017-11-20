import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { ActivatedRoute, Router } from '@angular/router';

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
    private _route: ActivatedRoute,
    private _router: Router
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
  // check ngValidatos
  applyCss(field: string) {
    if (this.condominiumForm.get(field).valid && this.condominiumForm.get(field).touched) {
      return {
        'has-success': this.condominiumForm.get(field).valid && this.condominiumForm.get(field).touched,
        'has-feedback': this.condominiumForm.get(field).valid && this.condominiumForm.get(field).touched,
        'form-control-success': this.condominiumForm.get(field).valid && this.condominiumForm.get(field).touched
      };
    } else {
      return {
        'has-danger': !this.condominiumForm.get(field).valid && this.condominiumForm.get(field).touched,
        'has-feedback': !this.condominiumForm.get(field).valid && this.condominiumForm.get(field).touched,
        'form-control-danger': this.condominiumForm.get(field).valid && this.condominiumForm.get(field).touched
      };
    }
  }

  setDefaultValuesForm() {

    this.condominiumForm = this.form.group({
      id: 0,
      active: true,
      createdAt: Date.now,
      updatedAt: Date.now,
      createdBy: null,
      updatedBy: null,
      name: [null, [Validators.required, Validators.minLength(3)]],
      email: [null, [Validators.email, Validators.required]],
      cnpj: [null, [Validators.required, Validators.minLength(14), Validators.maxLength(14)]],
      dddComercialPhone: [null, [Validators.required, Validators.maxLength(2), Validators.minLength(2)]],
      comercialPhone: [null, [Validators.required, Validators.maxLength(8), Validators.minLength(8)]],
      dddCellPhone: [null, [Validators.maxLength(2), Validators.minLength(2)]],
      cellPhone: [null, [Validators.maxLength(9), Validators.minLength(9)]],
      street: [null, [Validators.required, Validators.minLength(3)]],
      number: [null, [Validators.required, Validators.minLength(1)]],
      cep: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(9)]],
      complement: [null],
      neighborhood: [null, [Validators.required, Validators.minLength(2)]],
      city: [null, [Validators.required, Validators.minLength(2)]],
      uf: [null, [Validators.required, Validators.minLength(2), Validators.maxLength(2)]],
      towerNumber: [null, [Validators.required]]
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
      id: data.id,
      active: data.active,
      createdAt: data.createdAt,
      updatedAt: data.updatedAt,
      createdBy: data.createdBy,
      updatedBy: data.updatedBy,
      name: data.name,
      email: data.email,
      cnpj: data.cnpj,
      dddComercialPhone: data.dddComercialPhone,
      comercialPhone: data.comercialPhone,
      dddCellPhone: data.dddCellPhone,
      cellPhone: data.cellPhone,
      cep: data.cep,
      street: data.street,
      number: data.number,
      neighborhood: data.neighborhood,
      city: data.city,
      complement: data.complement,
      uf: data.uf,
      towerNumber: data.towerNumber
    });

  }

  onSubmit() {

    this.condominiumModel = this.condominiumForm.value;
    console.log(this.condominiumForm.value);
    // console.log(this.condominiumModel);

    if (!this.condominiumId) {
      this._condominiumService.postCondominium(this.condominiumModel)
        .subscribe(response => {
          this.condominiumModel = response;
          // message success
          alert('Dados salvos com sucesso!');
          // reset dataForm
          this.condominiumForm.reset();
          // Voltar para listagem
          this._router.navigate(['condominium/condominiumList']);
        }, error => {
          console.log(error);
        });
    } else {
      this._condominiumService.updateCondominium(this.condominiumModel, this.condominiumId)
        .subscribe(response => {
          this.condominiumModel = response;
          alert('Dados atualizados com sucesso');
          this._router.navigate(['condominium/condominiumList']);
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
