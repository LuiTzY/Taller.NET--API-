import {  Component, OnInit } from '@angular/core';
import { client } from '../../../interfaces/clients';
import { ClientsService } from '../../../services/clients/clients.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { DataTablesModule } from 'angular-datatables';
import { Config } from 'datatables.net';

@Component({
  selector: 'app-clients-list',
  standalone: true,
  imports: [DataTablesModule, RouterLink],
  templateUrl: './clients-list.component.html',
  styleUrls: ['./clients-list.component.css']  // Corregido aquí
})
export class ClientsListComponent implements OnInit{
  dtOptions: Config = {};

  clients!: client[];

    constructor(
      private clientService: ClientsService,
      private route: ActivatedRoute,
      private router: Router,
    
    ){}
    
    ngOnInit(): void {
      this.dtOptions = {
        pagingType: 'full',
        pageLength: 5,
        processing: true,
      };
      
        this.clients = this.route.snapshot.data['clientDataResolver'];

        console.log(`Mis datos de clientes ${this.clients}`)

        
    }

    deleteClient(id:number){

        var clientAnswer = confirm("Estas seguro de eliminar el cliente?")
        if(clientAnswer){
            this.clientService.deleteClient(id).subscribe({
                next:(clientDeleted)=>{
                     alert("Se ha eliminado el cliente correctamente")
                     this.reloadClients();
                },
                error:(err)=>{ alert("No hemos podido eliminar el cliente debido a un error")}
            });
        }
        
        console.log("No se ha eliminado el cliente");
    }


    reloadClients():void{
        const url = this.router.url;
        this.router.navigateByUrl("/", {
            skipLocationChange:true,
          }).then(()=>{
            //esto devuelve una promesa en la cual navegaremos a la url actual en la que estabamos anteriormente  
            this.router.navigate([url]);
          
          });
    }
}
