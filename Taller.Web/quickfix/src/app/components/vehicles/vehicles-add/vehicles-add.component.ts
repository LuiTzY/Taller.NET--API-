import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { VehiclesService } from '../../../services/vehicles/vehicles.service';
import { Router } from '@angular/router';
import { client } from '../../../interfaces/clients';
import { ClientsService } from '../../../services/clients/clients.service';

@Component({
  selector: 'app-vehicles-add',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './vehicles-add.component.html',
  styleUrl: './vehicles-add.component.css'
})
export class VehiclesAddComponent implements OnInit{
  public vehicleForm: FormGroup;
  public clients!: client[];
  constructor(
    private fb: FormBuilder,
    private vehiclesService: VehiclesService,
    private router: Router,
    private clientService: ClientsService
    
  ) {
    //Inicializamos los datos del formulario en un form group junto con el builder
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
  }
  onSubmit(): void {
    if (this.vehicleForm.valid) {
      this.vehiclesService.createVehiculo(this.vehicleForm.value).subscribe({
        next: () => this.router.navigate(['/vehicles/vehicles-list']),
        error: (e) => console.error(e)
      });
    }
  }
}
