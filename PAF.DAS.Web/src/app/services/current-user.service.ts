import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { CurrentUser } from '../models/current-user';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CurrentUserSvc {
    _currentUser = new BehaviorSubject<CurrentUser>(new CurrentUser());

    setCurrentUser(token: string) {
        localStorage.setItem('token', token);
        const tokenData = token.split('.')[1];
        const jsonData = JSON.parse(window.atob(tokenData));

        const newUser = new CurrentUser();
        newUser.id = jsonData.id;
        newUser.email = jsonData.email;
        newUser.isAdmin = jsonData.isAdmin;

        this._currentUser.next(newUser);
    }

    get currentUser(): Observable<CurrentUser> {
        return this._currentUser.asObservable();
    }

    signOut(): void {
        localStorage.removeItem('token');
        this._currentUser.next(new CurrentUser());
    }
}
