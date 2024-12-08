import { Component } from '@angular/core';
import { VehiclesService } from '../../../services/vehicles/vehicles.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { client } from '../../../interfaces/clients';
import { ClientsService } from '../../../services/clients/clients.service';

@Component({
  selector: 'app-vehicles-edit',
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule],
  templateUrl: './vehicles-edit.component.html',
  styleUrl: './vehicles-edit.component.css'
})
export class VehiclesEditComponent {
  vehicleForm: FormGroup;
  vehicleId!: number;
  public clients!: client[];

  constructor(
    private fb: FormBuilder,
    private vehiclesService: VehiclesService,
    private route: ActivatedRoute,
    private router: Router,
    private clientService: ClientsService

  ) {
    this.vehicleForm = this.fb.group({
      ClienteId: ['', Validators.required],
      Marca: ['', Validators.required],
      Modelo: ['', Validators.required],
      // Año: ['', Validators.required],
      Placa: ['', Validators.required],
      Color: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    
    //aqui cargamos los clientes que se les puedan asignar un vehiculo que se vaya a registar
    this.clientService.getClients().subscribe({
      next:(clients)=>{
        //tenemos todos los clientes cargados
        this.clients =  clients
      }
    })
    
    this.vehicleId =+ this.route.snapshot.params['id'];
    this.vehiclesService.getVehiculoById(this.vehicleId).subscribe({
      next: (vehicle) => this.vehicleForm.patchValue(vehicle),
      error: (e) => console.error(e)
    });
  }

  onSubmit(): void {
    if (this.vehicleForm.valid) {
      this.vehiclesService.updateVehiculo(this.vehicleId, this.vehicleForm.value).subscribe({
        next: () => {
          alert("The vehicle was edited succesfully")
          //se redicrecciona al listado de los clientes
          this.router.navigate(['/vehicles/vehicles-list'])
        },
        error: (e) => {
          alert("The vehicle edit failed, sorry and try later")
        }
      });
    }
  }
}
