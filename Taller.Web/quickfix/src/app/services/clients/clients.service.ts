import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap } from 'rxjs';
import { client, createClient } from '../../interfaces/clients';

@Injectable({
  providedIn: 'root'
})
export class ClientsService {
  private url: string = "https://localhost:7060/Clientes/clients"
  constructor(private http: HttpClient) { }

  createClient(clientData: createClient ):Observable<createClient>{
  
    return this.http.post<createClient>(this.url, {...clientData}, );
  }

  //metodo para obtener un cliente, esperamo
  getClient(client_id: number ):Observable<client>{
    console.log("Estamos haciedno la soli")
    return this.http.get<client>(this.url+`/${client_id}/`).pipe(
      tap(()=>{
        console.log("Esta es la respuesta")
      }),
      catchError((error)=>{
        console.log(error)
        throw error;
      })
    )
  }

  getClients():Observable<client[]>{
    return this.http.get<client[]>(this.url).pipe(
      tap((response)=>{ console.log(`Esto son los datos que nos llegan desde el API ${JSON.stringify(response)}`)})
    );
  }

  updateClient(id:number,clientDataUpdate: client ):Observable<void>{
    return this.http.put<void>(`${this.url}/${id}/`,{ ...clientDataUpdate}).pipe(
      tap(()=>{
        console.log("Esta es la respuesta")
      }),
      catchError((error)=>{
        console.log(error)
        throw error;
      })
    )
  }

  deleteClient(client_id: number ):Observable<void>{
    return this.http.delete<void>(`https://localhost:7060/Clientes/${client_id}/`).pipe(
      tap(()=>{
        console.log("Esta es la respuesta")
      }),
      catchError((error)=>{
        console.log(error)
        throw error;
      })
    )
  }

}
