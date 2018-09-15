import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridEquipoComponent } from './grid-equipo.component';

describe('GridEquipoComponent', () => {
  let component: GridEquipoComponent;
  let fixture: ComponentFixture<GridEquipoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridEquipoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridEquipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
