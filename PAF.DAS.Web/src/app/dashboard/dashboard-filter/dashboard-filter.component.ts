import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { PaperArchive } from '../../app-models/paperArchive';

@Component({
    selector: 'dashboard-filter',
    templateUrl: './app/dashboard/dashboard-filter/dashboard-filter.component.html'
})

export class DashboardFilterComponent implements OnInit {
    name = 'search-filter';
    mode = 'Observable';
    params: PaperArchive = new PaperArchive();
    @Output() onFilter = new EventEmitter();

    constructor() { }

    ngOnInit(): void {
    }

    clear(): void {
        this.params = new PaperArchive();
    }
    filter(): void {
        this.onFilter.emit(this.params);
    }
}
