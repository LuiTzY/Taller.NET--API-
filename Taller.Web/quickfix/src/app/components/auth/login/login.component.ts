import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ILogin } from '../../../interfaces/user';
import { AuthService } from '../../../services/auth/auth.service';



@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{

  public loginForm!: FormGroup;
  //iniciamos el constructor
  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,

  ){

    this.loginForm = this.formBuilder.group({
      username:['', [Validators.required]],
      password:['', [Validators.required, Validators.minLength(6)]]
    })
  }

  ngOnInit(): void {
    console.log("Se ha cargado el componete de Login")
    
  }

  login():void{
    //sacamos la data obtenida
    const data: ILogin =  {...this.loginForm.value};
    console.log("Problemas con la data ", data)
    
    this.authService.login(data).subscribe({
      next:((response)=>{
        //Mandamos mensaje de que el usuario se logueo correctamente
        alert("Inicio de sesion exitoso")
      }),
      error:(err)=>{
        alert("Claves incorrectas")        
      }
    })
    console.log("Aqui tenemoes los valores del formulario", data)
  }
}
