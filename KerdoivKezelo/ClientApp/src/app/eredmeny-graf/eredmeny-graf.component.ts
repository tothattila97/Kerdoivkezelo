import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eredmeny-graf',
  templateUrl: './eredmeny-graf.component.html',
  styleUrls: ['./eredmeny-graf.component.css']
})
export class EredmenyGrafComponent implements OnInit {
  public kerdoivek: Kerdoiv[];
  public kivalasztottKerdoiv = 0;

  kitoltesek: KerdoivKitoltese[];
  public csoportositottKitoltesek: KerdoivKitoltese[][];
  public kivalasztottKitoltesCsoport = -1;

  public savSzelesseg = 5;
  public maxCsoportMeret = 0;

  http: HttpClient;
  baseUrl: string;

  //integrálni mock helyett db-vel
  //a kérdőívek listázásától elérhető legyen
  //  akkor nem is kell a kérdőív választás, hanem csak az legyen, akit a kezdőoldalon kiválasztottunk?
  //másik kérdőív kiválasztására jöjjenek be a megfelelő adatok

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
      this.getKitoltesek(0);
    }, error => console.error(error));
  }

  getKitoltesek(kerdoivId: number) {
    this.http.get<KerdoivKitoltese[]>(this.baseUrl + 'api/Kitoltes/GetKitoltesek/' + kerdoivId).subscribe(result => {
      this.kitoltesek = result;
      this.kitoltesCsoportositas();
    }, error => console.error(error));
  }

  kitoltesCsoportositas() {
    let max = Math.floor(this.kerdoivek[this.kivalasztottKerdoiv].maxPontszam / this.savSzelesseg) + 1;
    let csk: KerdoivKitoltese[][] = new Array<KerdoivKitoltese[]>(max);
    for (let i = 0; i < max; i++) {
      csk[i] = this.kitoltesek
        .filter(kit => this.savSzamitas(kit.pontszam) === i)
        .sort((k1, k2) => { return k2.pontszam - k1.pontszam; });
      if (csk[i].length > this.maxCsoportMeret) {
        this.maxCsoportMeret = csk[i].length;
      }
    }
    this.csoportositottKitoltesek = csk;
  }

  public kerdoivValtas(event) {
    this.getKitoltesek(0);
  }

  savSzamitas(pont: number): number {
    return Math.floor(pont / this.savSzelesseg);
  }

  public reszletezes(index: number) {
    this.kivalasztottKitoltesCsoport = index;
  }

  public savSzelessegValtoztatas(valtoztatas: number) {
    this.kivalasztottKitoltesCsoport = -1;
    this.savSzelesseg += valtoztatas;
    if (this.savSzelesseg < 1) {
      this.savSzelesseg = 1;
    }
    this.kitoltesCsoportositas();
  }

  public getCsoportNev(index: number): string {
    let kezdes = index * this.savSzelesseg;
    let veg = index * this.savSzelesseg + (this.savSzelesseg - 1);
    if (veg > this.kerdoivek[this.kivalasztottKerdoiv].maxPontszam) {
      veg = this.kerdoivek[this.kivalasztottKerdoiv].maxPontszam;
    }
    if (kezdes == veg) {
      return kezdes + '';
    } else {
      return kezdes + ' - ' + veg;
    }
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

interface KerdoivKitoltese {
  pontszam: number;
  felhasznalo: Felhasznalo;
  kitoltesKezdete: Date;
  kitoltesVege: Date;
}

interface Felhasznalo {
  name: string;
}


