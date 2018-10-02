import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'mesa-status',
    templateUrl: './mesa-status.component.html'
})
export class MesaStatusComponent {
    public mesaStatus: MesaStatus;
    id: number;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute)
    {

        this.route.params.subscribe(res => this.id = res.id);

        http.get(baseUrl + 'api/mesa/status/' + this.id).subscribe(result => {
            this.mesaStatus = result.json() as MesaStatus;
        }, error => console.error(error));
    }
}

interface MesaStatus {
    mesaId: number;
    numMesa: number;
    pedidosAServir: PedidoItem;
    pedidosEmPreparacao: PedidoItem;
    pedidosServidos: PedidoItem;
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