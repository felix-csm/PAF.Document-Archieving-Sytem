import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import 'rxjs/add/operator/switchMap';

import { PaperArchiveSvc } from '../../services/paper-archive.service';
import { PaperArchive } from '../../models/paper-archive';

@Component({
    selector: 'app-paper-archive',
    templateUrl: './paper-archive.component.html',
    providers: [PaperArchiveSvc]
})

export class PaperArchiveComponent implements OnInit {
    title: string;
    private model: PaperArchive;
    errorMessage: string;

    constructor(
        private paperArchiveSvc: PaperArchiveSvc,
        private route: ActivatedRoute,
        private router: Router,
    ) { }

    ngOnInit() {
        this.title = 'Archive a Paper';
        this.model = new PaperArchive();
        if (this.route.snapshot.paramMap.has('id')) {
            const id = this.route.snapshot.paramMap.get('id');
            this.paperArchiveSvc.get(id).then(response => {
                    this.model = response;
                },
                error => this.errorMessage = <any>error);
            this.title = 'Edit Archive Details';
        }
    }

    save() {
        if (!this.model.id) {
            this.paperArchiveSvc.add(this.model).then(
                response => {
                    this.router.navigate(['/dashboard']);
                },
                error => this.errorMessage = <any>error);
        } else {
            this.paperArchiveSvc.update(this.model).then(
                response => {
                    this.router.navigate(['/dashboard']);
                },
                error => this.errorMessage = <any>error);
        }
    }

    cancel() {
        this.router.navigate(['/dashboard']);
    }
}
