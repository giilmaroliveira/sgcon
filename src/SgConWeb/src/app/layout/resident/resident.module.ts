import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResidentRoutingModule } from './resident.routing.module';

import { ResidentComponent } from './resident.component';
import { ResidentListComponent } from './resident-list/resident-list.component';
import { ResidentEditComponent } from './resident-edit/resident-edit.component';

@NgModule({
    imports: [
        CommonModule,
        ResidentRoutingModule
    ],
    exports: [],
    declarations: [
        ResidentComponent,
        ResidentEditComponent,
        ResidentListComponent
    ],
})
export class ResidentModule { }
