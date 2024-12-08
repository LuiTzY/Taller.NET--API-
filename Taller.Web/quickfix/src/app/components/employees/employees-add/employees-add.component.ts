import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { EmployeeService } from '../../../services/employees/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employees-add',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './employees-add.component.html',
  styleUrl: './employees-add.component.css'
})
export class EmployeesAddComponent {

  employeeForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private router: Router
  ) {
    this.employeeForm = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      cargo: ['', Validators.required],
      telefono: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      ordenesTrabajo: [[]]  // Assuming array of order jobs can be modified
    });
  }

  onSubmit(): void {
    if (this.employeeForm.valid) {
      this.employeeService.createEmployee(this.employeeForm.value).subscribe({
        next: () => {
          alert("Employee registered succesfully")
          this.router.navigate(['/employees/employees-list'])
        },
        error: (e) => console.error(e)
      });
    }
  }
}
