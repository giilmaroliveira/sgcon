import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

// models
import { TowerModel } from '../../../shared/entities/tower.model';
import { CondominiumModel } from '../../../shared/entities/condominium.model';

// services
import { TowerService } from '../../../shared/services/tower.service';
import { CondominiumService } from '../../../shared/services/condominium.service';

@Component({
  selector: 'app-tower-edit',
  templateUrl: './tower-edit.component.html',
  styleUrls: ['./tower-edit.component.scss']
})
export class TowerEditComponent implements OnInit {

  public towerForm: FormGroup;
  towerModel: TowerModel = new TowerModel();
  listOfCondominium: CondominiumModel[] = new Array<CondominiumModel>();

  towerId: number;

  constructor(
    private form: FormBuilder,
    private _towerService: TowerService,
    private _route: ActivatedRoute,
    private _condominiumService: CondominiumService,
    private _router: Router
  ) { }

  ngOnInit() {
    this.setDefaultValuesForm();

    this._route.params.subscribe(params => {
      if (params['id']) {
        this.towerId = +params['id'];
        this.getTower(this.towerId);
      }
    });

    this.getAllCondominium();
  }

  // check ngValidatos
  applyCss(field: string) {
    if (this.towerForm.get(field).valid && this.towerForm.get(field).touched) {
      return {
        'has-success': this.towerForm.get(field).valid && this.towerForm.get(field).touched,
        'has-feedback': this.towerForm.get(field).valid && this.towerForm.get(field).touched,
        'form-control-success': this.towerForm.get(field).valid && this.towerForm.get(field).touched
      };
    } else {
      return {
        'has-danger': !this.towerForm.get(field).valid && this.towerForm.get(field).touched,
        'has-feedback': !this.towerForm.get(field).valid && this.towerForm.get(field).touched,
        'form-control-danger': !this.towerForm.get(field).valid && this.towerForm.get(field).touched
      };
    }
  }

  setDefaultValuesForm() {
    this.towerForm = this.form.group({
      id: 0,
      active: true,
      createdAt: Date.now,
      updatedAt: Date.now,
      createdBy: null,
      updatedBy: null,
      block: [null, [Validators.required, Validators.minLength(3)]],
      floorsNumber: [null, [Validators.required, Validators.minLength(1)]],
      condominiumId: [null, [Validators.required]]
    });
  }

  populateForm(data: TowerModel) {
    this.towerForm.patchValue({
      id: data.id,
      active: data.active,
      createdAt: data.createdAt,
      updatedAt: data.updatedAt,
      createdBy: data.createdBy,
      updatedBy: data.updatedBy,
      block: data.block,
      floorsNumber: data.floorsNumber,
      condominiumId: data.condominiumId
    });
  }

  onSubmit() {
    this.towerModel = this.towerForm.value;

    if (!this.towerId) {
      this.postTower();
    } else {
      this.updateTower();
    }
  }

  getTower(id) {
    this._towerService.getTowerById(id)
      .subscribe( response => {
        this.towerModel = response;
        this.populateForm(this.towerModel);
      },
      error => {
        console.log(error);
      }
    );
  }

  updateTower() {
    this._towerService.updateTower(this.towerModel, this.towerId)
      .subscribe( response => {
        this.towerModel = response;
        alert('Dados atualizados com sucesso');
        this._router.navigate(['tower/towerList']);
      },
      error => {
        console.log(error);
      }
    );
  }

  deleteTower() {
    this._towerService.deleteTower(this.towerId).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }

  postTower() {
    this._towerService.postTower(this.towerModel)
      .subscribe( response => {
        this.towerModel = response;
        // message success
        alert('Dados salvos com sucesso!');

        this._router.navigate(['tower/towerList']);
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
