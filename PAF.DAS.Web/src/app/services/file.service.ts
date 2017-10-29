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
        return new Promise((resolve, reject) => {
            const formData: any = new FormData();
            const xhr = new XMLHttpRequest();
            for (let i = 0; i < files.length; i++) {
                formData.append('uploads[]', files[i], files[i].name);
            }
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4) {
                    if (xhr.status === 200) {
                        resolve(JSON.parse(xhr.response));
                    } else {
                        reject(xhr.response);
                    }
                }
            };
            xhr.open('POST', url, true);
            xhr.send(formData);
        });
    }

    viewFile(id: string, name: string): void {
        const url = `${AppSettings.API_URL}/paperarchives/${encodeURIComponent(id)}/file`;
        this.http.get(url, { responseType: 'blob'})
            .subscribe(
                data => this.downloadFile(data, name),
                error => alert('Error downloading file!'),
                () => console.log('OK!')
            );
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
