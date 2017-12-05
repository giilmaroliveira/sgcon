import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

// Models
import { ScheduleModel } from '../../../shared/entities/schedule.model';

// Services
import { CommonAreaService } from '../../../shared/services/commonarea.service';

@Component({
  selector: 'app-schedule-list',
  templateUrl: './schedule-list.component.html',
  styleUrls: ['./schedule-list.component.scss']
})
export class ScheduleListComponent implements OnInit {

  listOfSchedules: ScheduleModel[] = new Array<ScheduleModel>();

  listOfTimes = [
    {key: 1, value: '08:00 11:00'},
    {key: 2, value: '13:00 16:00'},
    {key: 3, value: '17:00 18:00'},
    {key: 4, value: '18:00 22:00'},
  ];

  constructor(
    private _commonAreaService: CommonAreaService
  ) { }

  ngOnInit() {

    this.getUserSchedules();
  }

  getUserSchedules() {

    this._commonAreaService.getUserSchedules()
      .subscribe(response => {
        this.listOfSchedules = response;
        console.log(this.listOfSchedules);
      }, error => console.log(error));
  }

}
