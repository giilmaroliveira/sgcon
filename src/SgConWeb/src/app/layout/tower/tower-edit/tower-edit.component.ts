import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';import { Http } from "@angular/http";
import "rxjs/add/operator/map";
import { ActivatedRoute } from "@angular/router";

// models
import { TowerModel } from "../../../shared/entities/tower.model";

// services
import { TowerService } from "../../../shared/services/tower.service";

@Component({
  selector: "app-tower-edit",
  templateUrl: "./tower-edit.component.html",
  styleUrls: ["./tower-edit.component.scss"]
})
export class TowerEditComponent implements OnInit {
  public towerForm: FormGroup;
  towerModel: TowerModel = new TowerModel();
  towerId: number;
  //towerId: number;

  constructor(
    private form: FormBuilder,
    private _towerService: TowerService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.setDefaultValuesForm();

    this._route.params.subscribe(params => {
      if (params["id"]) {
        this.towerId = +params["id"];
        this.getTower(this.towerId);
      }
    });
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
          'form-control-danger': this.towerForm.get(field).valid && this.towerForm.get(field).touched
        };
      }
    }

  setDefaultValuesForm() {
    this.towerForm = this.form.group({
      block: [null,[Validators.required,Validators.minLength(3)]],
      apartmentNumber: [null, [Validators.required, Validators.minLength(1)]],
      condominiumId: [null,[Validators.required]]
    });
  }

  populateForm(data: TowerModel) {
    this.towerForm.patchValue({
      block: data.block,
      apartmentNumber: data.apartmentNumber,
      condominiumId: data.condominiumId
    });
  }

  onSubmit() {
    this.towerModel = this.towerForm.value;

    if (!this.towerId) {
      this._towerService.postTower(this.towerModel).subscribe(
        response => {
          this.towerModel = response;
          // message success
          alert("Dados salvos com sucesso!");
          // reset dataForm
          this.towerForm.reset();
        },
        error => {
          console.log(error);
        }
      );
    } else {
      this._towerService.updateTower(this.towerModel, this.towerId).subscribe(
        response => {
          this.towerModel = response;
          alert("Dados atualizados com sucesso");
        },
        error => {
          console.log(error);
        }
      );
    }
  }

  getTower(id) {
    this._towerService.getTowerById(id).subscribe(
      response => {
        this.towerModel = response;
        this.populateForm(this.towerModel);
      },
      error => {
        console.log(error);
      }
    );
  }

  updateCondomium() {
    this._towerService.updateTower(this.towerModel, this.towerId).subscribe(
      response => {
        this.towerModel = response;
        console.log(response);
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
    this._towerService.postTower(this.towerModel).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }
}
