import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-kerdoiv-lista',
  templateUrl: './kerdoiv-lista.component.html'
})
export class KerdoivListaComponent implements OnInit {
  public kerdoivek: Kerdoiv[];
  utolsoOldal: number;
  oldalszam = 1;
  keresesiOldalszam = 1;
  szuroStr: string = "";

  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.getKerdoivek(this.oldalszam - 1);
    this.initMaxPage(false);
  }

  getKerdoivek(page: number, value: string = null) {
    if (value === "" || value === null) {
      this.http.get<Kerdoiv[]>(this.baseUrl + 'api/Kerdoiv/GetPage/' + page).subscribe(result => {
        this.kerdoivek = result;
      }, error => console.error(error));
    }
    else {
      this.http.get<Kerdoiv[]>(this.baseUrl + 'api/Kerdoiv/GetKerdoivekByMegnevezes/' + value/* + "/" + page*/).subscribe(result => {
        this.kerdoivek = result;
      }, error => console.error(error));
    }
  }

  initMaxPage(isKereses: boolean): void {
    let metodus: string;
    //TODO
    if (isKereses) {
      metodus = "GetMaxPage";
    }
    else {
      metodus = "GetMaxPage";
    }

    this.http.get<number>(this.baseUrl + 'api/Kerdoiv/' + metodus).subscribe(result => {
      this.utolsoOldal = result;
    }, error => console.error(error));
  }

  kovetkezoOldal(): void {
    if (this.szuroStr !== "" && this.szuroStr !== null) {
      if (this.keresesiOldalszam !== this.utolsoOldal) {
        this.keresesiOldalszam++;
      }
      this.getKerdoivek(this.keresesiOldalszam - 1);
      return;
    }

    if (this.oldalszam !== this.utolsoOldal) {
      this.oldalszam++;
    }
    this.getKerdoivek(this.oldalszam - 1);
  }

  elozoOldal(): void {
    if (this.szuroStr !== "" && this.szuroStr !== null) {
      if (this.keresesiOldalszam !== 1) {
        this.keresesiOldalszam--;
      }
      this.getKerdoivek(this.keresesiOldalszam - 1);
      return;
    }

    if (this.oldalszam !== 1) {
      this.oldalszam--;
    }
    this.getKerdoivek(this.oldalszam - 1);
  }

  kerdoivMegnyitasa(nev: string): void {

  }
  
  onEnter(value: string) {
    if (value === "" || value === null) {
      this.szuroStr = "";
      this.getKerdoivek(this.oldalszam - 1);
    }
    else {
      this.szuroStr = value;
      this.keresesiOldalszam = 1;
      this.initMaxPage(true);
      this.getKerdoivek(this.keresesiOldalszam - 1, value);
    }
  }

  rendezNevSzerint() {
    alert("rendez");
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
