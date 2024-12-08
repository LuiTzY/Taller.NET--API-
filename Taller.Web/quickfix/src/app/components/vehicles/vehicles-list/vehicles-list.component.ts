import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { DataTablesModule } from 'angular-datatables';
import { VehiclesService } from '../../../services/vehicles/vehicles.service';
import { Vehicle, VehicleResponse } from '../../../interfaces/vehicles';
import { Config } from 'datatables.net';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-vehicles-list',
  standalone: true,
  imports: [RouterLink, DataTablesModule],
  templateUrl: './vehicles-list.component.html',
  styleUrl: './vehicles-list.component.css'
})
export class VehiclesListComponent {

  dtOptions! : Config;
  vehicles!: VehicleResponse[];

  constructor(
    private vehicleService: VehiclesService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full',
      pageLength: 5,
      processing: true,
    };

    //Consumimos el servicio para obtener todos los vehiculos
    this.vehicles = this.route.snapshot.data['vehiclesResolver'];
  }

  deleteVehiculo(id: number): void {
    this.vehicleService.deleteVehiculo(id).subscribe({
      next: () => {
        this.router.navigate(['/vehicles/vehicles-add'])
        alert("The vehicle was deleted succesfully");
        //redireccionamos nuevamente a los vehiculos 
      },
      error: (e) => {
        alert("The vehicle elimination failed")
      }
    });
  }
}
