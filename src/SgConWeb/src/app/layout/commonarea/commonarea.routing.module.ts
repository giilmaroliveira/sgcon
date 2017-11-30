import { CommonareaListComponent } from './commonarea-list/commonarea-list.component';
import { CommonareaEditComponent } from './commonarea-edit/commonarea-edit.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CommonareaComponent } from './commonarea.component';

const routes: Routes = [
  { path: '', component: CommonareaComponent,
  children: [
    { path: 'commonareaList', component: CommonareaListComponent },
    { path: 'commonareaEdit', component: CommonareaEditComponent },
    { path: 'commonareaEdit/:id', component: CommonareaEditComponent }
  ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CommonareaRoutingModule { }
