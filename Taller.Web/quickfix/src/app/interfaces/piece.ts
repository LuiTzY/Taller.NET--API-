import { OrderPieces } from "./orderPieces"

export interface Piece {
    PiezaId: number
    Nombre: string
    Descripcion: string
    Precio: number
    OrdenPiezas: OrderPieces
}