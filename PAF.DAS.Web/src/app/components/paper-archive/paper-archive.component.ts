import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import 'rxjs/add/operator/switchMap';

import { AppSettings } from '../../app.settings';
import { PaperArchiveSvc } from '../../services/paper-archive.service';
import { FileSvc, FileResponse } from '../../services/file.service';
import { PaperArchive } from '../../models/paper-archive';

@Component({
    selector: 'app-paper-archive',
    templateUrl: './paper-archive.component.html'
})

export class PaperArchiveComponent implements OnInit {
    formName: string;
    model: PaperArchive;
    errorMessage: string;
    filesToUpload: File[];
    private fileIsValid: boolean;

    constructor(
        private paperArchiveSvc: PaperArchiveSvc,
        private fileSvc: FileSvc,
        private route: ActivatedRoute,
        private router: Router,
    ) { }

    ngOnInit(): void {
        this.formName = 'Archive a Paper';
        this.model = new PaperArchive();
        if (this.route.snapshot.paramMap.has('id')) {
            const id = this.route.snapshot.paramMap.get('id');
            this.paperArchiveSvc.get(id).then(response => {
                this.model = response;
            },
                error => this.errorMessage = <any>error);
            this.formName = 'Edit Archive Details';
        }
    }

    save() {
        if (!this.model.id) {
            this.fileSvc.upload(this.filesToUpload).then(o => {
                this.model.fileName = o.fileName;
                this.paperArchiveSvc.add(this.model).then(
                    response => {
                        this.router.navigate(['/dashboard']);
                    }, error => this.errorMessage = <any>error);

            }, error => this.errorMessage = <any>error);
        } else {
            this.paperArchiveSvc.update(this.model).then(
                response => {
                    this.router.navigate(['/dashboard']);
                }, error => this.errorMessage = <any>error);
        }
    }

    cancel() {
        this.router.navigate(['/dashboard']);
    }

    fileChangeEvent(fileInput: any) {
        this.filesToUpload = <Array<File>>fileInput.target.files;
        this.fileIsValid = this.filesToUpload.length === 0;
    }
}
