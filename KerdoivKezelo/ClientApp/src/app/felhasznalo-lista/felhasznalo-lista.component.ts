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
    this.felhasznalok = new Array<Felhasznalo>(3);
    this.felhasznalok[0] = {
      name: 'admin',
      admin: true,
      adminJog: true
    };
    this.felhasznalok[1] = {
      name: 'user1',
      admin: false,
      adminJog: true
    };
    this.felhasznalok[2] = {
      name: 'user2',
      admin: false,
      adminJog: false
    };
  }

  adminJogHozzaadasa(index: number): void {
    this.felhasznalok[index].adminJog = true;
  }

  adminJogElvetele(index: number): void {
    this.felhasznalok[index].adminJog = false;
  }
  
}

interface Felhasznalo {
  name: string;
  admin: boolean;
  adminJog: boolean;
}


