import { Route } from "@angular/router";
import { ClientsListComponent } from "./clients-list/clients-list.component";
import { ClientsAddComponent } from "./clients-add/clients-add.component";
import { clientDataResolver, clientResolver } from "../../resolvers/client.resolver";
import { ClientEditComponent } from "./client-edit/client-edit.component";

export const CLIENTS_ROUTES:Route[] = [
    {
        path:"client-list",
        component:ClientsListComponent,
        resolve:{clientDataResolver}
    },
    {
        path:"client-add",
        component:ClientsAddComponent
    },
    {
        path:"client-edit/:id",
        component:ClientEditComponent,
        resolve:{clientResolver}
    }
]