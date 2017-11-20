import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// components
import { CompanyComponent } from './company.component';
import { CompanyRoutingModule } from './company.routing.module';
import { CompanyListComponent } from './company-list/company-list.component';
// routs
import { CompanyEditComponent } from './company-edit/company-edit.component';


@NgModule({
    imports: [
        CommonModule,
        CompanyRoutingModule,
    ],

    exports: [

    ],
    declarations: [
        CompanyComponent,
        CompanyListComponent,
        CompanyEditComponent,
    ],
})
export class CompanyModule { }
