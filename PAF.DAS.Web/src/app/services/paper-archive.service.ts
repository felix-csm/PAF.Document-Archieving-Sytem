import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClient } from '@angular/common/http';

import { AppSettings } from '../app.settings';
import { PaperArchive } from '../models/paper-archive';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class PaperArchiveSvc {
    errorMessage: string;

    constructor(private http: HttpClient) { }

    get(id: string): Promise<PaperArchive> {
        const url = `${AppSettings.API_URL}/papers/${id}`;
        return this.http.get(url)
            .toPromise()
            .then(response => response as PaperArchive)
            .catch(this.handleError);
    }

    add(paperArchive: PaperArchive): Promise<PaperArchive> {
        const url = `${AppSettings.API_URL}/papers`;
        return this.http.post(url, paperArchive)
            .toPromise()
            .then(response => response as PaperArchive)
            .catch(this.handleError);
    }

    update(paperArchive: PaperArchive): Promise<PaperArchive> {
        const url = `${AppSettings.API_URL}/papers/${paperArchive.id}`;
        return this.http.put(url, paperArchive)
            .toPromise()
            .then(response => response as PaperArchive)
            .catch(this.handleError);
    }

    search(paperArchive: PaperArchive): Promise<PaperArchive[]> {
        const url = `${AppSettings.API_URL}/papers/search`;
        return this.http.post(url, paperArchive)
            .toPromise()
            .then(response => response as PaperArchive[])
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.error);
    }
}
