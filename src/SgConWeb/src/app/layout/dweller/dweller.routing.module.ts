import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DwellerComponent } from './dweller.component';
import { DwellerEditComponent } from './dweller-edit/dweller-edit.component';
import { DwellerListComponent } from './dweller-list/dweller-list.component';

const routes: Routes = [
  { path: '', component: DwellerComponent,
  children: [
    { path: 'dwellerList', component: DwellerListComponent},
    { path: 'dwellerEdit', component: DwellerEditComponent}
  ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DwellerRoutingModule { }
