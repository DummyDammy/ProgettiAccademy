import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GiocatoreComponent } from './giocatore.component';

describe('GiocatoreComponent', () => {
  let component: GiocatoreComponent;
  let fixture: ComponentFixture<GiocatoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GiocatoreComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GiocatoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
