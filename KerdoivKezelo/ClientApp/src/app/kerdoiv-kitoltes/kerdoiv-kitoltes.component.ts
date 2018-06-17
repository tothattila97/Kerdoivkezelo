import { Component, OnInit } from '@angular/core';
import { Kerdoiv, KERDOIV } from '../data/kerdoiv';
import { KerdesTipus } from '../data/kerdes';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-kerdoiv-kitoltes',
  templateUrl: './kerdoiv-kitoltes.component.html',
  styleUrls: ['./kerdoiv-kitoltes.component.css']
})
export class KerdoivKitoltesComponent implements OnInit {

  kerdoiv: Kerdoiv;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.getKerdoiv();
  }

  getKerdoiv() {
    const id = +this.route.snapshot.paramMap.get('id');
    // TODO: http request from backend server
    this.kerdoiv = KERDOIV;
  }

}
