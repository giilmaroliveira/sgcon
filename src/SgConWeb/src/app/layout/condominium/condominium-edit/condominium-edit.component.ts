import { Component, OnInit } from '@angular/core';

//Services
import { CondominiumService } from '../../../shared/services/condominium.service';
//Models
import { CondominiumModel } from '../../../shared/entities/condominium.model';

@Component({
  selector: 'app-condominium-edit',
  templateUrl: './condominium-edit.component.html',
  styleUrls: ['./condominium-edit.component.scss']
})
export class CondominiumEditComponent implements OnInit {

  condominiumModel: CondominiumModel = new CondominiumModel();
  condominiumId: number;
  constructor(
    private _condominiumService: CondominiumService
  ) { }

  ngOnInit() {

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
