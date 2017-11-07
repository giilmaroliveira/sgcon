import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CompanyComponent } from './company.component';
import { CompanyListComponent } from './company-list/company-list.component';
import { CompanyEditComponent } from './company-edit/company-edit.component';

const routes: Routes = [
  { path: '', component: CompanyComponent, 
  children: [
      { path: 'companyList', component: CompanyListComponent },
      { path: 'companyEdit', component: CompanyEditComponent }
    ] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CompanyRoutingModule { }