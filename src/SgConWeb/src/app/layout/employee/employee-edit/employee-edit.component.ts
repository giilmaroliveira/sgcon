import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

// service
import { EmployeeService } from '../../../shared/services/employee.service';

// models
import { EmployeeModel } from '../../../shared/entities/employee.model';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class EmployeeEditComponent implements OnInit {

  public employeeForm: FormGroup;
  employeeModel: EmployeeModel = new EmployeeModel();
  employeeId: number;

  constructor(
    private form: FormBuilder,
    private _employeeService: EmployeeService,
    private _route: ActivatedRoute
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
      uf: [null, [Validators.required, Validators.minLength(2), Validators.maxLength(2)]]
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

    this.employeeModel = this.employeeForm.value;

    console.log(this.employeeModel);

    if (!this.employeeId) {
      this._employeeService.postEmployee(this.employeeModel)
        .subscribe(response => {
          this.employeeModel = response;
          // message success
          alert('Dados salvos com sucesso!');
          // reset dataForm
          this.employeeForm.reset();
        }, error => {
          console.log(error);
        });
    } else {
      this._employeeService.updateEmployee(this.employeeModel, this.employeeId)
        .subscribe(response => {
          this.employeeModel = response;
          alert('Dados atualizados com sucesso');
        }, error => {
          console.log(error);
        });
    }
  }

  getEmployee(id) {

    this._employeeService.getEmployeeById(id)
      .subscribe(response => {
        this.employeeModel = response;
        console.log(response);
        this.populateForm(this.employeeModel);
      }, error => {
        console.log(error);
      });
  }

  updateEmployee() {

    this._employeeService.updateEmployee(this.employeeModel, this.employeeId)
      .subscribe(response => {
        this.employeeModel = response;
        console.log(response);
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

  postEmployee() {

    this._employeeService.postEmployee(this.employeeModel)
      .subscribe(response => {
        console.log(response);
      }, error => {
        console.log(error);
      });
  }
}
