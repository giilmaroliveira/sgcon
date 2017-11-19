import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

import { LoginComponent } from '../../login/login.component';

// Models
import { User } from '../entities/user.model';
import { LoginResponse } from '../entities/loginResponse.model';

// Services
import { HttpBaseService } from './http-base.service';
import { ApiRoutesService } from '../apiRoutes/apiRoutes.service';

@Injectable()
export class LoginService {

    headers: Headers;

    constructor(
        private _http: Http,
        private _httpBase: HttpBaseService,
        private _apiRoute: ApiRoutesService) {
    }

    login(user: User, routeAlias: string): Observable<LoginResponse> {

        let body = JSON.stringify(user);
        let url = this._apiRoute.getApiRouteByAlias(routeAlias);

        return this._httpBase.post(url, body, "Login de Usuário");
    }

    // logout() {

    // }

    // getUserMe(userType: string): Observable<User> {
    //     let url;
        
    //     if (userType === 'Internal')
    //         url = this._apiRoute.getApiRouteByAlias('getEmployeeMe');
    //     else if(userType === 'External')
    //         url = this._apiRoute.getApiRouteByAlias('getCustomerMe');

    //     return this._httpBase.get(url, "Me");
    // }
}