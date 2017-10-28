import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { CurrentUser } from '../models/currentUser';
import { Router, ActivatedRoute } from '@angular/router';

@Injectable()
export class CurrentUserSvc {
    private announceUsername = new BehaviorSubject<string>('');

    constructor(
        private router: Router,
        private route: ActivatedRoute) { }

    broadcastLoggedUsername(username: string) {
        this.announceUsername.next(username);
    }

    get loggedUsername$() {
        return this.announceUsername.asObservable();
    }

    redirectAfterLoggedIn(data: CurrentUser) {
        const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        this.router.navigate([returnUrl]);
    }
}
