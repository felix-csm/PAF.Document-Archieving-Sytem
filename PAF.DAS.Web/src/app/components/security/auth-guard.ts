import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { CurrentUserSvc } from '../../services/current-user.service';
import { CurrentUser } from '../../models/current-user';


@Injectable()
export class AuthGuard implements CanActivate {
    currentUser: CurrentUser;

    constructor(
        private router: Router,
        private currentUserSvc: CurrentUserSvc
    ) {
        this.currentUserSvc.currentUser$.subscribe(
            value => this.currentUser = value
        );
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (!!!this.currentUser.isAdmin) {
            if (state.url.lastIndexOf('/new-paper') > -1 ||
                state.url.lastIndexOf('/papers') > -1) {
               this.redirectToLogin(state.url);
            }
        }
        if (!!!this.currentUser.id) {
            this.redirectToLogin(state.url);
        }
        return true;
    }
    redirectToLogin(url) {
        this.currentUserSvc.signOut();
        this.router.navigate(['/login'], { queryParams: { returnUrl: url } });
    }
}
