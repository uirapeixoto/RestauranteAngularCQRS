import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'garcomTarefas',
    templateUrl: './garcomTarefas.component.html'
})
export class GarcomTarefasComponent {
    public mesas: Mesa[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute)
    {

        this.route.params.subscribe(res => console.log(res.id));

        http.get(baseUrl + 'api/garcon/tarefa', ).subscribe(result => {
            this.mesas = result.json() as Mesa[];
        }, error => console.error(error));
    }
}

interface Mesa {
    id: number;
    numMesa: number;
    garcom: Garcom;
    dataServico: string;
    pedidos: Pedido[];
    ativo: boolean;
}

interface Garcom
{
    id: number;
    nome: string;
}

interface Pedido
{
    id: number;
    mesaId: number;
    numMesa: number;
    pedidoItem: PedidoItem;
    pedidoBebidaItens: PedidoItem[];
    pedidoComidaItens: PedidoItem[]; 
}

interface PedidoItem {
    id: number;
    descricao: string;
    quantidade: number;
    ajustePreco: number;
    aServir: string;
    emPreparacao: string;
    servido: string;
}