import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'garcons',
    templateUrl: './garcons.component.html'
})
export class GarconsComponent {
    public garcons: Garcon[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/garcon/listar').subscribe(result => {
            this.garcons = result.json() as Garcon[];
        }, error => console.error(error));
    }
}

interface Garcon {
    id: number;
    nome: string;
}
