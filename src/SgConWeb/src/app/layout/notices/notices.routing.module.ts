import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NoticesComponent } from './notices.component';
import { NoticesEditComponent } from './notices-edit/notices-edit.component';
import { NoticesListComponent } from './notices-list/notices-list.component';

const routes: Routes = [
  { path: '', component: NoticesComponent,
  children:[
    { path: 'noticesList', component: NoticesListComponent},
    { path: 'noticesEdit', component: NoticesEditComponent}
  ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NoticeRoutingModule { }