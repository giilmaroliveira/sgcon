import { Component, OnInit } from '@angular/core';
// service
import { ResidentService } from './../../../shared/services/resident.service';
// models
import { ResidentModel } from './../../../shared/entities/resident.model';

@Component({
  selector: 'app-resident-list',
  templateUrl: './resident-list.component.html',
  styleUrls: ['./resident-list.component.scss']
})
export class ResidentListComponent implements OnInit {

  residentList: ResidentModel[] = new Array<ResidentModel>();

    constructor(private _residentService: ResidentService) {}

    ngOnInit() {
      this.getAllResident();
    }

    getAllResident() {
      this._residentService.getAllResident().subscribe(
        response => {
          this.residentList = response;
        },
        error => {
          console.log(error);
        }
      );
    }
  }
