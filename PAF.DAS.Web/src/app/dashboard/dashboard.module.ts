import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CommonAppModule } from '../common/common.module';

// Components
import { DashboardComponent } from './dashboard.component';
import { DashboardFilterComponent } from './dashboard-filter/dashboard-filter.component';
import { DateOrNullModule } from '../common/date-or-null.module';

// Providers
import { DashboardSvc } from './dashboard.service';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        CommonAppModule,
        DateOrNullModule.forRoot()
    ],
    declarations: [
        DashboardComponent,
        DashboardFilterComponent
    ],
    providers: [
        DashboardSvc
    ]
})

export class DashboardModule { }
