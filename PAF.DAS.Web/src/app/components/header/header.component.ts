import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { AppRoutingModule } from '../../app.routing.module';
import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
})

export class HeaderComponent implements OnDestroy {
    title = 'header';
    showCurrentUser = false;
    subscription: Subscription;
    private userName: string;

    constructor(private appRouting: AppRoutingModule,
        //private loginService: LoginService,
        private router: Router,
        //private currentUserService: CurrentUserService
    ) {
        // subscribed to the changes made during login
        // this.subscription = this.currentUserService.loggedUsername$.subscribe(
        //     item => {
        //         this.userName = item;
        //         this.showCurrentUser = this.userName !== '';
        //     }
        // );
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    logoutUser() {
        //this.loginService.logout();
        // clear logged username
        //this.currentUserService.broadcastLoggedUsername('');
        this.router.navigate(['/login']);
    }
}
