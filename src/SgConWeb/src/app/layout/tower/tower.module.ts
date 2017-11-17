import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TowerComponent } from './tower.component';
import { TowerRoutingModule } from 'app/layout/tower/tower.routing.module';
import { TowerListComponent } from 'app/layout/tower/tower-list/tower-list.component';
import { TowerEditComponent } from 'app/layout/tower/tower-edit/tower-edit.component';
import { TowerService } from 'app/shared/services/tower.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

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
    ],
})
export class TowerModule { }
