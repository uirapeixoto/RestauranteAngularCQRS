import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

import { MesasComponent } from './mesas.component';
import { MesaStatusComponent } from './mesa-status.component';
import { MesaAbrirFormComponent } from './mesa-abrir-form.component';
import { MesaService } from './mesa.service';
import { MesaPedidoComponent } from './mesa-pedido.component';


const mesasRoutes: Routes = [
    { path: 'mesas', component: MesasComponent},
    { path: 'mesa-status/:id', component: MesaStatusComponent },
    { path: 'mesa-pedido/:id', component: MesaPedidoComponent },
    { path: 'mesa-abrir-form', component: MesaAbrirFormComponent }
]

@NgModule({
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild(mesasRoutes)
    ],
    declarations: [
        MesasComponent,
        MesaStatusComponent,
        MesaAbrirFormComponent,
        MesaPedidoComponent
    ],
    exports: [
        MesasComponent,
        MesaStatusComponent,
        MesaAbrirFormComponent,
        MesaPedidoComponent,
        RouterModule
    ],
    providers: [MesaService]
})
export class MesaModule { }
