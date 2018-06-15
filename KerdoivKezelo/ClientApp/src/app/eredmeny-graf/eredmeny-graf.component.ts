import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eredmeny-graf',
  templateUrl: './eredmeny-graf.component.html',
  styleUrls: ['./eredmeny-graf.component.css']
})
export class EredmenyGrafComponent implements OnInit {
  public kerdoivek: Kerdoiv[];
  kivalasztottKerdoivIndex = 0;

  kitoltesek: KerdoivKitoltese[];
  public csoportositottKitoltesek: KerdoivKitoltese[][];
  public kivalasztottKitoltesCsoportIndex = -1;

  public savSzelesseg = 5;
  public maxCsoportMeret = 0;

  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }
  
  ngOnInit(): void {
    this.getKerdoivek();
  }

  getKerdoivek() {
    this.http.get<Kerdoiv[]>(this.baseUrl + 'api/Kitoltes/GetKerdoivek').subscribe(result => {
      this.kerdoivek = result;
      this.getKitoltesek();
    }, error => console.error(error));
  }

  getKitoltesek() {
    let kerdoivId = this.kerdoivek[this.kivalasztottKerdoivIndex].id;
    this.http.get<KerdoivKitoltese[]>(this.baseUrl + 'api/Kitoltes/GetKitoltesek/' + kerdoivId).subscribe(result => {
      this.kitoltesek = result;
      this.kitoltesCsoportositas();
    }, error => console.error(error));
  }

  kitoltesCsoportositas() {
    this.kivalasztottKitoltesCsoportIndex = -1;
    let max = Math.floor(this.kerdoivek[this.kivalasztottKerdoivIndex].maxPontszam / this.savSzelesseg) + 1;
    let csk: KerdoivKitoltese[][] = new Array<KerdoivKitoltese[]>(max);
    for (let i = 0; i < max; i++) {
      csk[i] = this.csoportKeszites(i);
      this.maxCsoportMeretFrissites(csk[i].length);
    }
    this.csoportositottKitoltesek = csk;
  }

  csoportKeszites(index: number): KerdoivKitoltese[] {
    return this.kitoltesek
        .filter(kit => this.savSzamitas(kit.pontszam) === index)
        .sort((k1, k2) => { return k2.pontszam - k1.pontszam; });
  }

  maxCsoportMeretFrissites(csoportMeret: number) {
    if (csoportMeret > this.maxCsoportMeret) {
      this.maxCsoportMeret = csoportMeret;
    }
  }

  public kerdoivValtas(event) {
    this.kivalasztottKerdoivIndex = event.target.selectedIndex;
    this.getKitoltesek();
  }

  savSzamitas(pont: number): number {
    return Math.floor(pont / this.savSzelesseg);
  }

  public reszletezes(index: number) {
    this.kivalasztottKitoltesCsoportIndex = index;
  }

  public savSzelessegValtoztatas(valtoztatas: number) {
    this.savSzelesseg += valtoztatas;
    if (this.savSzelesseg < 1) {
      this.savSzelesseg = 1;
    }
    this.kitoltesCsoportositas();
  }

  public getCsoportNev(index: number): string {
    let kezdes = index * this.savSzelesseg;
    let veg = index * this.savSzelesseg + (this.savSzelesseg - 1);
    if (veg > this.kerdoivek[this.kivalasztottKerdoivIndex].maxPontszam) {
      veg = this.kerdoivek[this.kivalasztottKerdoivIndex].maxPontszam;
    }
    if (kezdes == veg) {
      return kezdes + '';
    } else {
      return kezdes + ' - ' + veg;
    }
  }

}

interface Kerdoiv {
  id: number;
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


