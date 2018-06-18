import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Felhasznalo } from '../data/Felhasznalo.data';
import { Observable } from 'rxjs/Observable';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

export class BejelentkezesService {

  constructor(private http: HttpClient, private baseURL: string) { }

  bejelentkezes() {
    
  }
}
