import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { AlertService } from '../services/alert.service';

@Component({
  selector: 'app-bejelentkezes',
  providers: [AuthenticationService, AlertService],
  templateUrl: './bejelentkezes.component.html'
})
export class BejelentkezesComponent implements OnInit {
  model: any = {};
  loading = false;

  constructor(
    private authenticationService: AuthenticationService,
    private alertService: AlertService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.authenticationService.kijelentkezes();
  }

  bejelentkezes() {
    this.loading = true;
    this.authenticationService.bejelentkezes(this.model.email, this.model.password)
      .subscribe(data => {
        this.router.navigate(['']);
      },
        error => {
          this.alertService.error(error);
          this.loading = false;
        });
  }
}
