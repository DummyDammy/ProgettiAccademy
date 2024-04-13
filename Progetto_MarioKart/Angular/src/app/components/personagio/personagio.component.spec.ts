import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonagioComponent } from './personagio.component';

describe('PersonagioComponent', () => {
  let component: PersonagioComponent;
  let fixture: ComponentFixture<PersonagioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PersonagioComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PersonagioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
