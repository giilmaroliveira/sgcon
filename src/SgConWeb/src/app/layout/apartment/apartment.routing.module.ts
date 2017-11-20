import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ApartmentComponent } from './apartment.component';
import { ApartmentListComponent } from './apartment-list/apartment-list.component';
import { ApartmentEditComponent } from './apartment-edit/apartment-edit.component';

const routes: Routes = [
  { path: '', component: ApartmentComponent,
  children: [
    { path: 'apartmentList', component: ApartmentListComponent },
    { path: 'apartmentEdit', component: ApartmentEditComponent },
    { path: 'apartmentEdit/:id', component: ApartmentEditComponent }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ApartmentRoutingModule { }
