import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { PaperArchive } from '../../../models/paper-archive';

@Component({
    selector: 'app-dashboard-filter',
    templateUrl: './dashboard-filter.component.html'
})

export class DashboardFilterComponent implements OnInit {
    name = 'search-filter';
    params: PaperArchive = new PaperArchive();
    @Output() onFilter = new EventEmitter();

    constructor() { }

    ngOnInit(): void {
        this.params.documentType = 0;
    }

    clear(): void {
        this.params = new PaperArchive();
        this.params.documentType = 0;
    }
    filter(): void {
        this.onFilter.emit(this.params);
    }
}
