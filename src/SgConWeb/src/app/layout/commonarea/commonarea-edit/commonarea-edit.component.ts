import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import 'rxjs/add/operator/map';

// models
import { CommonareaModel } from '../../../shared/entities/commonarea.model';
import { CondominiumModel } from '../../../shared/entities/condominium.model';

// services
import { CondominiumService } from '../../../shared/services/condominium.service';
import { CommonareaService } from '../../../shared/services/commonarea.service';

@Component({
  selector: 'app-commonarea-edit',
  templateUrl: './commonarea-edit.component.html',
  styleUrls: ['./commonarea-edit.component.scss']
})
export class CommonareaEditComponent implements OnInit {

  public commonAreaForm: FormGroup;
  commonareaModel: CommonareaModel = new CommonareaModel();
  listOfCondominium: CondominiumModel[] = new Array<CondominiumModel>();

  commonareaId

  constructor(
    private form: FormBuilder,
    private _route: ActivatedRoute,
    private _condominiumService: CondominiumService,
    private _commonareaService: CommonareaService,
  ) { }

  ngOnInit() {
    this.setDefaultValuesForm();

    this._route.params.subscribe(params => {
      if (params['id']) {
        this.commonareaId = +params['id'];
        this.getCommonarea(this.commonareaId);
      }
    });

    this.getAllCondominium();
  }

    // check ngValidatos
    applyCss(field: string) {
      if (this.commonAreaForm.get(field).valid && this.commonAreaForm.get(field).touched) {
        return {
          'has-success': this.commonAreaForm.get(field).valid && this.commonAreaForm.get(field).touched,
          'has-feedback': this.commonAreaForm.get(field).valid && this.commonAreaForm.get(field).touched,
          'form-control-success': this.commonAreaForm.get(field).valid && this.commonAreaForm.get(field).touched
        };
      } else {
        return {
          'has-danger': !this.commonAreaForm.get(field).valid && this.commonAreaForm.get(field).touched,
          'has-feedback': !this.commonAreaForm.get(field).valid && this.commonAreaForm.get(field).touched,
          'form-control-danger': !this.commonAreaForm.get(field).valid && this.commonAreaForm.get(field).touched
        };
      }
    }

  setDefaultValuesForm() {
    this.commonAreaForm = this.form.group({
      name: [null, [Validators.required, Validators.minLength(3)]],
      description: [null, [Validators.required, Validators.minLength(1)]],
      condominiumId: [null, [Validators.required]],
      capacity: [null, [Validators.required, Validators.minLength(1)]]
    });
  }

  populateForm(data: CommonareaModel) {
    this.commonAreaForm.patchValue({

      name: data.name,
      description: data.description,
      condominiumId: data.condominiumId,
      capacity: data.capacity

    });
  }

  onSubmit() {
    this.commonareaModel = this.commonAreaForm.value;

    if (!this.commonareaId) {
      this._commonareaService.postCommonarea(this.commonareaModel).subscribe(
        response => {
          this.commonareaModel = response;
          // message success
          alert('Dados salvos com sucesso!');
          // reset dataForm
          this.commonAreaForm.reset();
        },
        error => {
          console.log(error);
        }
      );
    } else {
      this._commonareaService.updateCommonarea(this.commonareaModel, this.commonareaId).subscribe(
        response => {
          this.commonareaModel = response;
          alert('Dados atualizados com sucesso');
        },
        error => {
          console.log(error);
        }
      );
    }
  }

  getCommonarea(id) {
    this._commonareaService.getCommonareaById(id).subscribe(
      response => {
        this.commonareaModel = response;
        this.populateForm(this.commonareaModel);
      },
      error => {
        console.log(error);
      }
    );
  }

  updateCommonarea() {
    this._commonareaService.updateCommonarea(this.commonareaModel, this.commonareaId).subscribe(
      response => {
        this.commonareaModel = response;
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }

  deleteCommonarea() {
    this._commonareaService.deleteCommonarea(this.commonareaId).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }

  postCommonarea() {
    this._commonareaService.postCommonarea(this.commonareaModel).subscribe(
      response => {
        console.log(response);
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
}
