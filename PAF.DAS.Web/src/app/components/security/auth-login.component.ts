import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { Login } from '../../models/login';
import { AuthSvc } from '../../services/auth.service';

@Component({
    selector: 'app-auth-login',
    templateUrl: './auth-login.component.html',
    providers: [AuthSvc]
})

export class AuthComponent implements OnInit {
    errorMessage: string;
    model: Login;

    constructor(
        private authSvc: AuthSvc,
        private route: ActivatedRoute,
        private router: Router,
    ) { }

    ngOnInit(): void {
        this.model = new Login();
        this.model.email = '';
        this.model.password = '';
        localStorage.setItem('currentUser', '');
    }

    onSubmit(login) {
        this.authSvc.signIn(this.model)
        .then(response => {
            localStorage.setItem('currentUser', JSON.stringify(response));
            this.redirectToHome();
        }, error => this.errorMessage = <any>error);
    }

    redirectToHome() {
        this.router.navigate(['']);
    }
}
