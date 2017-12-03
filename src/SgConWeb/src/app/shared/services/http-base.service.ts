import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Response, Headers, RequestOptions, Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Component } from '@angular/core';
import { ModalComponent } from '../components/modal/modal.component';
import { DialogService } from 'ng2-bootstrap-modal';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import 'rxjs/Rx';

@Injectable()
export class HttpBaseService {
  @BlockUI() blockUI: NgBlockUI;

  public static blockIdList: number[] = new Array<number>();

  constructor(
    private _http: Http,
    private _router: Router,
    private _dialogService: DialogService
  ) {}

  startBlockUi(): number {
    let blockId = Date.now();
    // console.log("add", HttpBaseService.blockIdList, blockId);
    HttpBaseService.blockIdList.push(blockId);
    // setTimeout(() => {
    this.blockUI.start('Carregando...');
    // }, 0.001);
    return blockId;
  }

  stopBlockUi(
    observable: Observable<Response>,
    blockId: number
  ): Observable<Response> {
    return observable.finally(() => {
      if (blockId > 0) {
        // setTimeout(() => {
        HttpBaseService.blockIdList.splice(
          HttpBaseService.blockIdList.indexOf(blockId),
          1
        );
        if (HttpBaseService.blockIdList.length <= 0) {
          // setTimeout(() => {
          this.blockUI.stop();
          // }, 1500);
        }
        // }, 50);
      }
    });
  }

  getByDate(
    url: string,
    msg: string,
    filters: { [id: string]: string } = null,
    startDate = null,
    endDate = null,
    headers: { [id: string]: string } = null,
    showModal: boolean = true
  ): Observable<any> {
    let blockID = this.startBlockUi();

    let options = this.headersWithToken(
      localStorage.getItem('token'),
      filters,
      headers,
      startDate,
      endDate
    );

    return this.stopBlockUi(
      this._http
        .get(url, options)
        .map((res: Response) => res.json())
        .catch((error: any) => {
          return Observable.throw(this.handlerError(error, msg, showModal));
        }),
      blockID
    );
  }

  get(
    url: string,
    msg: string,
    filters: { [id: string]: string } = null,
    headers: { [id: string]: string } = null,
    useLoader = true,
    jsonResponse: boolean = true,
    useHeaders: boolean = true,
    showModal: boolean = true
  ): Observable<any> {
    let blockID = 0;

    if (useLoader) {
      blockID = this.startBlockUi();
    }

    let options: RequestOptions = new RequestOptions();

    // if (useHeaders)
    // 	options = this.headersWithToken(localStorage.getItem('token'), filters, headers);

    return this.stopBlockUi(
      this._http
        .get(url, options)
        .map((res: Response) => (jsonResponse ? res.json() : res))
        .catch((error: any) => {
          return Observable.throw(this.handlerError(error, msg, showModal));
        }),
      blockID
    );

    // return this._http.get(url, options);
  }

  post(
    url: string,
    body: string,
    msg: string,
    filters: { [id: string]: string } = null,
    headers: { [id: string]: string } = null,
    jsonResponse: boolean = true,
    showModal: boolean = true,
    startDate = null,
    endDate = null
  ): Observable<any> {
    let blockID = this.startBlockUi();
    let options = this.headersWithToken(
      localStorage.getItem('token'),
      filters,
      headers,
      startDate,
      endDate
    );
    return this.stopBlockUi(
      this._http
        .post(url, body, options)
        .map((res: Response) => (jsonResponse ? res.json() : res))
        .catch((error: any) => {
          return Observable.throw(this.handlerError(error, msg, showModal));
        }),
      blockID
    );
  }

