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
      console.log(username, password);
        return this.http.post<Client>(`${environment.apiUrl}/Client/login`, { username, password })
            .pipe(map(client => {
              console.log(client)
                // store client details and jwt token in local storage to keep client logged in between page refreshes
                localStorage.setItem('client', JSON.stringify(client));
                this.clientSubject.next(client);
                return client;
            }));
    }

    register(client: Client) {
      client.role = "user"
      console.log(client);
      return this.http.post(`${environment.apiUrl}/Client/register`, client)
      .pipe(map((client : Client) =>{
        console.log(client)
          // store client details and jwt token in local storage to keep client logged in between page refreshes
          localStorage.setItem('client', JSON.stringify(client));
          this.clientSubject.next(client);
          return client;
      }));;
  }

    logout() {
        // remove client from local storage and set current client to null
        localStorage.removeItem('client');
        this.clientSubject.next(null);
        this.router.navigate(['/account/login']);
    }

    getAll() {
      return this.http.get<Client[]>(`${environment.apiUrl}/Client`);
  }

  getById(id: string) {
      return this.http.get<Client>(`${environment.apiUrl}/Client/${id}`);
  }

  update(id: string, params: any) {
      return this.http.put(`${environment.apiUrl}/Client/${id}`, params)
          .pipe(map(x => {
              // update stored Client if the logged in Client updated their own record
              if (id == this.clientValue?.id) {
                  // update local storage
                  const Client = { ...this.clientValue, ...params };
                  localStorage.setItem('Client', JSON.stringify(Client));

                  // publish updated Client to subscribers
                  this.clientSubject.next(Client);
              }
              return x;
          }));
  }

  delete(id: string) {
      return this.http.delete(`${environment.apiUrl}/Client/${id}`)
          .pipe(map(x => {
              // auto logout if the logged in user deleted their own record
              if (id == this.clientValue?.id) {
                  this.logout();
              }
              return x;
          }));
  }
}
