import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from '../dashboard/dashboard.component';
import { LoginComponent } from '../app-login/app-login.component';
import { AboutComponent } from '../about/about.component';
import { PaperArchiveComponent } from '../paperArchive/paperArchive.component';

import { AuthGuard } from '../common/auth.guard';

const _routes: Routes = [{
    path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full'
}, {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard]
}, {
    path: 'papers/add',
    component: PaperArchiveComponent,
    canActivate: [AuthGuard]
}, {
    path: 'login',
    component: LoginComponent
}, {
    path: 'about',
    component: AboutComponent
}];

@NgModule({
    imports: [RouterModule.forRoot(_routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {
    get Routes() {
        return _routes;
    }
}
