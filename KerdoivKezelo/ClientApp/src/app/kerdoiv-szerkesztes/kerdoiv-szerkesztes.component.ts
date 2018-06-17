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
  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.getKerdoiv();
    this.kerdesTipusok = Object.entries(KerdesTipus);
    this.selectedKerdes = this.kerdoiv.kerdesek[0];
  }

  getKerdoiv() {
    const id = +this.route.snapshot.paramMap.get('id');
    // TODO: http request from backend server
    this.kerdoiv = KERDOIV;
  }

  selectKerdoiv(kerdes: Kerdes) {
    this.selectedKerdes = kerdes;
  }

}
