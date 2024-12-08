import { Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { SingupComponent } from "./singin/singup.component";


//Rutas utilizadas para la autentiacion del usuario
export const AUTHENTICATION_ROUTES: Routes = [
    {
        path:"login",
        component: LoginComponent
    },
    {
        path:"register",
        component: SingupComponent
    }
];
