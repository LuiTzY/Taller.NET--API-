import { OrderJobs } from "./ordersJobs"

export interface Employee {
    EmpleadoId?: number
    Nombre: string
    Apellido: string
    Cargo: string
    Telefono: string
    Email: string
    ordenesTrabajo?: OrderJobs []
}

export interface EmployeeResponse {
    empleadoId?: number
    nombre: string
    apellido: string
    cargo: string
    telefono: string
    email: string
    ordenesTrabajo?: OrderJobs []
}