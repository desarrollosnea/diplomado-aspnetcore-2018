import { TestBed, inject } from '@angular/core/testing';

import { EquipoService } from './equipo.service';

describe('EquipoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EquipoService]
    });
  });

  it('should be created', inject([EquipoService], (service: EquipoService) => {
    expect(service).toBeTruthy();
  }));
});
