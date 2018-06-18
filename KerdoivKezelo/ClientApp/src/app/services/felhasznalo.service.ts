import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Felhasznalo } from '../data/Felhasznalo.data';

@Injectable()
export class FelhasznaloService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Felhasznalo[]>('/api/users');
  }

  getById(id: number) {
    return this.http.get('/api/users/' + id);
  }

  create(user: Felhasznalo) {
    return this.http.post('/api/users', user);
  }

  update(user: Felhasznalo) {
    return this.http.put('/api/users/' + user.id, user);
  }

  delete(id: number) {
    return this.http.delete('/api/users/' + id);
  }
}
