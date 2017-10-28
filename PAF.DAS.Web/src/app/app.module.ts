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


import { RequestOptionsProvider } from './common/request-options.provider';
import { AuthGuard } from './components/security/auth.guard';

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        AboutComponent,
        PaperArchiveComponent
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
