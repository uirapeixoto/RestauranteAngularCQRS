import { PedidoItem } from "./pedidoItem.model";

export class Pedido {

    mesaId: number;
    numMesa: number;
    garcomId: number;
    pedidoBebidaItens: PedidoItem[];
    pedidoComidaItens: PedidoItem[];
    
    constructor() { }
}