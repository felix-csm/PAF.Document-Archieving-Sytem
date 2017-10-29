import { Component, OnInit } from '@angular/core';

import { PaperArchiveSvc } from '../../services/paper-archive.service';
import { FileSvc } from '../../services/file.service';
import { PaperArchive } from '../../models/paper-archive';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    providers: [PaperArchiveSvc, FileSvc]
})

export class DashboardComponent implements OnInit {
    name = 'Dashboard';
    items: PaperArchive[];
    errorMessage: string;
    params: PaperArchive = new PaperArchive();

    constructor(
        private paperArchiveSvc: PaperArchiveSvc,
        private fileSvc: FileSvc
    ) { }

    private populate() {
        this.paperArchiveSvc.search(this.params).then(
            response => {
                this.items = response;
            },
            error => this.errorMessage = <any>error);
    }

    filter(searchParams: PaperArchive): void {
        this.params = searchParams;
        this.populate();
    }

    view(id: string, name: string): void {
        this.fileSvc.viewFile(id, name);
    }

    ngOnInit() {
        this.populate();
    }
}
