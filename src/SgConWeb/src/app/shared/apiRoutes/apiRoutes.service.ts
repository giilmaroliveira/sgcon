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

        // commonarea
        { alias: 'getCommonareaById', verb: 'get', path: '/api/commonarea/' },
        { alias: 'getAllCommonarea', verb: 'get', path: '/api/commonarea/' },
        { alias: 'postCommonarea', verb: 'post', path: '/api/commonarea/' },
        { alias: 'updateCommonarea', verb: 'put', path: '/api/commonarea/' },
        { alias: 'deleteCommonarea', verb: 'delete', path: '/api/commonarea/' },
        { alias: 'getCommonareaByCondominiumId', verb: 'get', path: '/api/commonarea/condominium/' },
        { alias: 'postCommonAreaSchedule', verb: 'post', path: '/api/commonarea/schedule' },

        // company
        { alias: 'getCompanyById', verb: 'get', path: '/api/company/' },
        { alias: 'getAllCompany', verb: 'get', path: '/api/company/' },
        { alias: 'postCompany', verb: 'post', path: '/api/company/' },
        { alias: 'updateCompany', verb: 'put', path: '/api/company/' },
        { alias: 'deleteCompany', verb: 'delete', path: '/api/company/' },

        // employee
        { alias: 'getEmployeeById', verb: 'get', path: '/api/employee/' },
        { alias: 'getAllEmployee', verb: 'get', path: '/api/employee/' },
        { alias: 'postEmployee', verb: 'post', path: '/api/employee/' },
        { alias: 'updateEmployee', verb: 'put', path: '/api/employee/' },
        { alias: 'deleteEmployee', verb: 'delete', path: '/api/employee/' },

        // resident
        { alias: 'getResidentById', verb: 'get', path: '/api/resident/' },
        { alias: 'getAllResident', verb: 'get', path: '/api/resident/' },
        { alias: 'postResident', verb: 'post', path: '/api/resident/' },
        { alias: 'updateResident', verb: 'put', path: '/api/resident/' },
        { alias: 'deleteResident', verb: 'delete', path: '/api/resident/' },

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
        { alias: 'getApartmentByTowerId', verb: 'get', path: '/api/apartment/tower/' },

        // login
        { alias: 'loginEmployee', verb: 'post', path: '/api/token/employee/' },
        { alias: 'loginResident', verb: 'post', path: '/api/token/resident/' },

      ];
  }

  getApiRouteByAlias(alias: string): string {
    return this.baseUrl + this.routes.find(route => route.alias === alias).path;
  }

}
