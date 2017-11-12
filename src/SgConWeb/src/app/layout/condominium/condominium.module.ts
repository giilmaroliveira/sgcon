import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Components
import { CondominiumComponent } from './condominium.component';
import { CondominiumListComponent } from './condominium-list/condominium-list.component';
import { CondominiumEditComponent } from './condominium-edit/condominium-edit.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// Modules
import { CondominioumRoutingModule } from './condominium.routing.module';

// Services
import { CondominiumService } from '../../shared/services/condominium.service';

@NgModule({
    imports: [
        CommonModule,
        CondominioumRoutingModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    exports: [],
    declarations: [
        CondominiumComponent,
        CondominiumEditComponent,
        CondominiumListComponent
    ],
    providers: [
        CondominiumService
    ]
})
export class CondominiumModule { }
