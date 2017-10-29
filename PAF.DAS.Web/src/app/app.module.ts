import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app.routing.module';
import { DashboardModule } from './components/dashboard/dashboard.module';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { AboutComponent } from './components/about/about.component';
import { PaperArchiveComponent } from './components/paper-archive/paper-archive.component';
import { AuthComponent } from './components/security/auth-login.component';

import { RequestOptionsProvider } from './common/request-options.provider';

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
    providers: [
        RequestOptionsProvider
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
