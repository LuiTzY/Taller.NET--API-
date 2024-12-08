import { Component, OnInit } from '@angular/core';
import { Config } from 'datatables.net';
import {  EmployeeResponse } from '../../../interfaces/employee';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { EmployeeService } from '../../../services/employees/employee.service';
import { DataTablesModule } from 'angular-datatables';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-employees-list',
  standalone: true,
  imports: [DataTablesModule,RouterLink],
  templateUrl: './employees-list.component.html',
  styleUrl: './employees-list.component.css'
})
export class EmployeesListComponent implements OnInit{
  dtOptions: Config = {};
  public employees!: EmployeeResponse[];

  constructor(
    private route: ActivatedRoute,
    private employeeService: EmployeeService
  ){}

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full',
      pageLength: 5,
      processing: true,
    };

      this.employees = this.route.snapshot.data['employeesResolver'];

      
  }

  deleteEmployee(id:number | undefined):void{
    this.employeeService.deleteEmployee(id).subscribe({
      next:(response)=>{
        alert("Empleado eliminado")
      },
      error:(err)=>{
        alert("No se pudo eliminar el empleado lo sentimos")
      }
    }
    
  )
  }
}
