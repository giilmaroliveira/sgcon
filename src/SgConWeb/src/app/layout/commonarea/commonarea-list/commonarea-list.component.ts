import { CondominiumService } from './../../../shared/services/condominium.service';
import { CommonareaService } from './../../../shared/services/commonarea.service';
import { CondominiumModel } from './../../../shared/entities/condominium.model';
import { CommonareaModel } from './../../../shared/entities/commonarea.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-commonarea-list',
  templateUrl: './commonarea-list.component.html',
  styleUrls: ['./commonarea-list.component.scss']
})
export class CommonareaListComponent implements OnInit {

  commonAreaList: CommonareaModel[] = new Array<CommonareaModel>();
  listOfCondominium: CondominiumModel[] = new Array<CondominiumModel>();
  condominiumId: number;

  constructor(
    private _commonareaService: CommonareaService,
    private _condominiumService: CondominiumService
  ) {}

  ngOnInit() {
    this.getAllCondominium();
  }

  getAllCommonarea() {
    this._commonareaService.getAllCommonarea().subscribe(
      response => {
        this.commonAreaList = response;
      }, error => {
        console.log(error);
      });
  }

  getAllCondominium() {
    this._condominiumService.getAllCondominium().subscribe(
      response => {
        this.listOfCondominium = response;
      }, error => {
        console.log(error);
      });
  }

  getCommonareaByCondominiumId() {

    this._commonareaService.getCommonareaCondominiumId(this.condominiumId)
      .subscribe(response => {
        this.commonAreaList = response;
      }, error => {
        console.log(error);
      });
  }
}