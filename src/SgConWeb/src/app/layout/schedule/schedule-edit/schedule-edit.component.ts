import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-schedule-edit',
  templateUrl: './schedule-edit.component.html',
  styleUrls: ['./schedule-edit.component.scss']
})
export class ScheduleEditComponent implements OnInit {

  date: Date;

  teste() {
    console.log(this.date);
  }

  constructor() { }

  ngOnInit() {
  }

}
