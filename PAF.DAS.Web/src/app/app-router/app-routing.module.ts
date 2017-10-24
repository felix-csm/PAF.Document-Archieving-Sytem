import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from '../dashboard/dashboard.component';
import { LoginComponent } from '../app-login/app-login.component';
import { AboutComponent } from '../about/about.component';

import { AuthGuard } from '../common/auth.guard';

const _routes: Routes = [{
    path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full'
}, {
    path: 'dashboard',
    component: DashboardComponent,
    data: { isRoot: true, title: 'Dashboard' },
    canActivate: [AuthGuard]
}, {
    path: 'login', component: LoginComponent,
    data: { isRoot: false, title: 'Login' }
}, {
    path: 'about', component: AboutComponent,
    data: { isRoot: false, title: 'Login' }
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
