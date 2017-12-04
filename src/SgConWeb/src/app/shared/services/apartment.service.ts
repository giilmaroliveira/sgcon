import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import { HttpBaseService } from './http-base.service';
import { ApiRoutesService } from '../apiRoutes/apiRoutes.service'

@Injectable()
export class ApartmentService {

    constructor(
        private _http: Http,
        private _httpBase: HttpBaseService,
        private _apiRoute: ApiRoutesService
    ) { }

    getApartmentById(id: number): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getApartmentById') + id;

        return this._httpBase.get(url, 'Apartamento');
    }

    getAllApartment(): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getAllApartment');

        return this._httpBase.get(url, 'Apartamento');
    }

    postApartment(apartment): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('postApartment');

        return this._httpBase.post(url, apartment, 'Apartamento');
    }

    updateApartment(apartment, id): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('updateApartment') + id;

        return this._httpBase.put(url, apartment, 'Apartamento');
    }

    deleteApartment(id): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('deleteApartment') + id;

        return this._httpBase.delete(url, 'Apartamento');
    }

    getApartmentTowerId(id: number): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getApartmentByTowerId') + id;

        return this._httpBase.get(url, 'Apartamento');
    }

    getCondominiumById(id: number): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getCondomiumById') + id;

        return this._httpBase.get(url, 'Condomínio');
    }
}
