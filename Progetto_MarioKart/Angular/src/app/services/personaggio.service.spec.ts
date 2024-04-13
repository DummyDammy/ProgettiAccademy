import { TestBed } from '@angular/core/testing';

import { PersonaggioService } from './personaggio.service';

describe('PersonaggioService', () => {
  let service: PersonaggioService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PersonaggioService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
