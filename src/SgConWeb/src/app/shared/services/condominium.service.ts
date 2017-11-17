import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
// tslint:disable-next-line:import-blacklist
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

        return this._httpBase.get(url, 'Condomínio');
    }

    getAllCondominium(): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getAllCondomium');

        return this._httpBase.get(url, 'Condomínio');
    }

    postCondominium(condominium): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('postCondominium');

        return this._httpBase.post(url, condominium, 'Condomínio');
    }

    updateCondominium(condominium, id): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('updateCondominium') + id;

        return this._httpBase.put(url, condominium, 'Condomínio');
    }

    deleteCondominium(id): Observable<any> {

        const url = this._apiRoute.getApiRouteByAlias('deleteCondominium') + id;

        return this._httpBase.delete(url, 'Condomínio');
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
