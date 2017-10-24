import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { GlobalSettings } from '../common/global-settings';
import { PaperArchive } from '../app-models/paperArchive';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class DashboardSvc {
    errorMessage: string;

    constructor(private http: Http) { }

    get(title: string, author: string, yearSubmitted: string): Promise<PaperArchive[]> {
        const url = `${GlobalSettings.API_URL}/papers`;
        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as PaperArchive[])
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}
