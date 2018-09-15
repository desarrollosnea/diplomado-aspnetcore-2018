import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class EquipoService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'http://localhost:9100/api/equipo';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public get() {
    // Get all jogging data
    return this.http.get(this.accessPointUrl, { headers: this.headers });
  }

  public add(payload) {
    return this.http.post(this.accessPointUrl, payload, { headers: this.headers });
  }

  public remove(payload) {
    return this.http.delete(this.accessPointUrl + '/' + payload.equipoId, { headers: this.headers });
  }

  public update(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.equipoId, payload, { headers: this.headers });
  }
}
