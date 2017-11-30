import { Component, OnInit } from '@angular/core';
import {NgbTimeStruct} from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-commonarea-edit',
  templateUrl: './commonarea-edit.component.html',
  styleUrls: ['./commonarea-edit.component.scss']
})
export class CommonareaEditComponent implements OnInit {

  date: Date;
  startTime = {hour: 13, minute: 30};
  finishTime = {hour: 13, minute: 30};

  teste() {
    console.log(this.date);
  }

  constructor() { }

  ngOnInit() {

  }

}
