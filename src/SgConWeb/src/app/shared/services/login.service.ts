import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

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

    getUserMe(userType: string): Observable<User> {
        let url;
        
        if (userType === 'Employee')
            url = this._apiRoute.getApiRouteByAlias('getEmployeeMe');
        else if(userType === 'Resident')
            url = this._apiRoute.getApiRouteByAlias('getResidentMe');

        return this._httpBase.get(url, "Me");
    }
}