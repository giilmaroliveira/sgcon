import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// service
import { EmployeeService } from '../../shared/services/employee.service';

// components
import { EmployeeComponent } from './employee.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeEditComponent } from './employee-edit/employee-edit.component';

// modules
import { EmployeeRoutingModule } from './employee.routing.module';

@NgModule({
    imports: [
        CommonModule,
        EmployeeRoutingModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    exports: [],

    declarations: [
        EmployeeComponent,
        EmployeeEditComponent,
        EmployeeListComponent
    ],
    providers: [
        EmployeeService
    ],
})
export class EmployeeModule { }
