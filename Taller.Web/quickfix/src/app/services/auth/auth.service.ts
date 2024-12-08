import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { ILogin } from '../../interfaces/user';
import { catchError, Observable, ReplaySubject, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements OnInit{
  private url: string = "https://localhost:7060"
  constructor(
    private http: HttpClient
  ) { }


  ngOnInit(): void {
    console.log("Se ha iniciado el moudlo de autenticacion")
  }

  login(user: ILogin): Observable<ILogin>{
    return this.http.post<ILogin>(`${this.url}/login`, user).pipe(
      tap(response => {

      }),
      catchError( error =>{
        throw error;
      })
    )
  }
  register(user:ILogin):Observable<ILogin>{
    return this.http.post<ILogin>(`${this.url}/register`, user).pipe(
      tap(response => {

      }),
      catchError( error =>{
        throw error;
      })
    )
  }
}
