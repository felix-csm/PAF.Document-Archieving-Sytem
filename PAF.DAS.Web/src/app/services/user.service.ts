import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClient } from '@angular/common/http';

import { AppSettings } from '../app.settings';
import { UserInfo } from '../models/user-info';
import { ChangePasswordUser } from '../models/change-password';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class UserSvc {
    errorMessage: string;

    constructor(private http: HttpClient) { }

    getAll(): Promise<UserInfo[]> {
        const url = `${AppSettings.API_URL}/users`;
        return this.http.get(url)
            .toPromise()
            .then(response => response as UserInfo[])
            .catch(this.handleError);
    }

    changePassword(user: ChangePasswordUser): Promise<ChangePasswordUser> {
        const url = `${AppSettings.API_URL}/users/${user.id}/reset`;
        return this.http.put(url, user)
            .toPromise()
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.error);
    }
}
