import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrUpdateEquipoComponent } from './add-or-update-equipo.component';

describe('AddOrUpdateEquipoComponent', () => {
  let component: AddOrUpdateEquipoComponent;
  let fixture: ComponentFixture<AddOrUpdateEquipoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddOrUpdateEquipoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrUpdateEquipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
