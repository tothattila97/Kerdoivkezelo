import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KerdoivSzerkesztesComponent } from './kerdoiv-szerkesztes.component';

describe('KerdoivSzerkesztesComponent', () => {
  let component: KerdoivSzerkesztesComponent;
  let fixture: ComponentFixture<KerdoivSzerkesztesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KerdoivSzerkesztesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KerdoivSzerkesztesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
