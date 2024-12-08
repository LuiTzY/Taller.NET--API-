import { Employee } from "./employee"
import { MaintenanceHistory } from "./maintenance"
import { OrderPieces } from "./orderPieces"
import { Vehicle } from "./vehicles"

export interface OrderJobs {
    OrdenId: number
    VehiculoId: number
    EmpleadoId: number
    FechaEntrada: string
    FechaSalida: string
    Descripcion: string
    Estado : string
    TotalCosto: number
    Empleado: Employee
    HistorialMantenimientos: MaintenanceHistory[]
    OrdenPiezas: OrderPieces[]
    Vehiculo:Vehicle[]
}