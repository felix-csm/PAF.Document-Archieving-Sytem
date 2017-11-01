import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { CurrentUserSvc } from '../../services/current-user.service';
import { AuthSvc } from '../../services/auth.service';
import { CurrentUser } from '../../models/current-user';

import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';
@Component({
    selector: 'app-header',
    templateUrl: './header.component.html'
})

export class HeaderComponent implements OnDestroy {
    title = 'header';
    subscription: Subscription;
    isLoggedIn = false;
    email: string;

    constructor(private router: Router,
        private currentUserSvc: CurrentUserSvc,
        private authSvc: AuthSvc
    ) {
        this.subscription = this.currentUserSvc.currentUser$.subscribe(
            value => {
                this.email = value.email;
                this.isLoggedIn = !!value.id;
            }
        );
    }
    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
    logout() {
        this.authSvc.signOut().then(resp => {
            this.currentUserSvc.signOut();
            this.router.navigate(['/login']);
       });
    }
}
