import { Component, OnInit, Inject } from '@angular/core';
import { Http, Response, Headers, URLSearchParams, RequestOptions } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { MesaAbrirFormComponent } from './mesa-abrir-form.component';
import { Pedido } from '../shared/models/Pedido.model';

@Component({
    selector: 'mesa-pedido',
    templateUrl: './mesa-pedido.component.html'
})
export class MesaPedidoComponent {
    public pedido: Pedido;

    public pedidoMesaForm: FormGroup;

    public title: string;
    public successMessage: string = "";
    mesaUrl: string;
    id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder,
        private _avRoute: ActivatedRoute,
        private _router: Router,
        private http: Http,
        @Inject('BASE_URL') baseUrl: string) {

        this.title = "Abrir Nova Mesa";
        this.mesaUrl = baseUrl + 'api/mesa/';

        this._avRoute.params.subscribe(res => this.id = res.id);

        http.get(this.mesaUrl + 'pedido/' + this.id).subscribe(result => {
            this.pedido = result.json() as Pedido;
        }, error => console.error(error));

        this.pedidoMesaForm = this._fb.group(
            {
                MesaId: [1, [Validators.required]],
            }
        )
    }

    Pedir() {
        console.log(this.pedidoMesaForm.value);
    }
}