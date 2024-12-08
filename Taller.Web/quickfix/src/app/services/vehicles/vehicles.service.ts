import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Vehicle, VehicleResponse } from '../../interfaces/vehicles';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehiclesService {

  private apiUrl = 'https://localhost:7060/Vehiculos';

  constructor(private http: HttpClient) { }

  getAllVehiculos(): Observable<VehicleResponse[]> {
    return this.http.get<VehicleResponse[]>(`${this.apiUrl}`);
  }

  getVehiculoById(id: number): Observable<Vehicle> {
    return this.http.get<Vehicle>(`${this.apiUrl}/${id}`);
  }

  createVehiculo(vehiculo: Vehicle): Observable<Vehicle> {
    return this.http.post<Vehicle>(`${this.apiUrl}`, vehiculo);
  }

  updateVehiculo(id: number, vehiculo: Vehicle): Observable<Vehicle> {
    return this.http.put<Vehicle>(`${this.apiUrl}/${id}`, vehiculo);
  }

  deleteVehiculo(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}
