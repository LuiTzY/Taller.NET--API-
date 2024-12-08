import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ILogin } from '../../../interfaces/user';
import { AuthService } from '../../../services/auth/auth.service';

@Component({
  selector: 'app-singin',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './singup.component.html',
  styleUrl: './singup.component.css'
})
export class SingupComponent implements OnInit {
  
  public singupForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService
  ){
    this.singupForm = this.fb.group({
      username:['', Validators.required],
      password:['', [Validators.required, Validators.minLength(6)]]

    })
  }

  ngOnInit(): void {
    
  }

  singup():void{
     //sacamos la data obtenida
     const data: ILogin =  {...this.singupForm.value};
     console.log("Problemas con la data ", data)
     
     this.authService.register(data).subscribe({
       next:((response)=>{
         //Mandamos mensaje de que el usuario se logueo correctamente
         alert("You registered succesfully")
        }),
       error:(err)=>{
        console.log("Este es el error", JSON.stringify(err))
        alert("Erros, we cannot register your account")        
       }
     })
     console.log("Aqui tenemoes los valores del formulario", data)
  }
}
