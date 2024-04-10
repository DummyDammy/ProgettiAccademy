import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UtenteInsertComponent } from './utente-insert.component';

describe('UtenteInsertComponent', () => {
  let component: UtenteInsertComponent;
  let fixture: ComponentFixture<UtenteInsertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UtenteInsertComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UtenteInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
