import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UtenteListComponent } from './utente-list.component';

describe('UtenteListComponent', () => {
  let component: UtenteListComponent;
  let fixture: ComponentFixture<UtenteListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UtenteListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UtenteListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
