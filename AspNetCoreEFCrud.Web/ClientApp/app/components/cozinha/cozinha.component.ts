import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'cozinha',
    templateUrl: './cozinha.component.html'
})
export class CozinhaComponent {
    public tarefas: Cozinha[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/cozinha/listar').subscribe(result => {
            this.tarefas = result.json() as Cozinha[];
        }, error => console.error(error));
    }
}

interface Cozinha {
    pedidoItemId: number;
    mesaId: number;
    numMesa: number;
    pedidoId: number;
    descricao: string;
    quantidade: number;
    ajustePrco: number;
    aServir: string;
    emPreparacao: string;
    servido: string;
    menuItem: Menuitem;
    pedidosProntos: PedidoItem[];
    marcarComoPronto: boolean;
}

interface Menuitem
{
    id: number;
    numMenuItem: number;
    descricao: string;
    valor: number;
    bebida: boolean;
    ativo: boolean;
}

interface PedidoItem
{
    id: number;
    descricao: string;
    quantidade: number;
    ajustePreco: number;
    aServir: string;
    emPreparacao: string;
    servido: string;
}
