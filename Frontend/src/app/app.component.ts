import { Component } from '@angular/core';

import { Client } from './_models';
import { AccountService } from './services/account.service';

@Component({ selector: 'app-root', templateUrl: 'app.component.html' })
export class AppComponent {
    client?: Client | null;

    constructor(private accountService: AccountService) {
        this.accountService.client.subscribe(x => this.client = x);
    }

    logout() {
        this.accountService.logout();
    }
}
