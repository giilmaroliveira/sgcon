import { CommonModule } from '@angular/common';
import { FormModule } from './../form/form.module';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

// routs
import { ResidentRoutingModule } from './resident.routing.module';

// services
import { ResidentService } from './../../shared/services/resident.service';

// components
import { ResidentComponent } from './resident.component';
import { ResidentListComponent } from './resident-list/resident-list.component';
import { ResidentEditComponent } from './resident-edit/resident-edit.component';

@NgModule({
    imports: [
        CommonModule,
        ResidentRoutingModule,
        FormModule,
        ReactiveFormsModule

    ],
    exports: [],
    declarations: [
        ResidentComponent,
        ResidentEditComponent,
        ResidentListComponent
    ],
    providers: [
        ResidentService
    ]
})
export class ResidentModule { }
