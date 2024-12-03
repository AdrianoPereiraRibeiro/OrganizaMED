import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { ListagemMedicosComponent } from './views/medicos/listar/listagem-medicos.component';
import { CadastroMedicoComponent } from './views/medicos/cadastrar/cadastro-medico.component';
import { ExclusaoMedicoComponent } from './views/medicos/excluir/exclusao-medico.component';
import { EdicaoMedicoComponent } from './views/medicos/editar/edicao-medico.component';
export const routes: Routes = [
   { path: '', redirectTo: 'dashboard',
     pathMatch: 'full' },
     { path: 'dashboard', loadComponent: () => import('./views/dashboard/dashboard.component')
      .then( (m) => m.DashboardComponent ), },

      {path : `medicos`, component: ListagemMedicosComponent},

      {path : 'medicos/cadastrar', component: CadastroMedicoComponent },
      {path : 'medicos/excluir/:id', component: ExclusaoMedicoComponent },
      {path : 'medicos/editar/:id', component: EdicaoMedicoComponent }

 ];

