import { Component } from '@angular/core';
import { CurrentUserService } from './common/current-user.service';

@Component({
    selector: 'paf-das',
    templateUrl: './app/app.component.html'
})

export class AppComponent {
    name = 'PAF.DAS';

    constructor(private currentUserSvc: CurrentUserService) {
        const currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser) {
            this.currentUserSvc.broadcastLoggedUsername(currentUser.firstName + ' ' + currentUser.lastName);
        }
    }
}
