import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

// service
import { EmployeeService } from '../../../shared/services/employee.service';

// models
import { EmployeeModel } from '../../../shared/entities/employee.model';
import { Profile } from '../../../shared/entities/profile.model';
import { Address } from '../../../shared/entities/address.model';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class EmployeeEditComponent implements OnInit {

  public employeeForm: FormGroup;
  employeeModel: EmployeeModel = new EmployeeModel();
  employeeId: number;
  address: Address = new Address();
  profile: Profile = new Profile();

  constructor(
    private form: FormBuilder,
    private _employeeService: EmployeeService,
    private _route: ActivatedRoute,
    private _router: Router
  ) { }

  ngOnInit() {
    this.setDefaultValuesForm();

    this._route.params.subscribe(params => {

      if (params['id']) {
        this.employeeId = +params['id'];
        this.getEmployee(this.employeeId);
      }
    });

  }
  // check ngValidatos
  applyCss(field: string) {
    if (this.employeeForm.get(field).valid && this.employeeForm.get(field).touched) {
      return {
        'has-success': this.employeeForm.get(field).valid && this.employeeForm.get(field).touched,
        'has-feedback': this.employeeForm.get(field).valid && this.employeeForm.get(field).touched,
        'form-control-success': this.employeeForm.get(field).valid && this.employeeForm.get(field).touched
      };
    } else {
      return {
        'has-danger': !this.employeeForm.get(field).valid && this.employeeForm.get(field).touched,
        'has-feedback': !this.employeeForm.get(field).valid && this.employeeForm.get(field).touched,
        'form-control-danger': this.employeeForm.get(field).valid && this.employeeForm.get(field).touched
      };
    }
  }

  setDefaultValuesForm() {

    this.employeeForm = this.form.group({
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
      street: [null, [Validators.required, Validators.minLength(3)]],
      number: [null, [Validators.required, Validators.minLength(1)]],
      cep: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(9)]],
      complement: [null],
      neighborhood: [null, [Validators.required, Validators.minLength(2)]],
      city: [null, [Validators.required, Validators.minLength(2)]],
      uf: [null, [Validators.required, Validators.minLength(2), Validators.maxLength(2)]],
      userName: [null, [Validators.required, Validators.minLength(3)]],
      passWord: [null, [Validators.required, Validators.minLength(3)]],
      jobRole: [null, [Validators.required, Validators.minLength(3)]],
      profileId: 2
    });
  }

  consultingCep(cep) {

    this._employeeService.consultingCep(cep)
      .map(data => data.json())
      .subscribe(data => this.populateAddressForm(data, this.employeeForm));
  }

  populateAddressForm(data, employeeForm) {
    this.employeeForm.patchValue({
      cep: data.cep,
      city: data.localidade,
      complement: data.complemento,
      neighborhood: data.bairro,
      street: data.logradouro,
      uf: data.uf
    })
  }

  populateForm(data: EmployeeModel) {

    this.employeeForm.patchValue({
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
      addressId: data.addressId,
      cep: data.address.cep,
      street: data.address.street,
      number: data.address.number,
      neighborhood: data.address.neighborhood,
      city: data.address.city,
      complement: data.address.complement,
      uf: data.address.uf,
      userName: data.userName,
      passWord: data.passWord,
      jobRole: data.jobRole,
      profileId: data.profileId
    });

  }

  onSubmit() {

    this.employeeModel.name = this.employeeForm.value.name;
    this.employeeModel.email = this.employeeForm.value.email;
    this.employeeModel.dddComercialPhone = this.employeeForm.value.dddComercialPhone;
    this.employeeModel.comercialPhone = this.employeeForm.value.comercialPhone;
    this.employeeModel.dddCellPhone = this.employeeForm.value.dddCellPhone;
    this.employeeModel.cellPhone = this.employeeForm.value.cellPhone;

    // Default value for condominium address
    this.address.addressTypeId = 3;
    this.address.cep = this.employeeForm.value.cep;
    this.address.street = this.employeeForm.value.street;
    this.address.number = this.employeeForm.value.number;
    this.address.neighborhood = this.employeeForm.value.neighborhood;
    this.address.city = this.employeeForm.value.city;
    this.address.complement = this.employeeForm.value.complement;
    this.address.uf = this.employeeForm.value.uf;

    this.employeeModel.address = this.address;
    this.profile = this.profile;

    if (!this.employeeId) {
      this.postEmployee();
    } else {
      this.updateEmployee();
    }
  }

  getEmployee(id) {

    this._employeeService.getEmployeeById(id)
      .subscribe(response => {
        this.employeeModel = response;
        this.address = response.address;
        this.profile = response.profile;
        this.populateForm(this.employeeModel);
      }, error => {
        console.log(error);
      });
  }

  postEmployee() {

    this._employeeService.postEmployee(this.employeeModel)
      .subscribe(response => {
        this.employeeModel = response;
        // message success
        alert('Dados salvos com sucesso!');

        // Voltar para a listagem
        this._router.navigate(['employee/employeeList']);
      }, error => {
        console.log(error);
      });
  }

  updateEmployee() {

    this._employeeService.updateEmployee(this.employeeModel, this.employeeId)
      .subscribe(response => {
        this.employeeModel = response;
        alert('Dados atualizados com sucesso');

        // Voltar para a listagem
        this._router.navigate(['employee/employeeList']);
      }, error => {
        console.log(error);
      });

  }

  deleteEmployee() {

    this._employeeService.deleteEmployee(this.employeeId)
      .subscribe(response => {
        console.log(response);
      }, error => {
        console.log(error);
      });
  }
}
