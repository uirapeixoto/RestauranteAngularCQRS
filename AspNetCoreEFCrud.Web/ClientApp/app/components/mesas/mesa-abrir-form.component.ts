import { Component, OnInit, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'mesa-abrir-form',
    templateUrl: './mesa-abrir-form.component.html',
})
export class MesaAbrirFormComponent implements OnInit {

    public mesa: AbrirMesa;
    public garcons: Garcom[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        http.get(baseUrl + 'api/garcon/listar').subscribe(result => {
            this.garcons = result.json() as Garcom[];
        }, error => console.error(error));

    }

    ngOnInit() {
    }

}

interface AbrirMesa {
    id: number;
    numMesa: number;
    garcom: Garcom;
    dataServico: string;
    ativo: boolean;
}

interface Garcom {
    id: number;
    nome: string;
}

