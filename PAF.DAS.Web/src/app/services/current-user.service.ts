import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { CurrentUser } from '../models/current-user';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class CurrentUserSvc {
    private _currentUser = new BehaviorSubject<CurrentUser>(new CurrentUser());

    get currentUser$() {
        const token = localStorage.getItem('token');
        if (token) {
            const tokenData = token.split('.')[1];
            const jsonData = JSON.parse(window.atob(tokenData));

            const newUser = new CurrentUser();
            newUser.id = jsonData.id;
            newUser.email = jsonData.email;
            newUser.isAdmin = jsonData.isAdmin;

            this._currentUser.next(newUser);
        }
        return this._currentUser.asObservable();
    }

    setToken(token: string) {
        localStorage.setItem('token', token);

        const tokenData = token.split('.')[1];
        const jsonData = JSON.parse(window.atob(tokenData));

        const newUser = new CurrentUser();
        newUser.id = jsonData.id;
        newUser.email = jsonData.email;
        newUser.isAdmin = jsonData.isAdmin;

        this._currentUser.next(newUser);
    }

    signOut(): void {
        localStorage.removeItem('token');
        this._currentUser.next(new CurrentUser());
    }
}
