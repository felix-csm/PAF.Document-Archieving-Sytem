import { Component, OnInit } from '@angular/core';
import { DashboardSvc } from './dashboard.service';
import { PaperArchive } from '../app-models/paperArchive';

@Component({
    selector: 'dashboard',
    templateUrl: './app/dashboard/dashboard.component.html',
    providers: [DashboardSvc]
})

export class DashboardComponent implements OnInit {
    name = 'Dashboard';
    items: PaperArchive[];
    errorMessage: string;
    mode = 'Observable';
    title: string = '';
    author: string = '';
    yearSubmitted: string = '';

    constructor(private dashboardSvc: DashboardSvc) { }

    private populate(): void {
        this.dashboardSvc.get(this.title, this.author, this.yearSubmitted).then(
            response => {
                this.items = response;
            },
            error => this.errorMessage = <any>error);
    }

    filter(params: any): void {
        this.title = params.title;
        this.author = params.author;
        this.yearSubmitted = params.yearSubmitted;
        this.populate();
    }

    ngOnInit(): void {
        this.populate();
    }
}
