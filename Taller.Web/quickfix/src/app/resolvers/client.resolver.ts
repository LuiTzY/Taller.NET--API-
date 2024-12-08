import { ResolveFn } from '@angular/router';
import { inject } from '@angular/core';
import { ClientsService } from '../services/clients/clients.service';
import { client } from '../interfaces/clients';


export const clientDataResolver: ResolveFn<client[]> = (route, state) => {
  //retornaremos la data que obtuvimos
  
  return inject(ClientsService).getClients();
  
};



export const clientResolver: ResolveFn<client | undefined> = (route, state) => {
  
    //obtenemos el ID que tengamos en la ruta
    const id = route.paramMap.get("id")
    if(id !== null){

        console.log(`Este es el ID ${id}`);
    
        return inject(ClientsService).getClient(parseInt(id));
      
    }
  
    return 
};