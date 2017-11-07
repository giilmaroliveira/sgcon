import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CondominioComponent } from './condominio.component';
import { CondominioRoutingModule } from './condominio.routing.module';
import { CondominioSelectComponent } from './condominio-select/condominio-select.component';
import { CondominioInsertComponent } from './condominio-insert/condominio-insert.component';

@NgModule({
  imports: [
    CommonModule,
    CondominioRoutingModule,
  ],
  declarations: [
    CondominioComponent,
    CondominioSelectComponent,
    CondominioInsertComponent,
]
})
export class CondominioModule { }
