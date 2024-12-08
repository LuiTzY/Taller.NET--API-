import { OrderJobs } from "./ordersJobs"
import { Vehicle } from "./vehicles"

export interface MaintenanceHistory {
    HistorialId: number
    VehiculoId: number
    OrdenId: number
    Fecha: string
    Descripcion: string
    Orden: OrderJobs
    Vehiculo: Vehicle
}