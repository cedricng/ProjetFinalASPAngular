import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '@environments/environment';
import { Client } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class AccountService {
    private clientSubject: BehaviorSubject<Client | null>;
    public client: Observable<Client | null>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.clientSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('client')!));
        this.client = this.clientSubject.asObservable();
    }

    public get clientValue() {
        return this.clientSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<Client>(`${environment.apiUrl}/Client/login`, { username, password })
            .pipe(map(client => {
                // store client details and jwt token in local storage to keep client logged in between page refreshes
                localStorage.setItem('client', JSON.stringify(client));
                this.clientSubject.next(client);
                return client;
            }));
    }

    register(client: Client) {
      return this.http.post(`${environment.apiUrl}/Client/register`, client);
  }

    logout() {
        // remove client from local storage and set current client to null
        localStorage.removeItem('client');
        this.clientSubject.next(null);
        this.router.navigate(['/account/login']);
    }
}
