import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../../../services/employees/employee.service';

@Component({
  selector: 'app-employees-edit',
  standalone: true,
  imports: [ReactiveFormsModule,FormsModule],
  templateUrl: './employees-edit.component.html',
  styleUrl: './employees-edit.component.css'
})
export class EmployeesEditComponent {
  employeeForm: FormGroup;
  private id!: number;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.employeeForm = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      cargo: ['', Validators.required],
      telefono: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      ordenesTrabajo: [[]]
    });
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.employeeService.getEmployeeById(this.id).subscribe({
      next: (employee) => {
        this.employeeForm.patchValue(employee);
      },
      error: (e) => console.error(e)
    });
  }

  onSubmit(): void {
    if (this.employeeForm.valid) {
      this.employeeService.updateEmployee(this.id, this.employeeForm.value).subscribe({
        next: () => { 
          alert("Se actualizo correctamente el cliente")
          this.router.navigate(['/employees/employees-list'])
        },
        error: (e) => console.error(e)
      });
    }
  }
}
