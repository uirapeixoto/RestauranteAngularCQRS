import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'garcomTarefas',
    templateUrl: './garcomTarefas.component.html'
})
export class GarcomTarefasComponent {
    public garcom: Garcom;
    id: number;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute)
    {

        this.route.params.subscribe(res => this.id = res.id);

        http.get(baseUrl + 'api/garcon/tarefa/' + this.id).subscribe(result => {
            this.garcom = result.json() as Garcom;
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
    mesas: Mesa[];
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
    menuItem: MenuItem;
}

interface MenuItem {
    id: number;
    numMenuItem: number;
    descricao: string;
    valor: number;
    bebida: boolean;
    ativo: boolean;
}