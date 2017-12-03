import { CompanyService } from './../../../shared/services/company.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyModel } from './../../../shared/entities/company.model';
import { Component, OnInit } from '@angular/core';
import { FormGroup, ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-company-edit',
  templateUrl: './company-edit.component.html',
  styleUrls: ['./company-edit.component.scss']
})
export class CompanyEditComponent implements OnInit {

  public companyForm: FormGroup;
  companyModel: CompanyModel = new CompanyModel();
  companyId: number;

  constructor(
    private form: FormBuilder,
    private _companyService: CompanyService,
    private _route: ActivatedRoute,
    private _router: Router
  ) { }

  ngOnInit() {
    this.setDefaultValuesForm();

    this._route.params.subscribe(params => {

      if (params['id']) {
        this.companyId = +params['id'];
        this.getCompany(this.companyId);
      }
    });

  }
  // check ngValidatos
  applyCss(field: string) {
    if (this.companyForm.get(field).valid && this.companyForm.get(field).touched) {
      return {
        'has-success': this.companyForm.get(field).valid && this.companyForm.get(field).touched,
        'has-feedback': this.companyForm.get(field).valid && this.companyForm.get(field).touched,
        'form-control-success': this.companyForm.get(field).valid && this.companyForm.get(field).touched
      };
    } else {
      return {
        'has-danger': !this.companyForm.get(field).valid && this.companyForm.get(field).touched,
        'has-feedback': !this.companyForm.get(field).valid && this.companyForm.get(field).touched,
        'form-control-danger': !this.companyForm.get(field).valid && this.companyForm.get(field).touched
      };
    }
  }

  setDefaultValuesForm() {

    this.companyForm = this.form.group({
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
    });
  }

  consultingCep(cep) {

    this._companyService.consultingCep(cep)
      .map(data => data.json())
      .subscribe(data => this.populateAddressForm(data, this.companyForm));
  }

  populateAddressForm(data, companyForm) {
    this.companyForm.patchValue({
      cep: data.cep,
      city: data.localidade,
      complement: data.complemento,
      neighborhood: data.bairro,
      street: data.logradouro,
      uf: data.uf
    })
  }

  populateForm(data: CompanyModel) {

    this.companyForm.patchValue({
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
      // address: data.address,
      addressId: data.addressId,
      cep: data.address.cep,
      street: data.address.street,
      number: data.address.number,
      neighborhood: data.address.neighborhood,
      city: data.address.city,
      complement: data.address.complement,
      uf: data.address.uf,
    });

  }

  onSubmit() {

    this.companyForm = this.companyForm.value;
    console.log(this.companyForm.value);
    // console.log(this.companyModel);

    if (!this.companyId) {
      this._companyService.postCompany(this.companyModel)
        .subscribe(response => {
          this.companyModel = response;
          // message success
          alert('Dados salvos com sucesso!');
          // reset dataForm
          this.companyForm.reset();
          // Voltar para listagem
          this._router.navigate(['condominium/condominiumList']);
        }, error => {
          console.log(error);
        });
    } else {
      this._companyService.updateCompany(this.companyModel, this.companyId)
        .subscribe(response => {
          this.companyModel = response;
          alert('Dados atualizados com sucesso');
          this._router.navigate(['condominium/condominiumList']);
        }, error => {
          console.log(error);
        });
    }
  }

  getCompany(id) {

    this._companyService.getCompanyById(id)
      .subscribe(response => {
        this.companyModel = response;
        this.populateForm(this.companyModel);
      }, error => {
        console.log(error);
      });
  }

  updateCompany() {

    this._companyService.updateCompany(this.companyModel, this.companyId)
      .subscribe(response => {
        this.companyModel = response;
        console.log(response);
      }, error => {
        console.log(error);
      });

  }

  deleteCompany() {

    this._companyService.deleteCompany(this.companyId)
      .subscribe(response => {
        console.log(response);
      }, error => {
        console.log(error);
      });
  }

  postCompany() {

    this._companyService.postCompany(this.companyModel)
      .subscribe(response => {
        console.log(response);
      }, error => {
        console.log(error);
      });
  }
}
