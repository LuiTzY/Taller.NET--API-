import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { client } from '../../../interfaces/clients';
import { ClientsService } from '../../../services/clients/clients.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-client-edit',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, NgClass],
  templateUrl: './client-edit.component.html',
  styleUrl: './client-edit.component.css'
})
export class ClientEditComponent {


  clientEditForm!: FormGroup;
  public clientID!: number;
  public clientInfo!: client;
  constructor(
    private fb: FormBuilder,
    private clientService: ClientsService,
    private route: ActivatedRoute,
    private router: Router
  ){
    this.clientInfo =  this.route.snapshot.data['clientResolver'];

    this.clientEditForm = this.fb.group({
      Nombre:[this.clientInfo.nombre],
      Email:[this.clientInfo.email, [Validators.email]],
      Direccion:[this.clientInfo.direccion],
      Telefono:[this.clientInfo.telefono]
    });
  }

  ngOnInit(): void {

  }

  onSubmit():void{
    if(this.clientEditForm.valid){
      const data = this.clientEditForm.value;

      this.clientService.updateClient(this.clientInfo.clienteId,data).subscribe({
        next:(response)=>{
          alert("Se ha editado el cliente correctamente");
          this.router.navigate(["/clients-list"])
        },
        error:(err)=>{
          console.log(err)
          alert("No hemos podido crear el cliente correctamente");
        }
      })

    }
  }
}
