import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-statisztikak',
  templateUrl: './statisztikak.component.html',
  styleUrls: ['./statisztikak.component.css']
})
export class StatisztikakComponent implements OnInit {
  kerdoivek: Kerdoiv[];
  kivalasztottKerdoivIndex = 0;

  kitoltesek: KerdoivKitoltes[];
  csoportositottKitoltesek: KerdoivKitoltes[][];
  kivalasztottKitoltesCsoportIndex = -1;

  savSzelesseg = 5;
  maxCsoportMeret = 0;

  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute, private router: Router) {
    this.http = http;
    this.baseUrl = baseUrl;
  }
  
  ngOnInit(): void {
    let id = this.route.snapshot.queryParams['id'] || -1;
    this.getKerdoivek(id);
  }

  getKerdoivek(id: number): void {
    this.http.get<Kerdoiv[]>(this.baseUrl + 'api/Kitoltes/GetKerdoivek').subscribe(result => {
      this.kerdoivek = result;
      this.kivalasztasIndexSzamitasKerdoivIdbol(id);
      this.getKitoltesek();
    }, error => console.error(error));
  }

  kivalasztasIndexSzamitasKerdoivIdbol(id: number): void {
    if (id !== -1) {
      for (let i = 0; i < this.kerdoivek.length; i++) {
        if (id == this.kerdoivek[i].id) {
          this.kivalasztottKerdoivIndex = i;
          return;
        }
      }
    }
  }

  getKitoltesek(): void {
    let kerdoivId = this.kerdoivek[this.kivalasztottKerdoivIndex].id;
    this.http.get<KerdoivKitoltes[]>(this.baseUrl + 'api/Kitoltes/GetKitoltesek/' + kerdoivId).subscribe(result => {
      this.kitoltesek = result;
      this.kitoltesCsoportositas();
    }, error => console.error(error));
  }

  kitoltesCsoportositas(): void {
    this.maxCsoportMeret = 0;
    this.kivalasztottKitoltesCsoportIndex = -1;
    let savokSzama = Math.floor(this.kerdoivek[this.kivalasztottKerdoivIndex].maxPontszam / this.savSzelesseg) + 1;
    let csk: KerdoivKitoltes[][] = new Array<KerdoivKitoltes[]>(savokSzama);
    for (let i = 0; i < savokSzama; i++) {
      csk[i] = this.csoportKeszites(i);
      this.maxCsoportMeretFrissites(csk[i].length);
    }
    this.csoportositottKitoltesek = csk;
  }

  csoportKeszites(index: number): KerdoivKitoltes[] {
    return this.kitoltesek
        .filter(kit => this.savSzamitas(kit.pontszam) === index)
        .sort((k1, k2) => { return k2.pontszam - k1.pontszam; });
  }

  savSzamitas(pont: number): number {
    return Math.floor(pont / this.savSzelesseg);
  }

  maxCsoportMeretFrissites(csoportMeret: number): void {
    if (csoportMeret > this.maxCsoportMeret) {
      this.maxCsoportMeret = csoportMeret;
    }
  }

  kerdoivValtas(event): void {
    this.kivalasztottKerdoivIndex = event.target.selectedIndex;
    this.getKitoltesek();
  }

  reszletezes(index: number): void {
    if (index === this.kivalasztottKitoltesCsoportIndex && index != -1) {
      this.kivalasztottKitoltesCsoportIndex = -1;
    } else {
      this.kivalasztottKitoltesCsoportIndex = index;
    }
  }

  savSzelessegValtoztatas(valtoztatas: number): void {
    this.savSzelesseg += valtoztatas;
    if (this.savSzelesseg < 1) {
      this.savSzelesseg = 1;
    }
    this.kitoltesCsoportositas();
  }

  getCsoportNev(index: number): string {
    let kezdes = index * this.savSzelesseg;
    let veg = index * this.savSzelesseg + (this.savSzelesseg - 1);
    if (veg > this.kerdoivek[this.kivalasztottKerdoivIndex].maxPontszam) {
      veg = this.kerdoivek[this.kivalasztottKerdoivIndex].maxPontszam;
    }
    return this.getCsoportNevHatarokAlapjan(kezdes, veg);
  }

  getCsoportNevHatarokAlapjan(kezdes: number, veg: number): string {
    if (kezdes == veg) {
      return kezdes + '';
    } else {
      return kezdes + ' - ' + veg;
    }
  }

  kitoltottekMar(): boolean {
    return this.kitoltesek != undefined && this.kitoltesek.length>0;
  }

}

interface Kerdoiv {
  id: number;
  nev: string;
  maxPontszam: number;
}

interface KerdoivKitoltes {
  pontszam: number;
  kitoltesKezdete: Date;
  kitoltesVege: Date;
}


