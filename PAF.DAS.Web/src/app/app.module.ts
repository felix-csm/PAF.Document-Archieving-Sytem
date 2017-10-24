// modules
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BootstrapModalModule } from 'angular2-modal/plugins/bootstrap';
import { ModalModule } from 'angular2-modal';
import { HttpModule} from '@angular/http';
import { FormsModule }   from '@angular/forms';

import { AppRoutingModule } from './app-router/app-routing.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { LoginModule } from './app-login/app-login.module';

import { SimpleNotificationsModule } from 'angular2-notifications';

// components
import { AppComponent } from './app.component';
import { AppHeaderComponent } from './app-header/app-header.component';
import { AboutComponent } from './about/about.component';

// providers
import { requestOptionsProvider } from './common/default-request-options.service';
import { GlobalSettings } from './common/global-settings';
import { CurrentUserService } from './common/current-user.service';
import { NotificationsService  } from 'angular2-notifications';

@NgModule({
    imports: [
        BrowserModule,
        ModalModule.forRoot(),
        BootstrapModalModule,
        HttpModule,
        FormsModule,
        // Put your custom module before the route, to prevent routing issue
        DashboardModule,
        LoginModule,
        AppRoutingModule,
        SimpleNotificationsModule.forRoot()
    ],
    declarations: [
        AppComponent,
        AppHeaderComponent,
        AboutComponent
    ],
    providers: [requestOptionsProvider, GlobalSettings, CurrentUserService, NotificationsService],
    bootstrap: [AppComponent]
})

export class AppModule { }
