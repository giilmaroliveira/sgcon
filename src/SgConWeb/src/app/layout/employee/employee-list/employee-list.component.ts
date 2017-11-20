import { Component, OnInit } from '@angular/core';
// services
import { EmployeeService } from './../../../shared/services/employee.service';
// models
import { EmployeeModel } from './../../../shared/entities/employee.model';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  employeeList: EmployeeModel[] = new Array<EmployeeModel>();

    constructor(private _employeeService: EmployeeService) {}

    ngOnInit() {
      this.getAllEmployee();
    }

    getAllEmployee() {
      this._employeeService.getAllEmployee().subscribe(
        response => {
          this.employeeList = response;
        },
        error => {
          console.log(error);
        }
      );
    }
  }
