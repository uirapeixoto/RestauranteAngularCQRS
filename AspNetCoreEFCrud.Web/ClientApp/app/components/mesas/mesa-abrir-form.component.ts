import { Component, OnInit, Inject } from '@angular/core';
import { Http, Response, Headers, URLSearchParams, RequestOptions } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';  
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { MesaService } from './mesa.service';

@Component({
    selector: 'mesa-abrir-form',
    templateUrl: './mesa-abrir-form.component.html',
})
export class MesaAbrirFormComponent implements OnInit {

    public novaMesa: NovaMesa;
    public garcons: Garcom[];
    
    public novaMesaForm: FormGroup;
    public title: string;

    errorMessage: any;
    mesaUrl: string;

    constructor(
        private _fb: FormBuilder,
        private _avRoute: ActivatedRoute,
        private _router: Router,
        private http: Http,
        @Inject('BASE_URL') baseUrl: string) {

        this.title = "Abrir Nova Mesa";
        this.mesaUrl = baseUrl + 'api/mesa/';

        http.get(baseUrl + 'api/garcon/listar').subscribe(result => {
            this.garcons = result.json() as Garcom[];
        }, error => console.error(error));

        this.novaMesaForm = this._fb.group(
            {
                numMesa: [1, [Validators.required]],
                garcomId: [this.garcons, [Validators.required]]
            }
        )
    }

    ngOnInit() {
    }

    salvar() {
        if (this.novaMesaForm.valid) {
            console.log("formulario invalido!")
            return;
        }
        console.log("segue a validacao!")
        let cpHeaders = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: cpHeaders });
        return this.http.post(this.mesaUrl + '/abrirnova', this.novaMesaForm.value, options)
            .map((response: Response) => response.json()).catch(this.handleError);

    }

    private extractData(res: Response) {
        let body = res.json();
        return body;
    }

    private handleError(error: Response | any) {
        console.error(error.message || error);
        return Observable.throw(error.status);
    }

}

interface NovaMesa {
    numMesa: number;
    garcomId: number;
}

interface Garcom {
    id: number;
    nome: string;
}

