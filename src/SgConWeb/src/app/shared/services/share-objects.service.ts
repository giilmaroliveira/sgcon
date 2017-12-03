import { Injectable } from '@angular/core';
import { Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { User } from '../entities/user.model';

@Injectable()
export class ShareObjectsService {
    private user: Subject<User> = new Subject<User>();
    
    constructor() { }

    setUser(value: User) {
        this.user.next(value);
    }

    getUser(): Observable<User> {
        return this.user.asObservable();
    }
}