import { Routes } from "@angular/router";
import { VehiclesAddComponent } from "./vehicles-add/vehicles-add.component";
import { VehiclesListComponent } from "./vehicles-list/vehicles-list.component";
import { VehiclesEditComponent } from "./vehicles-edit/vehicles-edit.component";
import { vehiclesResolver } from "../../resolvers/vehicles.resolver";

//Se almacenara todas las rutas relacionadas  a los vehiculos
export const VEHICLES_ROUTES : Routes =  [
    {
       path:"vehicles-list",
       component: VehiclesListComponent,
       resolve:{vehiclesResolver}
    },
    {
        path:"vehicles-edit/:id",
        component:VehiclesEditComponent
    },
    {
        path:"vehicles-add",
        component:VehiclesAddComponent
    }
]