import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CondominioRoutingModule } from './condominio.routing.module';
import { CondominioComponent } from './condominio.component';
import { CondominioListComponent } from './list/condominio.component';
import { CondominioEditComponent } from './edit/condominio.component';

@NgModule({
  imports: [
    CommonModule,
    CondominioRoutingModule
  ],
  declarations: [
    CondominioComponent,
    CondominioListComponent,
    CondominioEditComponent
]
})
export class CondominioModule { }
