import { Component, OnInit } from '@angular/core';

// Models
import { ScheduleModel } from '../../../shared/entities/schedule.model';
import { CondominiumModel } from '../../../shared/entities/condominium.model';
import { CommonAreaModel } from '../../../shared/entities/commonarea.model';

// Services
import { CommonAreaService } from '../../../shared/services/commonarea.service';

@Component({
  selector: 'app-schedule-edit',
  templateUrl: './schedule-edit.component.html',
  styleUrls: ['./schedule-edit.component.scss']
})
export class ScheduleEditComponent implements OnInit {

  date: Date;
  listOfCommonArea: CommonAreaModel[] = new Array<CommonAreaModel>();
  scheduleModel: ScheduleModel = new ScheduleModel();

  listOfTimes = [
    {key: 1, value: '08:00 11:00'},
    {key: 2, value: '13:00 16:00'},
    {key: 3, value: '17:00 18:00'},
    {key: 4, value: '18:00 22:00'},
  ];

  constructor(private _commonAreaService: CommonAreaService) { }

  teste() {
    console.log(this.date);
  }

  ngOnInit() {
    this.getCommonAreaByCondominiumId();
  }

  getCommonAreaByCondominiumId() {
    let id: number = 1;

    this._commonAreaService.getCommonareaCondominiumId(id)
      .subscribe(response => {
        console.log(response);
        this.listOfCommonArea = response;
      }, error => {
        console.log(error);
      })
  }

  onSumit() {

    this.scheduleModel.used = false;
    this.scheduleModel.apartmentId = 1;

    console.log(this.scheduleModel);

    this._commonAreaService.postCommonAreaSchedule(this.scheduleModel)
      .subscribe(response => {
        console.log(response);
        console.log('gravou');
      }, error => {
        console.log(error);
      });
  }

}
