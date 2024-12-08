import { client } from "./clients"
import { MaintenanceHistory } from "./maintenance"
import { OrderJobs } from "./ordersJobs"

export interface Vehicle {
    
    VehiculoId: number
    ClienteId: number
    Marca: string
    Modelo: string
    Año: number
    Placa: string
    Color: string
    Cliente: client
    HistorialMantenimientos: MaintenanceHistory[]
    OrdenesTrabajos: OrderJobs[]
}

export interface VehicleResponse {
    vehiculoId: number
    clienteId: number
    marca: string
    modelo: string
    Año: number
    placa: string
    color: string
    cliente: client
    historialMantenimientos: MaintenanceHistory[]
    ordenesTrabajos: OrderJobs[]
}