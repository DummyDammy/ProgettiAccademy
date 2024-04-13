import { TestBed } from '@angular/core/testing';

import { GiocatoreService } from './giocatore.service';

describe('GiocatoreService', () => {
  let service: GiocatoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GiocatoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
