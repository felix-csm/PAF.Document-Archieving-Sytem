import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { CurrentUserSvc } from '../../services/current-user.service';
import { AuthSvc } from '../../services/auth.service';
import { CurrentUser } from '../../models/current-user';

import { Observable } from 'rxjs/Observable';
@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    providers: [AuthSvc, CurrentUserSvc]
})

export class HeaderComponent {
    title = 'header';
    showCurrentUser = false;
    private currentUser: CurrentUser;

    constructor(private router: Router,
        private currentUserSvc: CurrentUserSvc,
        private authSvc: AuthSvc
    ) {
        this.currentUserSvc.currentUser.subscribe(
            value => this.currentUser = value
        );
    }

    logout() {
        this.authSvc.signOut();
        // clear logged username
        this.currentUserSvc.signOut();
        this.router.navigate(['/login']);
    }
}
