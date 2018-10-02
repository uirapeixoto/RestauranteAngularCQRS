import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MesasComponent } from './mesas.component';
import { MesaStatusComponent } from './mesa-status.component';
import { MesaAbrirFormComponent } from './mesa-abrir-form.component';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        MesasComponent,
        MesaStatusComponent,
        MesaAbrirFormComponent
    ],
    exports: [
        MesasComponent
    ],
    providers: []
})
export class MesaModule { }
