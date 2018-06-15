import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Felhasznalo } from '../data/Felhasznalo.data';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { equal } from 'assert';

@Component({
  selector: 'app-regisztracio',
  templateUrl: './regisztracio.component.html'
})
export class RegisztracioComponent implements OnInit {
  valid: boolean = true;
  ok: boolean = true;

  jelszoUjra: string;
  felhasznalo: Felhasznalo;
  regisztracioForm: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) { }

  ngOnInit(): void {
    this.felhasznalo = new Felhasznalo();

    this.regisztracioForm = new FormGroup({
      'felhasznaloNev': new FormControl(this.felhasznalo.felhasznaloNev, Validators.required),
      'email': new FormControl(this.felhasznalo.email, [
        Validators.required,
        Validators.pattern("[^ @]*@[^ @]*")
      ]),
      'jelszo': new FormControl(this.felhasznalo.jelszo, [
        Validators.minLength(8),
        Validators.required
      ]),
      'jelszoUjra': new FormControl(this.jelszoUjra, [
        Validators.minLength(8),
        Validators.required
      ])
    });
  }

  isJelszoEgyezik(): boolean {
    if (this.felhasznalo.jelszo !== this.jelszoUjra) {
      return false;
    }
    return true;
  }

  regisztracio() {
    if (this.isJelszoEgyezik()) {
      this.valid = true;
    }
    else {
      this.valid = false;
    }
    if (this.valid) {
      //this.http.get(this.baseUrl + '').subscribe(result => {
      //  this.token = result
      //}, error => console.error(error));
      if (this.ok) {
        this.router.navigate(['/kerdoiv-lista']);
      }

    }
  }
}
