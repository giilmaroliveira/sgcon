import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CondominioRoutingModule } from './condominio.routing.module';
import { CondominioComponent } from './condominio.component';

@NgModule({
  imports: [
    CommonModule,
    CondominioRoutingModule
  ],
  declarations: [CondominioComponent]
})
export class CondominioModule { }
