import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TowerComponent } from './tower.component';
import { TowerListComponent } from 'app/layout/tower/tower-list/tower-list.component';
import { TowerEditComponent } from 'app/layout/tower/tower-edit/tower-edit.component';

const routes: Routes = [
  { path: '', component: TowerComponent,
  children: [
    { path: 'towerList', component: TowerListComponent },
    { path: 'towerEdit', component: TowerEditComponent },
    { path: 'towerEdit/:id', component: TowerEditComponent }
  ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TowerRoutingModule { }
