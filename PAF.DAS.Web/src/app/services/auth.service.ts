import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClient } from '@angular/common/http';

import { AppSettings } from '../app.settings';
import { PaperArchive } from '../models/paper-archive';

import 'rxjs/add/operator/toPromise';
import { Login } from '../models/login';
import { CurrentUser } from '../models/current-user';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AuthSvc {
    constructor(
        private http: HttpClient
    ) { }

    signIn(login: Login): Observable<any> {
        const url = `${AppSettings.API_URL}/user/sign-in`;
        return this.http.post(url, login);
    }

    signOut(): Promise<any> {
        const url = `${AppSettings.API_URL}/user/sign-out`;
        return this.http.get(url)
            .toPromise()
            .then()
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.error || error);
    }
}
