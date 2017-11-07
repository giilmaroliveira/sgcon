import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeComponent } from './employee.component';
import { EmployeeRoutingModule } from './employee.routing.module';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeEditComponent } from './employee-edit/employee-edit.component';

@NgModule({
    imports: [
        CommonModule,
        EmployeeRoutingModule
    ],
    exports: [],
    declarations: [
        EmployeeComponent,
        EmployeeEditComponent,
        EmployeeListComponent
    ],
    providers: [],
})
export class EmployeeModule { }
