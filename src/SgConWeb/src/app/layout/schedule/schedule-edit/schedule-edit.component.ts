import { DatePipe } from '@angular/common';
import { NgbDatepicker, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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
  listOfCommonArea: CommonAreaModel[] = new Array<CommonAreaModel>();
  scheduleModel: ScheduleModel = new ScheduleModel();
  listOfSchedules: ScheduleModel[] = new Array<ScheduleModel>();
  canShowInputs: boolean = false;

  listOfTimes = [
    {key: 1, value: '08:00 11:00'},
    {key: 2, value: '13:00 16:00'},
    {key: 3, value: '17:00 18:00'},
    {key: 4, value: '18:00 22:00'},
  ];

  listOfTimesFilter = [];

  constructor(
    private _commonAreaService: CommonAreaService,
    private _router: Router) { }

  ngOnInit() {
    this.getCommonAreaByCondominiumId();
  }

  getCommonAreaByCondominiumId() {
  
    this._commonAreaService.getCommonAreaByUser()
      .subscribe(response => {
        this.listOfCommonArea = response;
      }, error => {
        console.log(error);
      })
  }

  getScheduleByCommonArea() {

    this._commonAreaService.getSchedulesByCommonAreaId(this.scheduleModel.commonAreaId, this.scheduleModel.date)
      .subscribe(response => {
        this.listOfSchedules = response;

        this.listOfTimes.forEach(item => {
          let time = this.listOfSchedules.find(x => x.scheduleId == item.key);

          if (time == null) {
            this.listOfTimesFilter.push(item);
          }

        });
        
      }, error => {
        console.log(error);
      })
  }  

  onSubmit() {

    this.scheduleModel.used = false;
    this.scheduleModel.apartmentId = 1;

    this._commonAreaService.postCommonAreaSchedule(this.scheduleModel)
      .subscribe(response => {
        console.log(response);
        alert('Agendamento feito com sucesso!');

        this._router.navigate(['schedule/scheduleList']);
      }, error => {
        console.log(error);
      });
  }

  showInputs() {

    if (this.scheduleModel.date && this.scheduleModel.date != null)
      this.canShowInputs = true;
  }

}
