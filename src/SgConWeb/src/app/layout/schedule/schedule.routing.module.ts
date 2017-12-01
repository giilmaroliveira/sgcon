import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
// components
import { ScheduleListComponent } from './schedule-list/schedule-list.component';
import { ScheduleEditComponent } from './schedule-edit/schedule-edit.component';
import { ScheduleComponent } from './schedule.component';

const routes: Routes = [
  { path: '', component: ScheduleComponent,
  children: [
    { path: 'scheduleList', component: ScheduleListComponent},
    { path: 'scheduleEdit', component: ScheduleEditComponent},
    { path: 'scheduleEdit/:id', component: ScheduleEditComponent }
  ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ScheduleRoutingModule { }
