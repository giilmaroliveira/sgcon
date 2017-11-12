import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import { HttpBaseService } from './http-base.service';
import { ApiRoutesService } from '../apiRoutes/apiRoutes.service'

@Injectable()
export class CondominiumService {

    constructor(
        private _http: Http,
        private _httpBase: HttpBaseService,
        private _apiRoute: ApiRoutesService
    ) { }

    getCondominiumById(id: number): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getCondomiumById') + id;

        return this._httpBase.get(url, "Condomínio");
    }

    getAllCondominium(): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getAllCondomium');

        return this._httpBase.get(url, "Condomínio");
    }
}