import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TowerComponent } from './tower.component';
import { TowerListComponent } from './tower-list/tower-list.component';
import { TowerEditComponent } from './tower-edit/tower-edit.component';
import { GenerateApartmentComponent } from './generate-apartment/generate-apartment.component';

const routes: Routes = [
  { path: '', component: TowerComponent,
  children: [
    { path: 'towerList', component: TowerListComponent },
    { path: 'towerEdit', component: TowerEditComponent },
    { path: 'towerEdit/:id', component: TowerEditComponent },
    { path: 'generateApartments', component: GenerateApartmentComponent }
  ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TowerRoutingModule { }
