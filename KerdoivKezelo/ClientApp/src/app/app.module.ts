import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { KerdoivListaComponent } from './kerdoiv-lista/kerdoiv-lista.component';
import { BejelentkezesComponent } from './bejelentkezes/bejelentkezes.component';
import { RegisztracioComponent } from './regisztracio/regisztracio.component';
import { EredmenyGrafComponent } from './eredmeny-graf/eredmeny-graf.component';
import { KerdesComponent } from './kerdes/kerdes.component';
import { KerdoivKitoltesComponent } from './kerdoiv-kitoltes/kerdoiv-kitoltes.component';
import { KerdoivSzerkesztesComponent } from './kerdoiv-szerkesztes/kerdoiv-szerkesztes.component';

@NgModule({
  declarations: [
      AppComponent,
      NavMenuComponent,
      KerdoivListaComponent,
      BejelentkezesComponent,
      RegisztracioComponent,
      EredmenyGrafComponent,
      KerdesComponent,
      KerdoivKitoltesComponent,
      KerdoivSzerkesztesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: KerdoivListaComponent },
      { path: 'bejelentkezes', component: BejelentkezesComponent },
      { path: 'regisztracio', component: RegisztracioComponent },
      { path: 'eredmeny-graf', component: EredmenyGrafComponent },
      { path: 'kerdes/:id', component: KerdesComponent },
      { path: 'kerdoiv-kitoltes/:id', component: KerdoivKitoltesComponent },
      { path: 'kerdoiv-szerkesztes/:id', component: KerdoivSzerkesztesComponent },
      { path: 'kerdoiv-szerkesztes', component: KerdoivSzerkesztesComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
