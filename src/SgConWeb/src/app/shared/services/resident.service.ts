import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';
import { HttpBaseService } from './http-base.service';
import { ApiRoutesService } from '../apiRoutes/apiRoutes.service'

@Injectable()
export class ResidentService {

    constructor(
        private _http: Http,
        private _httpBase: HttpBaseService,
        private _apiRoute: ApiRoutesService
    ) { }

    getResidentById(id: number): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getResidentById') + id;

        return this._httpBase.get(url, 'Morador');
    }

    getAllResident(): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getAllResident');

        return this._httpBase.get(url, 'Morador');
    }

    postResident(resident): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('postResident');

        return this._httpBase.post(url, resident, 'Morador');
    }

    updateResident(resident, id): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('updateResident') + id;

        return this._httpBase.put(url, resident, 'Morador');
    }

    deleteResident(id): Observable<any> {

        const url = this._apiRoute.getApiRouteByAlias('deleteResident') + id;

        return this._httpBase.delete(url, 'Morador');
    }

    consultingCep(cep) {

        // Nova variável cep somente com dígitos.
        cep = cep.replace(/\D/g, '');
        // Verifica se campo cep possui valor informado.
        if (cep !== '') {
            // Expressão regular para validar o CEP.
            const validacep = /^[0-9]{8}$/;
            // Valida o formato do CEP.
            if (validacep.test(cep)) {
                return this._http.get(`//viacep.com.br/ws/${cep}/json`)
            }
        }
    }
}
