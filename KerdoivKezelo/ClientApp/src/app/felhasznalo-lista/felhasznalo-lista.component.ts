import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-felhasznalo-lista',
  templateUrl: './felhasznalo-lista.component.html'
})
export class FelhasznaloListaComponent implements OnInit {
  felhasznalok: Felhasznalo[];

  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }
  
  ngOnInit(): void {
    this.getFelhasznalok();
  }

  getFelhasznalok(): void {
    this.http.get<Felhasznalo[]>(this.baseUrl + 'api/Felhasznalo/GetFelhasznalok').subscribe(result => {
      this.felhasznalok = result;
    }, error => console.error(error));
  }

  adminJogHozzaadasa(index: number): void {
    this.felhasznalok[index].adminJog = true;
    this.felhasznaloFrissitese(index);
  }

  adminJogElvetele(index: number): void {
    this.felhasznalok[index].adminJog = false;
    this.felhasznaloFrissitese(index);
  }

  felhasznaloFrissitese(index: number): void {
    this.http.post<Felhasznalo>(this.baseUrl + 'api/Felhasznalo/FelhasznaloFrissitese', this.felhasznalok[index]);
  }
  
}

interface Felhasznalo {
  name: string;
  admin: boolean;
  adminJog: boolean;
}


