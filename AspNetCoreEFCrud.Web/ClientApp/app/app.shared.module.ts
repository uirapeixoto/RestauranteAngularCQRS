import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CozinhaComponent } from './components/cozinha/cozinha.component';
import { CounterComponent } from './components/counter/counter.component';
import { GarconsComponent } from './components/garcons/garcons.component';
import { MesasComponent } from './components/mesas/mesas.component';
import { MesaStatusComponent } from './components/mesas/mesaStatus.component';
import { GarcomTarefasComponent } from './components/garcons/garcomTarefas.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        CozinhaComponent,
        MesasComponent,
        MesaStatusComponent,
        GarconsComponent,
        GarcomTarefasComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'cozinha', component: CozinhaComponent },
            { path: 'garcons', component: GarconsComponent },
            { path: 'garcom-tarefas/:id', component: GarcomTarefasComponent },
            { path: 'mesas', component: MesasComponent },
            { path: 'mesa-status/:id', component: MesaStatusComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
