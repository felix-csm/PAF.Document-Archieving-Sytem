import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, Validators } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app.routing.module';
import { DashboardModule } from './components/dashboard/dashboard.module';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { AboutComponent } from './components/about/about.component';
import { PaperArchiveComponent } from './components/paper-archive/paper-archive.component';
import { AuthComponent } from './components/security/auth-login.component';

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './components/security/auth-interceptor';

import { CurrentUserSvc } from './services/current-user.service';
import { AuthSvc } from './services/auth.service';
import { PaperArchiveSvc } from './services/paper-archive.service';
import { FileSvc } from './services/file.service';

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        AboutComponent,
        PaperArchiveComponent,
        AuthComponent
    ],
    imports: [
        BrowserModule,
        CommonModule,
        FormsModule,
        HttpModule,
        AppRoutingModule,
        HttpClientModule,
        DashboardModule
    ],
    providers: [{
        provide: HTTP_INTERCEPTORS,
        useClass: AuthInterceptor,
        multi: true
    },
        CurrentUserSvc,
        AuthSvc,
        PaperArchiveSvc,
        FileSvc
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
