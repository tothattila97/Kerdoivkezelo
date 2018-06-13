import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-kerdoiv-lista',
  templateUrl: './kerdoiv-lista.component.html'
})
export class KerdoivListaComponent {
  public kerdoivek: Kerdoiv[];
  maxElemszamEgyOldalon: number = 20;
  utolsoOldal: number = 5;
  oldalszam = 1;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Kerdoiv[]>(baseUrl + 'api/Kerdoiv/GetKerdoivek').subscribe(result => {
      this.kerdoivek = result;
    }, error => console.error(error));
  }

  kovetkezoOldal(): void {
    if (this.oldalszam !== this.utolsoOldal) {
      this.oldalszam++;
    }
    //TODO
  }

  elozoOldal(): void {
    if (this.oldalszam !== 1) {
      this.oldalszam--;
    }
    //TODO
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
