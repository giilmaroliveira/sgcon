import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';
import { HttpBaseService } from './http-base.service';
import { ApiRoutesService } from '../apiRoutes/apiRoutes.service'

@Injectable()
export class EmployeeService {

    constructor(
        private _http: Http,
        private _httpBase: HttpBaseService,
        private _apiRoute: ApiRoutesService
    ) { }

    getEmployeeById(id: number): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getEmployeeById') + id;

        return this._httpBase.get(url, 'Empresa');
    }

    getAllEmployee(): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('getAllEmployee');

        return this._httpBase.get(url, 'Empresa');
    }

    postEmployee(employee): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('postEmployee');

        return this._httpBase.post(url, employee, 'Empresa');
    }

    updateEmployee(employee, id): Observable<any> {

        let url = this._apiRoute.getApiRouteByAlias('updateEmployee') + id;

        return this._httpBase.put(url, employee, 'Empresa');
    }

    deleteEmployee(id): Observable<any> {

        const url = this._apiRoute.getApiRouteByAlias('deleteEmployee') + id;

        return this._httpBase.delete(url, 'Empresa');
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
