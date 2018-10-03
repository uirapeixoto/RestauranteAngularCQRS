import { Garcom } from './garcom.model';

export class Mesa {

    id?: number;
    numMesa: number;
    garcom: Garcom;
    dataServico?: string;
    ativo?: boolean;

    constructor() { }
}