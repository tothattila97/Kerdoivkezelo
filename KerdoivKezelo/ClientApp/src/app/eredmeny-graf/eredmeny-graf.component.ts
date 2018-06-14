import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eredmeny-graf',
  templateUrl: './eredmeny-graf.component.html'
})
export class EredmenyGrafComponent implements OnInit {
  public kerdoiv: Kerdoiv;
  public kitoltesek: KerdoivKitoltese[][];
  public szelessegSzorzo = 20;
  public savSzelesseg = 5;
  public kivalasztott = -1;

  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }
  
  ngOnInit(): void {
    this.getKerdoivKitoltesek(-1);
    this.getKerdoiv();
  }

  getKerdoivKitoltesek(kerdoivId: number) {
    this.http.get<KerdoivKitoltese[][]>(this.baseUrl + 'api/Kitoltes/GetKerdoivKitoltesek').subscribe(result => {
      this.kitoltesek = result;
    }, error => console.error(error));
  }

  getKerdoiv() {
    this.http.get<Kerdoiv>(this.baseUrl + 'api/Kitoltes/GetKerdoiv').subscribe(result => {
      this.kerdoiv = result;
    }, error => console.error(error));
  }

  public reszletezes(index: number) {
    this.kivalasztott = index;
  }

  public savSzelessegValtoztatas(valtoztatas: number) {
    this.savSzelesseg += valtoztatas;
  }

}

//FIXME: ezt tartalmazza a kerdoiv-lista.component.ts
//ki kéne rakni egy fájlba
interface Kerdoiv {
  nev: string;
  idoKorlat: string;
  kitoltesSzam: number;
  atlagPontszam: number;
  maxPontszam: number;
  eredmeny: number;
}

interface KerdoivKitoltese {
  pontszam: number;
  felhasznalo: Felhasznalo;
  kitoltesKezdete: Date;
  kitoltesVege: Date;
}

interface Felhasznalo {
  name: string;
}


