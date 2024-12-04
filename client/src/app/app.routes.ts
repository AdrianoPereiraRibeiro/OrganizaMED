import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { ListagemMedicosComponent } from './views/medicos/listar/listagem-medicos.component';
import { CadastroMedicoComponent } from './views/medicos/cadastrar/cadastro-medico.component';
import { ExclusaoMedicoComponent } from './views/medicos/excluir/exclusao-medico.component';
import { EdicaoMedicoComponent } from './views/medicos/editar/edicao-medico.component';
import { ListagemConsultasComponent } from './views/consultas/listar/listagem-consultas.component';
import { ExclusaoConsultaComponent } from './views/consultas/excluir/exclusao-consulta.component';
import { CadastroconsultaComponent } from './views/consultas/cadastrar/cadastro-consulta.component';
import { EditarConsultaComponent } from './views/consultas/editar/edicao-consulta.component';
import { ListagemcirugiasComponent } from './views/cirugias/listar/listagem-cirugias.component';
import { CadastroCirugiaComponent } from './views/cirugias/cadastrar/cadastro-cirugia.component';
import { EdicaoCirugiaComponent } from './views/cirugias/editar/edicao-cirugia.component';
import { ExclusaocirugiaComponent } from './views/cirugias/excluir/exclusao-cirugia.component';
import { VisualizarCirugiaComponent } from './views/cirugias/visualizar/visualizar-cirugias.component';
export const routes: Routes = [
   { path: '', redirectTo: 'dashboard',
     pathMatch: 'full' },
     { path: 'dashboard', loadComponent: () => import('./views/dashboard/dashboard.component')
      .then( (m) => m.DashboardComponent ), },

      {path : `medicos`, component: ListagemMedicosComponent},

      {path : 'medicos/cadastrar', component: CadastroMedicoComponent },
      {path : 'medicos/excluir/:id', component: ExclusaoMedicoComponent },
      {path : 'medicos/editar/:id', component: EdicaoMedicoComponent },

      {path : `consultas`, component: ListagemConsultasComponent},

      {path : 'consultas/cadastrar', component: CadastroconsultaComponent },
      {path : 'consultas/excluir/:id', component: ExclusaoConsultaComponent },
      {path : 'consultas/editar/:id', component: EditarConsultaComponent },

      {path : `cirugias`, component: ListagemcirugiasComponent},

      {path : 'cirugias/cadastrar', component: CadastroCirugiaComponent },
      {path : 'cirugias/excluir/:id', component: ExclusaocirugiaComponent },
      {path : 'cirugias/editar/:id', component: EdicaoCirugiaComponent },
      {path : 'cirugias/visualizar/:id', component: VisualizarCirugiaComponent }
 ];


