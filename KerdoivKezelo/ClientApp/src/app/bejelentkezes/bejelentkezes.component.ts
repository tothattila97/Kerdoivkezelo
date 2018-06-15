import { Component, Inject, OnInit, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Felhasznalo } from '../data/Felhasznalo.data';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bejelentkezes',
  templateUrl: './bejelentkezes.component.html'
})
export class BejelentkezesComponent implements OnInit {
  token: object;
  ok: boolean = true;
    
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) { }

  ngOnInit(): void {
  }

  bejelentkezes(userName, password) {
    let options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(this.baseUrl + '', JSON.stringify({ userName, password }), options).subscribe(result => {
      
    });
    if (this.ok) {
      this.router.navigate(['']);
    }
  }
}
