import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { PaperArchiveSvc } from '../app-services/paperArchive.service';
import { PaperArchive } from '../app-models/paperArchive';

@Component({
    selector: 'papers-add',
    templateUrl: './app/app-templates/paperArchive-manage.html',
    providers: [PaperArchiveSvc]
})

export class PaperArchiveComponent implements OnInit {
    name = 'PapersAdd';
    mode = 'Observable';
    model: PaperArchive = new PaperArchive();
    errorMessage: string;

    constructor(
        private paperArchiveSvc: PaperArchiveSvc,
        private router: Router
    ) { }

    ngOnInit() {

    }

    save() {
        this.paperArchiveSvc.save(this.model).then(
            response => {
                this.router.navigate(['/dashboard']);
            },
            error => this.errorMessage = <any>error);
    }

    cancel() {
        this.router.navigate(['/dashboard']);
    }
}
