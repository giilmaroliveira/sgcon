import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import { HttpBaseService } from './http-base.service';
import { ApiRoutesService } from '../apiRoutes/apiRoutes.service'

@Injectable()
export class CommonareaService {

    constructor(
        private _http: Http,
        private _httpBase: HttpBaseService,
        private _apiRoute: ApiRoutesService
    ) { }

    getCommonareaById(id: number): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getCommonareaById') + id;

        return this._httpBase.get(url, 'Areas Comuns');
    }

    getAllCommonarea(): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getAllCommonarea');

        return this._httpBase.get(url, 'Areas Comuns');
    }

    postCommonarea(commonarea): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('postCommonarea');

        return this._httpBase.post(url, commonarea, 'Areas Comuns');
    }

    updateCommonarea(commonarea, id): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('updateCommonarea') + id;

        return this._httpBase.put(url, commonarea, 'Areas Comuns');
    }

    deleteCommonarea(id): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('deleteCommonarea') + id;

        return this._httpBase.delete(url, 'Areas Comuns');
    }

    getCommonareaCondominiumId(id: number): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getCommonareaByCondominiumId') + id;

        return this._httpBase.get(url, 'Areas Comuns');
    }
}
