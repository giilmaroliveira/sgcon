import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CondominioComponent } from './condominio.component';

const routes: Routes = [
    { path: '', component: CondominioComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CondominioRoutingModule { }
