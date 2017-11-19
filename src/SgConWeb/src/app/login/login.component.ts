import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../router.animations';

import { AuthService } from '../shared/services/auth.service';
import { LoginService } from '../shared/services/login.service';

import { User } from '../shared/entities/user.model';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    animations: [routerTransition()]
})
export class LoginComponent implements OnInit {

    user: User = new User();
    routeStr: string;

    constructor(
        private _router: Router,
        private _loginService: LoginService,
        private _authService: AuthService
    ) {
    }

    ngOnInit() {
    }

    // onLoggedin() {
    //     localStorage.setItem('isLoggedin', 'true');
    // }

    login() {

        this.routeStr = "loginEmployee";

        this._loginService.login(this.user, this.routeStr)
            .subscribe(response => {
                this.user.token = response.access_token;
                this._authService.employeeLogin(this.user);
            }, error => {
                console.log(error);
            });
    }

    logout() {

        this._authService.logout();
    }

}
