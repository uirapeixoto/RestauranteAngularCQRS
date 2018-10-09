import { Injectable, Inject } from '@angular/core';
import { Http, Response, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { NovaMesa } from '../shared/models/novamesa.Model';
import { Mesa } from '../shared/models/mesa.Model';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class MesaService {
    mesaUrl: string;
    novamesa: NovaMesa;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.mesaUrl = baseUrl + 'api/mesa';
        this.novamesa = new NovaMesa();
    }

    obterMesasAbertas() {
        return this.http.get(this.mesaUrl + '/mesasabertas')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    abrirNovaMesa(mesa: NovaMesa): Observable<NovaMesa> {

        return this.http.post(this.mesaUrl + '/abrirnovamesa', mesa)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}