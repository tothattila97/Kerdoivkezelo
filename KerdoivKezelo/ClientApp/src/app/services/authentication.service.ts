import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {
  constructor(private http: HttpClient, private baseUrl: string) { }

  bejelentkezes(email: string, password: string) {
    return this.http.post<any>(this.baseUrl + '/bejelentkezes', { email: email, password: password })
      .map(user => {
        if (user && user.token) {
          localStorage.setItem('currentUser', JSON.stringify(user));
        }

        return user;
      });
  }

  kijelentkezes() {
    localStorage.removeItem('currentUser');
  }
}
