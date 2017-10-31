import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { CurrentUserSvc } from '../../services/current-user.service';
import { CurrentUser } from '../../models/current-user';

import { Subscription } from 'rxjs/Subscription';
@Injectable()
export class AuthGuard implements CanActivate {
    userNameSubs: Subscription;
    currentUser: CurrentUser;

    constructor(
        private router: Router,
        private currentUserSvc: CurrentUserSvc
    ) {
        this.currentUserSvc.currentUser.subscribe(
            item => {
                this.currentUser = item;
            }
        );
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.currentUser) {
            return true;
        }

        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}
