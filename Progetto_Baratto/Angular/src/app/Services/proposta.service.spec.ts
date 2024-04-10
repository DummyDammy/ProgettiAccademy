import { TestBed } from '@angular/core/testing';

import { PropostaService } from './proposta.service';

describe('PropostaService', () => {
  let service: PropostaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PropostaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
