import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-kerdoiv-lista',
  templateUrl: './kerdoiv-lista.component.html'
})
export class KerdoivListaComponent implements OnInit {
  public kerdoivek: Kerdoiv[];
  utolsoOldal: number;
  oldalszam = 1;

  //szűréshez használt értékek
  keresesiOldalszam = 1;
  szuroStr: string = "";
  kezdoIdo: number = 0;
  vegsoIdo: number = 0;
  isKereses: boolean = false;
  vasztottOpcio = "optionNev";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) { }

  ngOnInit(): void {
    this.getKerdoivek(this.oldalszam - 1);
    this.initMaxPage();
  }

  getKerdoivek(page: number) {
    if (!this.isKereses) {
      this.http.get<Kerdoiv[]>(this.baseUrl + 'api/Kerdoiv/GetPage/' + page).subscribe(result => {
        this.kerdoivek = result;
      }, error => console.error(error));
    }
    else {
      if (this.vasztottOpcio === "optionNev") {
        this.http.get<Kerdoiv[]>(this.baseUrl + 'api/Kerdoiv/GetKerdoivekByMegnevezes/' + this.szuroStr + "/" + page).subscribe(result => {
          this.kerdoivek = result;
        }, error => console.error(error));
      }
      if (this.vasztottOpcio === "optionIdokorlat") {
        this.http.get<Kerdoiv[]>(this.baseUrl + 'api/Kerdoiv/GetKerdoivekByIdoIntervallum/' +
          this.kezdoIdo + "/" + this.vegsoIdo + "/" + page).subscribe(result => {
          this.kerdoivek = result;
        }, error => console.error(error));
      }
    }
  }

  initMaxPage(): void {
    let metodus: string;
    if (this.isKereses) {
      if (this.vasztottOpcio === "optionNev") {
        metodus = "GetMatchingPagesNumber/" + this.szuroStr;
      }
      if (this.vasztottOpcio === "optionIdokorlat") {
        metodus = "GetPagesNumberByTimeInterval/" + this.kezdoIdo + "/" + this.vegsoIdo;
      }
    }
    else {
      metodus = "GetMaxPage";
    }

    this.http.get<number>(this.baseUrl + 'api/Kerdoiv/' + metodus).subscribe(result => {
      this.utolsoOldal = result;
    }, error => console.error(error));
  }

  kovetkezoOldal(): void {
    if (this.isKereses) {
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
    if (this.isKereses) {
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

  opcioValasztas(opcio) {
    this.vasztottOpcio = opcio;
    if (opcio === "optionNev") {
      this.nevSzuresTorles();
    }
    if (opcio === "optionIdokorlat") {
      this.idoSzuresTorles();
    }
  }

  kerdoivMegnyitasa(id: number): void {
    this.router.navigate(['/kerdoiv-kitoltes/18' /*+ id*/]);
  }

  kerdoivSzerkesztese(id: number): void {
    this.router.navigate(['/kerdoiv-szerkesztes/18' /*+ id*/]);
  }

  private setKeresesNev(value: string) {
    this.szuroStr = value;
    this.keresesiOldalszam = 1;
    this.isKereses = true;
    this.initMaxPage();
    this.getKerdoivek(this.keresesiOldalszam - 1);
  }

  private nevSzuresTorles() {
    this.szuroStr = "";
    this.isKereses = false;
    this.initMaxPage();
    this.getKerdoivek(this.oldalszam - 1);
  }
  
  onEnterNev(value: string) {
    if (value !== "" && value !== null && value !== undefined) {
      this.setKeresesNev(value);
    }
    else {
      this.nevSzuresTorles();
    }
  }

  onBackspaceNev(value: string) {
    if (value === "") {
      this.nevSzuresTorles();
    }
    else {
      this.setKeresesNev(value);
    }
  }

  private setKeresesIdo(kezdo, vegso) {
    if (kezdo === "") {
      this.kezdoIdo = 0;
    }
    else {
      this.kezdoIdo = kezdo;
    }

    if (vegso === "") {
      this.vegsoIdo = 120;
    }
    else {
      this.vegsoIdo = vegso;
    }
    
    this.keresesiOldalszam = 1;
    this.isKereses = true;
    this.initMaxPage();
    this.getKerdoivek(this.keresesiOldalszam - 1);
  }

  private idoSzuresTorles() {
    this.kezdoIdo = 0;
    this.vegsoIdo = 0;
    this.isKereses = false;
    this.initMaxPage();
    this.getKerdoivek(this.oldalszam - 1);
  }

  onEnterIdo(kezdo, vegso) {
    if (kezdo === "" && vegso === "") {
      this.idoSzuresTorles();
    }
    else {
      this.setKeresesIdo(kezdo, vegso);
    }
  }

  onBackspaceIdo(kezdo, vegso) {
    if (kezdo === "" && vegso === "") {
      this.idoSzuresTorles();
    }
    else {
      this.setKeresesIdo(kezdo, vegso);
    }
  }

  //TODO
  rendezNevSzerint() {
    alert("rendez");
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
