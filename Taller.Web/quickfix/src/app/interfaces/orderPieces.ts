import { OrderJobs } from "./ordersJobs"
import { Piece } from "./piece"

export interface OrderPieces {

    OrdenPiezaId: number
    OrdenId: number
    PiezaId: number
    Cantidad : number
    Costo : number
    FechaUso: string
    Orden: OrderJobs
    Pieza: Piece
}