import { ResolveFn } from '@angular/router';
import { inject } from '@angular/core';
import { VehicleResponse } from '../interfaces/vehicles';
import { VehiclesService } from '../services/vehicles/vehicles.service';


export const vehiclesResolver: ResolveFn<VehicleResponse[]> = (route, state) => {
    //retornaremos la data que obtuvimos
    
    return inject(VehiclesService).getAllVehiculos();
    
  };

