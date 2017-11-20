import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// components
import { ApartmentComponent } from './apartment.component';
import { ApartmentListComponent } from './apartment-list/apartment-list.component';
import { ApartmentEditComponent } from './apartment-edit/apartment-edit.component';

// services
import { ApartmentService } from './../../shared/services/apartment.service';
import { CondominiumService } from './../../shared/services/condominium.service';
import { TowerService } from './../../shared/services/tower.service';

// routs
import { ApartmentRoutingModule } from './apartment.routing.module';


@NgModule({
    imports: [
        CommonModule,
        ApartmentRoutingModule,
        FormsModule,
        ReactiveFormsModule
    ],
    exports: [],

    declarations: [
        ApartmentComponent,
        ApartmentEditComponent,
        ApartmentListComponent
    ],
    providers: [
        TowerService,
        CondominiumService,
        ApartmentService
    ],
})
export class ApartmentModule { }
