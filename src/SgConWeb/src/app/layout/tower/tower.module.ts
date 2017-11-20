import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// components
import { TowerComponent } from './tower.component';
import { TowerListComponent } from '../../layout/tower/tower-list/tower-list.component';
import { TowerEditComponent } from '../../layout/tower/tower-edit/tower-edit.component';

// services
import { TowerService } from '../../shared/services/tower.service';
import { CondominiumService } from '../../shared/services/condominium.service';

// routs
import { TowerRoutingModule } from 'app/layout/tower/tower.routing.module';


@NgModule({
    imports: [
        CommonModule,
        TowerRoutingModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    exports: []
    ,
    declarations: [
        TowerComponent,
        TowerListComponent,
        TowerEditComponent
    ],
    providers: [
        TowerService,
        CondominiumService
    ],
})
export class TowerModule { }
