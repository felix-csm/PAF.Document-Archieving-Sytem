import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CommonAppModule } from '../common/common.module';
import { RouterModule } from '@angular/router';

// Components
import { DashboardComponent } from './dashboard.component';
import { DashboardFilterComponent } from './dashboard-filter/dashboard-filter.component';
import { DateOrNullModule } from '../common/date-or-null.module';

// Providers
import { PaperArchiveSvc } from '../app-services/paperArchive.service';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        CommonAppModule,
        RouterModule,
        DateOrNullModule.forRoot()
    ],
    declarations: [
        DashboardComponent,
        DashboardFilterComponent
    ],
    providers: [
        PaperArchiveSvc
    ]
})

export class DashboardModule { }
