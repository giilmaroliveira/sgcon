import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CondominiumComponent } from './condominium.component';
import { CondominioumRoutingModule } from './condominium.routing.module';
import { CondominiumListComponent } from './condominium-list/condominium-list.component';
import { CondominiumEditComponent } from './condominium-edit/condominium-edit.component';

@NgModule({
    imports: [
        CommonModule,
        CondominioumRoutingModule
    ],
    exports: [],
    declarations: [
        CondominiumComponent,
        CondominiumEditComponent,
        CondominiumListComponent
    ],
})
export class CondominiumModule { }