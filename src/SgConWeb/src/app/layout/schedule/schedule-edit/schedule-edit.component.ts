import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-schedule-edit',
  templateUrl: './schedule-edit.component.html',
  styleUrls: ['./schedule-edit.component.scss']
})
export class ScheduleEditComponent implements OnInit {

  date: Date;

  listOfTimes = [
    {key: 1, value: "08:00 11:00"},
    {key: 2, value: "13:00 16:00"},
    {key: 3, value: "17:00 18:00"},
  ]

  teste() {
    console.log(this.date);
  }

  constructor() { }

  ngOnInit() {
  }

}