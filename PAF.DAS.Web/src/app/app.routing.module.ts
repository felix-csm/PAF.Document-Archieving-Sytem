import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AboutComponent } from './components/about/about.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PaperArchiveComponent } from './components/paper-archive/paper-archive.component';
import { AuthComponent } from './components/security/auth-login.component';
import { UserListComponent } from './components/security/user/user-list.component';

import { AuthGuard } from './components/security/auth-guard';

const _routes: Routes = [{
    path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full'
}, {
    path: 'login',
    component: AuthComponent
}, {
    path: 'logout',
    component: AuthComponent
}, {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard]
}, {
    path: 'new-paper',
    component: PaperArchiveComponent,
    canActivate: [AuthGuard]
}, {
    path: 'papers/:id',
    component: PaperArchiveComponent,
    canActivate: [AuthGuard]
}, {
    path: 'users',
    component: UserListComponent,
    canActivate: [AuthGuard]
}, {
    path: 'about',
    component: AboutComponent
}];

@NgModule({
    imports: [RouterModule.forRoot(_routes)],
    exports: [RouterModule],
    providers: [
        AuthGuard
    ]
})

export class AppRoutingModule {
}
