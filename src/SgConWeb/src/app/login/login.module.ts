import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';

import { AuthService } from '../shared/services/auth.service';
import { LoginService } from '../shared/services/login.service';

@NgModule({
    imports: [
        CommonModule,
        LoginRoutingModule,
        // ActivatedRoute,
        FormsModule,
        ReactiveFormsModule
    ],
    declarations: [
        LoginComponent
    ],
    providers: [
        AuthService,
        LoginService
    ]

})
export class LoginModule {
}
