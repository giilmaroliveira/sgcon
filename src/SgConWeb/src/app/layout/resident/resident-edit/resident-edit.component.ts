import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
// service
import { ResidentService } from './../../../shared/services/resident.service';
// models
import { ResidentModel } from './../../../shared/entities/resident.model';

@Component({
  selector: 'app-resident-edit',
  templateUrl: './resident-edit.component.html',
  styleUrls: ['./resident-edit.component.scss']
})
export class ResidentEditComponent implements OnInit {

  public residentForm: FormGroup;
  residentModel: ResidentModel = new ResidentModel();
  residentId: number;

  constructor(
    private form: FormBuilder,
    private _residentService: ResidentService,
    private _route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.setDefaultValuesForm();

    this._route.params.subscribe(params => {

      if (params['id']) {
        this.residentId = +params['id'];
        this.getResident(this.residentId);
      }
    });

  }
  // check ngValidatos
  applyCss(field: string) {
    if (this.residentForm.get(field).valid && this.residentForm.get(field).touched) {
      return {
        'has-success': this.residentForm.get(field).valid && this.residentForm.get(field).touched,
        'has-feedback': this.residentForm.get(field).valid && this.residentForm.get(field).touched,
        'form-control-success': this.residentForm.get(field).valid && this.residentForm.get(field).touched
      };
    } else {
      return {
        'has-danger': !this.residentForm.get(field).valid && this.residentForm.get(field).touched,
        'has-feedback': !this.residentForm.get(field).valid && this.residentForm.get(field).touched,
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
      cpf: [null, [Validators.required, Validators.minLength(9), Validators.maxLength(9)]],
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
      uf: [null, [Validators.required, Validators.minLength(2), Validators.maxLength(2)]]
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

    this.residentModel = this.residentForm.value;

    console.log(this.residentModel);

    if (!this.residentId) {
      this._residentService.postResident(this.residentModel)
        .subscribe(response => {
          this.residentModel = response;
          // message success
          alert('Dados salvos com sucesso!');
          // reset dataForm
          this.residentForm.reset();
        }, error => {
          console.log(error);
        });
    } else {
      this._residentService.updateResident(this.residentModel, this.residentId)
        .subscribe(response => {
          this.residentModel = response;
          alert('Dados atualizados com sucesso');
        }, error => {
          console.log(error);
        });
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
        console.log(response);
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
        console.log(response);
      }, error => {
        console.log(error);
      });
  }
}
