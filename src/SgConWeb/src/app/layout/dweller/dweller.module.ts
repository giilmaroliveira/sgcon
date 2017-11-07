import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DwellerComponent } from './dweller.component';
import { DwellerRoutingModule } from './dweller.routing.module';
import { DwellerListComponent } from './dweller-list/dweller-list.component';
import { DwellerEditComponent } from './dweller-edit/dweller-edit.component';

@NgModule({
    imports: [
        CommonModule,
        DwellerRoutingModule
    ],
    exports: [],
    declarations: [
        DwellerComponent,
        DwellerEditComponent,
        DwellerListComponent
    ],
})
export class DwellerModule { }
