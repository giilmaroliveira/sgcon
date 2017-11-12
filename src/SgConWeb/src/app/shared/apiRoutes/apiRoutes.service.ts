import { Injectable } from '@angular/core';
import { ApiRoute } from './apiRoute';
import { environment } from '../../../environments/environment';

@Injectable()
export class ApiRoutesService {
  baseUrl: string = environment.apiUrl;
  routes: ApiRoute[];

  constructor() {
      this.routes = [

        //condominium
        { alias: 'getCondomiumById', verb: 'get', path: '/api/condominium/' },
        { alias: 'getAllCondomium', verb: 'get', path: '/api/condominium/' },
        { alias: 'postCondominium', verb: 'post', path: '/api/condominium/' },
        { alias: 'updateCondominium', verb: 'put', path: '/api/condominium/' },
        { alias: 'deleteCondomium', verb: 'delete', path: '/api/condominium/' },

      ];
  }

  getApiRouteByAlias(alias: string): string {
    return this.baseUrl + this.routes.find(route => route.alias === alias).path;
  }

}