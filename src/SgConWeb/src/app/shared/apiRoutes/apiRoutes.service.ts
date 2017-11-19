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

        // tower
        { alias: 'getTowerById', verb: 'get', path: '/api/tower/' },
        { alias: 'getAllTower', verb: 'get', path: '/api/tower/' },
        { alias: 'postTower', verb: 'post', path: '/api/tower/' },
        { alias: 'updateTower', verb: 'put', path: '/api/tower/' },
        { alias: 'deleteTower', verb: 'delete', path: '/api/tower/' },
        { alias: 'getTowerByCondominiumId', verb: 'get', path: '/api/tower/condominium/' },

        // login
        { alias: 'loginEmployee', verb: 'post', path: '/api/token/employee/' },
        { alias: 'loginResident', verb: 'post', path: '/api/token/resident/' },

      ];
  }

  getApiRouteByAlias(alias: string): string {
    return this.baseUrl + this.routes.find(route => route.alias === alias).path;
  }

}