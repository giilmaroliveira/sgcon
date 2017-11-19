import { Injectable } from '@angular/core';
import { ApiRoute } from './apiRoute';
import { environment } from '../../../environments/environment';

@Injectable()
export class ApiRoutesService {
  baseUrl: string = environment.apiUrl;
  routes: ApiRoute[];

  constructor() {
      this.routes = [

        // condominium
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

        // apartment
        { alias: 'getApartmentById', verb: 'get', path: '/api/apartment/' },
        { alias: 'getAllApartment', verb: 'get', path: '/api/apartment/' },
        { alias: 'postApartment', verb: 'post', path: '/api/apartment/' },
        { alias: 'updateApartment', verb: 'put', path: '/api/apartment/' },
        { alias: 'deleteApartment', verb: 'delete', path: '/api/Apartment/' },
        { alias: 'getApartmentByCondominiumId', verb: 'get', path: '/api/apartment/condominium/' },
        { alias: 'getApartmentByTowerId', verb: 'get', path: '/api/apartment/tower/' },

      ];
  }

  getApiRouteByAlias(alias: string): string {
    return this.baseUrl + this.routes.find(route => route.alias === alias).path;
  }

}
