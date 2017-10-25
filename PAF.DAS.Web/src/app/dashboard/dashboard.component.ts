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
    params: PaperArchive = new PaperArchive();

    constructor(
        private paperArchiveSvc: PaperArchiveSvc
    ) { }

    private populate() {
        this.paperArchiveSvc.search(this.params).then(
            response => {
                this.items = response;
            },
            error => this.errorMessage = <any>error);
    }

    filter(searchParams: PaperArchive) {
        this.params = searchParams;
        this.populate();
    }

    ngOnInit() {
        this.populate();
    }
}
