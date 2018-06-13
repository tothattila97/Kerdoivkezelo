import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit{
  public kerdoivek: Kerdoiv[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Kerdoiv[]>(baseUrl + 'api/Kerdoiv/GetKerdoivek').subscribe(result => {
      this.kerdoivek = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
    
  }
}

interface Kerdoiv {
  nev: string;
  idoKorlat: string;
  kitoltesSzam: number;
  atlagPontszam: number;
  maxPontszam: number;
  eredmeny: number;
}
