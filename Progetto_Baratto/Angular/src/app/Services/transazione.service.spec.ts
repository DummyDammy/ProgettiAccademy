import { TestBed } from '@angular/core/testing';

import { TransazioneService } from './transazione.service';

describe('TransazioneService', () => {
  let service: TransazioneService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransazioneService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
