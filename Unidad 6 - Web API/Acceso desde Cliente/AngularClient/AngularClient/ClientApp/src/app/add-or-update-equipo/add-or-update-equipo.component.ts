import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-or-update-equipo',
  templateUrl: './add-or-update-equipo.component.html',
  styleUrls: ['./add-or-update-equipo.component.css']
})
export class AddOrUpdateEquipoComponent implements OnInit {

  @Output() equipoCreated = new EventEmitter<any>();
  @Input() equipoInfo: any;

  public buttonText = 'Save';

  constructor() {
    this.clearEquipoInfo();
    console.log(this.equipoInfo.nombre);
  }

  ngOnInit() {
  }

  private clearEquipoInfo = function () {
    // Create an empty jogging object
    this.equipoInfo = {
      equipoId: undefined,
      nombre: '',
      codigo: ''
    };
  };

  public addOrUpdateEquipoRecord = function (event) {
    this.equipoCreated.emit(this.equipoInfo);
    this.clearEquipoInfo();
  };
}
