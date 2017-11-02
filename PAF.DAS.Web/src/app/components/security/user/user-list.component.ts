import { Component, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import * as $ from 'jquery';
import * as b from 'bootstrap';
import { UserSvc } from '../../../services/user.service';
import { ChangePasswordUser } from '../../../models/change-password';
import { UserInfo } from '../../../models/user-info';
@Component({
    selector: 'app-user-list',
    templateUrl: './user-list.component.html'
})

export class UserListComponent implements OnInit {
    name = 'Dashboard';
    users: UserInfo[];
    current: ChangePasswordUser;
    errorMessage: string;

    constructor(
        private userSvc: UserSvc,
    ) {
        this.current = new ChangePasswordUser();
        this.current.oldPassword = '';
        this.current.newPassword = '';
    }

    private populate() {
        this.userSvc.getAll().then(
            response => {
                this.users = response;
            },
            error => this.errorMessage = <any>error);
    }

    select(user: ChangePasswordUser): void {
        this.current = user;
    }

    update(): void {
        this.userSvc.changePassword(this.current).then(
            response => {
                //TODO: need to call the modal hide manually here
                //$(this.myModal.nativeElement).modal('show');
            },
            error => this.errorMessage = <any>error);
    }

    ngOnInit() {
        this.populate();
    }
}
