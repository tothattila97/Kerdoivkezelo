import { Component, Inject, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Felhasznalo } from '../data/Felhasznalo.data';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bejelentkezes',
  templateUrl: './bejelentkezes.component.html'
})
export class BejelentkezesComponent implements OnInit {
  token: object;
  ok: boolean = true;

  felhasznalo: Felhasznalo;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) { }

  ngOnInit(): void {
    this.felhasznalo = new Felhasznalo();
  }

  bejelentkezes() {
    //this.http.get(this.baseUrl + '').subscribe(result => {
    //  this.token = result
    //}, error => console.error(error));
    if (this.ok) {
      this.router.navigate(['/kerdoiv-lista']);
    }
  }
}
