import { Routes } from '@angular/router';
import { AUTHENTICATION_ROUTES } from './components/auth/auth.routes';
import { CLIENTS_ROUTES } from './components/clients/clients.route';
import { EMPLOYEES_ROUTES } from './components/employees/employees.routes';
import { VEHICLES_ROUTES } from './components/vehicles/vehicles.routes';

export const routes: Routes = [
    //Rutas para el modulo de autenticacion, se coloca el path y el children que indicara las rutas hijas que se cargaran sobre ese path
    {
        path:"auth",
        children: AUTHENTICATION_ROUTES  
        
    },
    
    //Rutas para el modulo de clientes
    {
        path:"clients",
        children: CLIENTS_ROUTES 
        
    },
    //Rutas para el modulo de Empleados
    {
        path:"employees",
        children: EMPLOYEES_ROUTES 
        
    },
    //Rutas para el modulo vehiculos
    {
        path:"vehicles",
        children: VEHICLES_ROUTES  
    }
];
