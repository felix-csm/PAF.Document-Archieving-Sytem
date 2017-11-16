import { Component, OnInit } from '@angular/core';

import { PaperArchiveSvc } from '../../services/paper-archive.service';
import { FileSvc } from '../../services/file.service';
import { CurrentUserSvc } from '../../services/current-user.service';
import { PaperArchive } from '../../models/paper-archive';
import { CurrentUser } from '../../models/current-user';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html'
})

export class DashboardComponent implements OnInit {
    name = 'Dashboard';
    items: PaperArchive[];
    pagedItems: PaperArchive[];
    itemViewedStats: PaperArchive[];
    itemDownLoadedStats: PaperArchive[];
    errorMessage: string;
    params: PaperArchive = new PaperArchive();
    currentUser: CurrentUser;
    pager: any = { total: 0, perPage: 3, page: 1, totalPage: 0 };

    constructor(
        private paperArchiveSvc: PaperArchiveSvc,
        private fileSvc: FileSvc,
        private currentUserSvc: CurrentUserSvc
    ) {
        this.currentUserSvc.currentUser$.subscribe(
            item => {
                this.currentUser = item;
            }
        );
    }

    private populate() {
        this.paperArchiveSvc.search(this.params).then(
            response => {
                this.pager.total = response.length;
                this.pager.totalPage = Math.ceil(response.length / this.pager.perPage);
                this.items = response;
                this.pagedItems = response.slice(0, this.pager.page * this.pager.perPage);
            },
            error => this.errorMessage = <any>error);
    }

    private hasNext() {
        return this.pager.total > this.pager.page * this.pager.perPage;
    }

    private hasPrev() {
        return (this.pager.page - 1) * this.pager.perPage > 0;
    }

    private next() {
        if (this.hasNext()) {
            this.pager.page += 1;
            this.setPageData();
        }
    }

    private prev() {
        if (this.hasPrev()) {
            this.pager.page -= 1;
            this.setPageData();
        }
    }

    private setPageData() {
        this.pagedItems = this.items.slice((this.pager.page - 1) * this.pager.perPage, this.pager.page * this.pager.perPage);
    }

    private showLikedStats() {
        this.paperArchiveSvc.getLikedStats().then(
            response => {
                this.itemViewedStats = response;
            },
            error => this.errorMessage = <any>error);
    }
    private showDownloadedStats() {
        this.fileSvc.getDownloadedStats().then(
            response => {
                this.itemDownLoadedStats = response;
            },
            error => this.errorMessage = <any>error);
    }

    filter(searchParams: PaperArchive): void {
        this.params = searchParams;
        this.populate();
    }

    view(id: string, name: string): void {
        this.fileSvc.viewFile(id, name).then(
            result => {
                this.showLikedStats();
                this.showDownloadedStats();
            });
    }

    like(id: string): void {
        this.paperArchiveSvc.like(id).then(
            response => {
                this.showLikedStats();
                this.showDownloadedStats();
            });
    }

    ngOnInit() {
        this.populate();
        this.showLikedStats();
        this.showDownloadedStats();
    }
}
