import { Routes } from "@angular/router";
import { EmployeesListComponent } from "./employees-list/employees-list.component";
import { employeesResolver,employeeInfoResolver } from "../../resolvers/employee.resolver";
import { EmployeesAddComponent } from "./employees-add/employees-add.component";
import { EmployeesEditComponent } from "./employees-edit/employees-edit.component";

export const EMPLOYEES_ROUTES : Routes  = [
    {
        path:"employees-list",
        component:EmployeesListComponent,
        resolve:{employeesResolver}
    },
    {
        path:"employees-add",
        component: EmployeesAddComponent
    },
    {
        path:"employee-edit/:id",
        component: EmployeesEditComponent,
        resolve: { employeeInfoResolver}
    }
]