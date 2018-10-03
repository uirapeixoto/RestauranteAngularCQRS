import { Inject } from '@angular/core';
import { Http, Response, Headers, URLSearchParams, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Mesa } from '../shared/models/mesa.model';

export class MesaService {
    public mesas: Mesa[];
    //URL for CRUD operations
    mesaUrl = "";
    //Create constructor to get Http instance
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.mesaUrl = baseUrl + 'api/mesa/';
    }
    //Fetch all articles
    obterMesasAbertas(): Observable<Mesa[]> {
        return this.http.get(this.mesaUrl + '/mesasabertas')
            .map(this.extractData)
            .catch(this.handleError);

    }
    //Create article
    criarMesaAberta(mesa: Mesa): Observable<number> {
        let cpHeaders = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: cpHeaders });
        return this.http.post(this.mesaUrl + '/abrirnova', mesa, options)
            .map(success => success.status)
            .catch(this.handleError);
    }
    //Fetch article by id
    obterMesaPorId(mesaId: string): Observable<Mesa> {
        let cpHeaders = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: cpHeaders });
        console.log(this.mesaUrl + "/" + mesaId);
        return this.http.get(this.mesaUrl + "/" + mesaId)
            .map(this.extractData)
            .catch(this.handleError);
    }
    //Update article
    atualizarMesa(mesa: Mesa): Observable<number> {
        let cpHeaders = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: cpHeaders });
        return this.http.put(this.mesaUrl + "/" + mesa.id, mesa, options)
            .map(success => success.status)
            .catch(this.handleError);
    }
    //Delete article	
    fechaMesaPorId(mesaId: string): Observable<number> {
        let cpHeaders = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: cpHeaders });
        return this.http.delete(this.mesaUrl + "/" + mesaId)
            .map(success => success.status)
            .catch(this.handleError);
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