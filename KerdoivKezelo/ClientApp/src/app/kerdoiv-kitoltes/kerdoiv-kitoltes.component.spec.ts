import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KerdoivKitoltesComponent } from './kerdoiv-kitoltes.component';

describe('KerdoivKitoltesComponent', () => {
  let component: KerdoivKitoltesComponent;
  let fixture: ComponentFixture<KerdoivKitoltesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KerdoivKitoltesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KerdoivKitoltesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
