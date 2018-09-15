import { Component, OnInit } from '@angular/core';
import { EquipoService } from '../equipo.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-equipo',
  templateUrl: './equipo.component.html',
  styleUrls: ['./equipo.component.css']
})
export class EquipoComponent implements OnInit {

  public equipos: Array<any>;
  public currentEquipo: any;

  constructor(private equipoService: EquipoService) {
    equipoService.get().subscribe((data: any) => this.equipos = data);

    this.currentEquipo = this.setInitialValuesForEquipoData();
  }

  ngOnInit() {
  }

  private setInitialValuesForEquipoData() {
    return {
      equipoId: undefined,
      nombre: '',
      codigo: ''
    }
  }

  public createOrUpdateEquipo = function (equipo: any) {
    // if equipog is present in equipoData, we can assume this is an update
    // otherwise it is adding a new element
    let equipoWithId;
    equipoWithId = _.find(this.equipos, (el => el.equipoId === equipo.equipoId));

    if (equipoWithId) {
      const updateIndex = _.findIndex(this.equipos, { equipoId: equipoWithId.equipoId });
      this.equipoService.update(equipo).subscribe(
        equipoRecord => this.equipos.splice(updateIndex, 1, equipo)
      );
    } else {
      this.equipoService.add(equipo).subscribe(
        equipoRecord => this.equipos.push(equipo)
      );
    }

    this.currentEquipo = this.setInitialValuesForEquipoData();
  };

  public editClicked = function (record) {
    this.currentEquipo = record;
  };

  public newClicked = function () {
    this.currentEquipo = this.setInitialValuesForEquipoData();
  };

  public deleteClicked(record) {
    const deleteIndex = _.findIndex(this.equipos, { equipoId: record.equipoId });
    this.equipoService.remove(record).subscribe(
      result => this.equipos.splice(deleteIndex, 1)
    );
  }
}