  put(
    url: string,
    body: string,
    msg: string,
    filters: { [id: string]: string } = null,
    headers: { [id: string]: string } = null,
    jsonResponse: boolean = true,
    showModal: boolean = true
  ): Observable<any> {
    let blockID = this.startBlockUi();

    let options = this.headersWithToken(
      localStorage.getItem('token'),
      filters,
      headers
    );
    return this.stopBlockUi(
      this._http
        .put(url, body, options)
        .map((res: Response) => (jsonResponse ? res.json() : res))
        .catch((error: any) => {
          return Observable.throw(this.handlerError(error, msg, showModal));
        }),
      blockID
    );
  }

  delete(
    url: string,
    msg: string,
    headers: { [id: string]: string } = null,
    showModal: boolean = true
  ) {
    let blockID = this.startBlockUi();
    let options = this.headersWithToken(
      localStorage.getItem('token'),
      null,
      headers
    );

    return this.stopBlockUi(
      this._http
        .delete(url, options)
        .map((res: Response) => res)
        .catch((error: any) => {
          return Observable.throw(this.handlerError(error, msg, showModal));
        }),
      blockID
    );
  }

  headers() {
    let headersParams = { 'Content-Type': 'application/json' };
    let headers = new Headers(headersParams);
    let options = new RequestOptions({ headers: headers });
    return options;
  }

  headersWithToken(
    token: string,
    filters: { [id: string]: string } = null,
    headers: { [id: string]: string } = null,
    filterStartDate = null,
    filterEndDate = null
  ) {
    let headersParams = { 'Content-Type': 'application/json' };
    let _headers = new Headers(headersParams);

    if (token) {
      _headers.append('Authorization', 'Bearer ' + token);
    }

    if (filterStartDate) {
      _headers.append('filterStartDate', filterStartDate);
    }
    if (filterEndDate) {
      _headers.append('filterEndDate', filterEndDate);
    }

    if (filters) {
      let _filters: { [id: string]: string } = {};
      let keys = Object.keys(filters);
      keys.forEach(key => {
        if (filters[key] || filters[key] !== '') {
          _filters[key] = filters[key];
        }
      });
      _headers.append('FiltersJson', JSON.stringify(_filters));
    }
    if (headers) {
      let keys = Object.keys(headers);
      keys.forEach(key => {
        _headers.append(key, headers[key]);
      });
    }

    let options = new RequestOptions({ headers: _headers });
    return options;
  }

  intercept(observable: Observable<Response>): Observable<Response> {
    return observable
      .catch((err, source) => {
        if (err.status !== 200) {
          return Observable;
        } else {
          return Observable.throw(err);
        }
      })
      .finally(() => {
        return Observable;
      });
  }

  handlerError(error: any, type: string, showModal: boolean) {
    let message: string;
    let title: string;

    if (error.status === 0) {
      message = 'Houve um erro interno.';
      title = 'Erro';
      this.showModal(title, message, showModal);
      return message;
    }

    if (error.status === 400) {
      title = 'Erro';
      message = error._body;
      this.showModal(title, message, showModal);
      return message;
    }

    if (error.status === 401) {
      this._router.navigate(['no-permission']);
      message = 'Acesso negado.';
      title = 'Erro';
      this.showModal(title, message, showModal);
      return message;
    }

    if (error.status === 403) {
      message = 'Sem permissão para efetuar a operação.';
      title = 'Erro';
      this.showModal(title, message, showModal);
      return message;
    }

    if (error.status === 420) {
      message = error._body;
      title = 'Erro';
      this.showModal(title, message, showModal);
      return message;
    }

    if (error.status === 430) {
      message = error._body;
      title = 'Erro';
      this.showModal(title, message, showModal);
      return message;
    }
  }

  showModal(title: string, message: string, showModal: boolean) {
    if (!showModal) return;

    let disposable = this._dialogService
      .addDialog(
        ModalComponent,
        {
          title: title,
          message: message
        },
        { backdropColor: 'rgba(0, 0, 1, 0.5)' }
      )
      .subscribe(isConfirmed => {});

    window.scrollTo(0, 0);
  }
}
