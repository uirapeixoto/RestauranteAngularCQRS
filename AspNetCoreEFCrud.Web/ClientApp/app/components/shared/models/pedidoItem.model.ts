import { MenuItem } from './menuItem.model';

export class PedidoItem {

    id: number;
    descricao: string;
    quantidade: number;
    ajustePreco: number;
    aServir: string;
    emPreparacao: string;
    servido: string;
    menuItem: MenuItem;

    constructor() { }
}