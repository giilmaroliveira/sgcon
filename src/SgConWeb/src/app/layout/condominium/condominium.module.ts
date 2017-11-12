import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CondominiumComponent } from './condominium.component';
import { CondominioumRoutingModule } from './condominium.routing.module';
import { CondominiumListComponent } from './condominium-list/condominium-list.component';
import { CondominiumEditComponent } from './condominium-edit/condominium-edit.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

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
})
export class CondominiumModule { }
