import { ResolveFn } from '@angular/router';
import { inject } from '@angular/core';
import { Employee } from '../interfaces/employee';
import { EmployeeService } from '../services/employees/employee.service';


export const employeesResolver: ResolveFn<Employee[]> = (route, state) => {
    //retornaremos la data que obtuvimos
    
    return inject(EmployeeService).getAllEmployees();
    
  };

export const employeeInfoResolver: ResolveFn<Employee | undefined> = (route, state) => {
    //retornaremos la data que obtuvimos
    const id = route.paramMap.get("id")
    if(id !== null){

        return inject(EmployeeService).getEmployeeById(parseInt(id!));
    }
    return 
  };