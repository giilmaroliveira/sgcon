import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
// components
import { CompanyComponent } from './company.component';
import { CompanyRoutingModule } from './company.routing.module';
import { CompanyListComponent } from './company-list/company-list.component';
// routs
import { CompanyEditComponent } from './company-edit/company-edit.component';

// service
import { CompanyService } from './../../shared/services/company.service';



@NgModule({
    imports: [
        CommonModule,
        CompanyRoutingModule,
        FormsModule,
        ReactiveFormsModule,
    ],

    exports: [

    ],
    declarations: [
        CompanyComponent,
        CompanyListComponent,
        CompanyEditComponent,
    ],
    providers: [
        CompanyService
    ]
})
export class CompanyModule { }
