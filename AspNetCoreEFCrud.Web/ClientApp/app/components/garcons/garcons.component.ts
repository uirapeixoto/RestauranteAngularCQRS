import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'garcons',
    templateUrl: './garcons.component.html'
})
export class GarconsComponent {
    public garcons: Garcom[];
    public date = new Date();
    id: number;
    public mesas: Mesa[];
    baseUrl: string;
    http: Http;
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        this.baseUrl = baseUrl;
        this.http = http;

        http.get(baseUrl + 'api/garcon/listar').subscribe(result => {
            this.garcons = result.json() as Garcom[];
        }, error => console.error(error));
    }

    VerTarefas(id: number) {
        this.http.get(this.baseUrl + 'api/garcon/tarefas/${id}', ).subscribe(result => {
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

interface Garcom {
    id: number;
    nome: string;
}

interface Pedido {
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