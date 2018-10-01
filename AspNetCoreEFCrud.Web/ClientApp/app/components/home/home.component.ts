import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    public garcons: Garcom[];
    public mesas: Mesa[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/mesa/mesasabertas').subscribe(result => {
            this.mesas = result.json() as Mesa[];
        }, error => console.error(error));
    }


}

interface Garcom {
    [index: string]:
    {
        id: number[],
        nome: string[]
    }
}

interface Mesa {
    [index: string]:
    {
        id: number[],
        numMesa: number[]
    }
}
