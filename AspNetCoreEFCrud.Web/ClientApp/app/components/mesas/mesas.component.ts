import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'mesas',
    templateUrl: './mesas.component.html'
})
export class MesasComponent {
    public mesas: Mesa[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/mesa/mesasabertas').subscribe(result => {
            this.mesas = result.json() as Mesa[];
        }, error => console.error(error));
    }
}

interface Mesa {
    id: number;
    numMesa: number;
    garcom: Garcom;
    dataServico: string;
    ativo: boolean;
}

interface Garcom
{
    id: number;
    nome: string;
}