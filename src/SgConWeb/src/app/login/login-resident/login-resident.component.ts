import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../../router.animations';

import { AuthService } from '../../shared/services/auth.service';
import { LoginService } from '../../shared/services/login.service';

import { User } from '../../shared/entities/user.model';

@Component({
  selector: 'app-login-resident',
  templateUrl: './login-resident.component.html',
  styleUrls: ['./login-resident.component.scss'],
  animations: [routerTransition()]
})
export class LoginResidentComponent implements OnInit {

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

  login() {

      this.routeStr = "loginResident";

      this._loginService.login(this.user, this.routeStr)
          .subscribe(response => {
              this.user.token = response.access_token;
              this._authService.residentLogin(this.user);
          }, error => {
              console.log(error);
          });
  }

  logout() {

      this._authService.logout();
  }

}
