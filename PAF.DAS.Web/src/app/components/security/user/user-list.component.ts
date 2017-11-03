import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
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
    modalDisplay: string;

    constructor(
        private userSvc: UserSvc,
    ) {
        this.current = new ChangePasswordUser();
        this.current.oldPassword = '';
        this.current.newPassword = '';
        this.modalDisplay = 'none';
    }

    private populate() {
        this.userSvc.getAll().then(
            response => {
                this.users = response;
            },
            error => this.errorMessage = <any>error);
    }

    cancel() {
        this.current = new ChangePasswordUser();
        this.current.oldPassword = '';
        this.current.newPassword = '';
        this.modalDisplay = 'none';
    }

    select(user: ChangePasswordUser): void {
        this.current = user;
        this.modalDisplay = 'block';
    }

    update(): void {
        this.userSvc.changePassword(this.current).then(
            response => {
                this.cancel();
            },
            error => this.errorMessage = <any>error);
    }

    ngOnInit() {
        this.populate();
    }
}
