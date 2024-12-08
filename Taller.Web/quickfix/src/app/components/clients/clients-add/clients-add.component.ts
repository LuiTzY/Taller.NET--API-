import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ClientsService } from '../../../services/clients/clients.service';
import { NgClass } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clients-add',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, NgClass],
  templateUrl: './clients-add.component.html',
  styleUrl: './clients-add.component.css'
})
export class ClientsAddComponent implements OnInit{
    //propiedad donde se crearan todos los campos de los formularios
    public clientForm!: FormGroup;

    constructor(
        private fb: FormBuilder,
        private clientService: ClientsService,
        private router: Router
    ){

        //creamos el formulario una vez se inicie el constructor
        this.clientForm =  this.fb.group({
            Nombre:["", [Validators.required]],
            Email:["", [Validators.required]],
            Direccion:["", [Validators.required]],
            Telefono:["",[]]
        })
    }

    ngOnInit(): void {
        
    }

    onSubmit():void{

        if(this.clientForm.valid){
            const clientData = this.clientForm.value;
            console.log(`Esta es la data del formulario ${JSON.stringify(clientData)}`)
            this.clientService.createClient(clientData).subscribe({
                next:(clientCreated)=>{
                    this.router.navigate(['/clients/clients-list/'])
                    alert("Haz registrado el cliente correctamente");
                },
                error:(err)=>{ alert(`No se ha podido crear el cliente correctamente, lo sentimos, sucedio esto ${JSON.stringify(err)}`);}
            })
        }
    }
}
