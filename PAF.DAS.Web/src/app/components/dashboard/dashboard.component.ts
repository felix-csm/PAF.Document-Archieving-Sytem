import { Component, OnInit } from '@angular/core';

import { PaperArchiveSvc } from '../../services/paper-archive.service';
import { PaperArchive } from '../../models/paper-archive';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    providers: [PaperArchiveSvc]
})

export class DashboardComponent implements OnInit {
    name = 'Dashboard';
    items: PaperArchive[];
    errorMessage: string;
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
