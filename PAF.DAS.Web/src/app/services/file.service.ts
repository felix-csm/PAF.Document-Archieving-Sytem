import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { BaseRequestOptions, RequestOptions, ResponseOptions } from '@angular/http';
import { AppSettings } from '../app.settings';
import { PaperArchive } from '../models/paper-archive';
import { Subscription } from 'rxjs/Subscription';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class FileSvc {
    errorMessage: string;

    constructor(private http: HttpClient) { }

    upload(files: File[]): Promise<FileResponse> {
        const url = `${AppSettings.API_URL}/paperarchives/upload`;
        const formData: any = new FormData();
        for (let i = 0; i < files.length; i++) {
            formData.append('uploads[]', files[i], files[i].name);
        }
        return this.http.post(url, formData)
            .toPromise()
            .then(response => response as FileResponse)
            .catch(this.handleError);
    }

    viewFile(id: string, name: string): Promise<any>{
        const url = `${AppSettings.API_URL}/paperarchives/${encodeURIComponent(id)}/file`;
        return this.http.get(url, { responseType: 'blob' })
        .toPromise()
        .then(data => { this.downloadFile(data, name); })
        .catch(this.handleError);
    }
    getDownloadedStats(): Promise<PaperArchive[]> {
        const url = `${AppSettings.API_URL}/paperarchives/stats`;
        return this.http.get(url)
            .toPromise()
            .then(response => response as PaperArchive[])
            .catch(this.handleError);
    }
    private downloadFile(data: Blob, name: string): void {
        const a = document.createElement('a');
        a.href = URL.createObjectURL(data);
        a.download = name;
        a.click();
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
}

export class FileResponse {
    fileName: string;
}
