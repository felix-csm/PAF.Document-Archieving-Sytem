import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
    selector: 'dashboard-filter',
    templateUrl: './app/dashboard/dashboard-filter/dashboard-filter.component.html'
})

export class DashboardFilterComponent implements OnInit {
    name = 'search-filter';
    mode = 'Observable';
    params: any = { title: '', author: '', yearSubmitted: '', remarks: '' };
    @Output() onFilter = new EventEmitter();

    constructor() { }

    ngOnInit(): void {
    }

    filter(): void {
        this.onFilter.emit(this.params);
    }
}
