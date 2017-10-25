import { Component, OnInit } from '@angular/core';

import { PaperArchiveSvc } from '../app-services/paperArchive.service';
import { PaperArchive } from '../app-models/paperArchive';

@Component({
    selector: 'dashboard',
    templateUrl: './app/dashboard/dashboard.component.html',
    providers: [PaperArchiveSvc]
})

export class DashboardComponent implements OnInit {
    name = 'Dashboard';
    items: PaperArchive[];
    errorMessage: string;
    mode = 'Observable';
    title: string = '';
    author: string = '';
    yearSubmitted: string = '';

    constructor(
        private paperArchiveSvc: PaperArchiveSvc
    ) { }

    private populate() {
        this.paperArchiveSvc.get(this.title, this.author, this.yearSubmitted).then(
            response => {
                this.items = response;
            },
            error => this.errorMessage = <any>error);
    }

    filter(params: any) {
        this.title = params.title;
        this.author = params.author;
        this.yearSubmitted = params.yearSubmitted;
        this.populate();
    }

    ngOnInit() {
        this.populate();
    }
}
