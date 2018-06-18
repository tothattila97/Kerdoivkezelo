import { Component, OnInit, Input } from '@angular/core';
import { Kerdoiv, KERDOIV } from '../data/kerdoiv';
import { KerdesTipus, Kerdes } from '../data/kerdes';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-kerdoiv-szerkesztes',
  templateUrl: './kerdoiv-szerkesztes.component.html',
  styleUrls: ['./kerdoiv-szerkesztes.component.css']
})
export class KerdoivSzerkesztesComponent implements OnInit {

  kerdoiv: Kerdoiv;
  kerdesTipusok: [string, string][];
  selectedKerdes: Kerdes;
  selectedTipus: KerdesTipus;
  isNevEditing: boolean;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.getKerdoiv();
    this.kerdesTipusok = Object.entries(KerdesTipus); //.filter(key => !isNaN(Number(KerdesTipus[key])));
    console.log(this.kerdesTipusok);
    this.selectedKerdes = this.kerdoiv.kerdesek[1];
    this.isNevEditing = false;
  }

  getKerdoiv() {
    const id = +this.route.snapshot.paramMap.get('id');
    // TODO: http request from backend server
    this.kerdoiv = KERDOIV;
  }

  selectKerdes(kerdes: Kerdes) {
    this.isNevEditing = false;
    this.selectedKerdes = kerdes;
    this.selectedTipus = kerdes.tipus;
  }

  selectKerdesTipus(tipusKey: string) {
    this.selectedKerdes.tipus = KerdesTipus[tipusKey];
    this.selectedTipus = KerdesTipus[tipusKey];
  }

  valaszHozzaadasa() {
    this.selectedKerdes.valaszok.push('Uj valasz');
  }

  kerdesHozzaadasa() {
    const kerdes: Kerdes = {
      kerdes: 'Új kérdés',
      valaszok: [],
      tipus: KerdesTipus.egyszeru
    };
    this.kerdoiv.kerdesek.push(kerdes);
  }

  editNev() {
    this.isNevEditing = true;
  }

  saveNev(ujNev: string) {
    this.isNevEditing = false;
    this.kerdoiv.nev = ujNev;
  }

  cancelNev() {
    this.isNevEditing = false;
  }


}
