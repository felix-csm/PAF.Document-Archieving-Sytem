import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { Login } from '../../models/login';
import { AuthSvc } from '../../services/auth.service';
import { CurrentUserSvc } from '../../services/current-user.service';

@Component({
    selector: 'app-auth-login',
    templateUrl: './auth-login.component.html',
    providers: [AuthSvc, CurrentUserSvc]
})

export class AuthComponent {
    errorMessage: string;
    model: Login;

    constructor(
        private authSvc: AuthSvc,
        private currentUserSvc: CurrentUserSvc,
        private route: ActivatedRoute,
        private router: Router,
    ) {
        this.model = new Login();
        this.model.email = '';
        this.model.password = '';
        localStorage.setItem('currentUser', '');
    }

    onSubmit(login) {
        this.authSvc.signIn(this.model)
        .then(response => {
            this.currentUserSvc.setCurrentUser(response.access_token);
            this.redirectToHome();
        }, error => this.errorMessage = <any>error);
    }

    redirectToHome() {
        this.router.navigate(['dashboard']);
    }
}
