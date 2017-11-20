import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login-employee/login.component';
import { LoginResidentComponent } from './login-resident/login-resident.component';

const routes: Routes = [
    { path: '', component: LoginComponent },
    { path: 'resident', component: LoginResidentComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
