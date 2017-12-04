import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
// components
import { ResidentComponent } from './resident.component';
import { ResidentEditComponent } from './resident-edit/resident-edit.component';
import { ResidentListComponent } from './resident-list/resident-list.component';

const routes: Routes = [
  { path: '', component: ResidentComponent,
  children: [
    { path: 'residentList', component: ResidentListComponent },
    { path: 'residentEdit', component: ResidentEditComponent },
    { path: 'residentEdit/:id', component: ResidentEditComponent },
  ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ResidentRoutingModule { }
