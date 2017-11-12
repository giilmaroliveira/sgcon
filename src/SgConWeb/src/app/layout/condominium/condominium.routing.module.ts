import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CondominiumComponent } from './condominium.component';
import { CondominiumListComponent } from './condominium-list/condominium-list.component';
import { CondominiumEditComponent } from './condominium-edit/condominium-edit.component';

const routes: Routes = [
  { path: '', component: CondominiumComponent ,
  children: [
    { path: 'condominiumList', component: CondominiumListComponent },
    { path: 'condominiumEdit', component: CondominiumEditComponent },
    { path: 'condominiumEdit/:id', component: CondominiumEditComponent }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CondominioumRoutingModule { }