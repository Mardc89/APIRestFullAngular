import { DetallePedido } from "./detalle-pedido"



export interface Pedido {
    idPedido?:number,
    codigo:string,
    fechaPedido?:string
    montoTotal:string,
    detallePedido:DetallePedido[]
}
