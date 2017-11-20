import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import { HttpBaseService } from './http-base.service';
import { ApiRoutesService } from '../apiRoutes/apiRoutes.service'

@Injectable()
export class TowerService {

    constructor(
        private _http: Http,
        private _httpBase: HttpBaseService,
        private _apiRoute: ApiRoutesService
    ) { }

    getTowerById(id: number): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getTowerById') + id;

        return this._httpBase.get(url, 'Torre');
    }

    getAllTower(): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getAllTower');

        return this._httpBase.get(url, 'Torre');
    }

    postTower(tower): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('postTower');

        return this._httpBase.post(url, tower, 'Torre');
    }

    updateTower(tower, id): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('updateTower') + id;

        return this._httpBase.put(url, tower, 'Torre');
    }

    deleteTower(id): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('deleteTower') + id;

        return this._httpBase.delete(url, 'Torre');
    }

    getTowerCondominiumId(id: number): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getTowerByCondominiumId') + id;

        return this._httpBase.get(url, 'Torre');
    }
}
