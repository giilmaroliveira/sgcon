import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CondominioComponent } from './condominio.component';
import { CondominioListComponent } from './list/condominio.component';
import { CondominioEditComponent } from './edit/condominio.component';

const routes: Routes = [
    { path: '', component: CondominioComponent ,
    children: [
        { path: 'list', component: CondominioListComponent },
        { path: 'edit', component: CondominioEditComponent }
        ]}
    ];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CondominioRoutingModule { }
