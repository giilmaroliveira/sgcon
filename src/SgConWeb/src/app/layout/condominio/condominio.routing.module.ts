import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CondominioComponent } from './condominio.component';
import { CondominioSelectComponent } from './condominio-select/condominio-select.component';
import { CondominioInsertComponent } from './condominio-insert/condominio-insert.component';

const routes: Routes = [
    { path: '', component: CondominioComponent ,
    children: [
        { path: 'select', component: CondominioSelectComponent },
        { path: 'insert', component: CondominioInsertComponent },
    ]}
    ];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CondominioRoutingModule { }
