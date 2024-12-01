import { Component } from '@angular/core';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { NgForOf } from '@angular/common';
import { MatDividerModule } from '@angular/material/divider';
import { ItemRedirectDashboard } from './models/item-redirect-dashboard.model';

@Component({
selector: 'app-dashboard',
standalone: true,
imports: [NgForOf, RouterLink, MatCardModule, MatIconModule, MatButtonModule, MatDividerModule],
templateUrl: './dashboard.component.html',
styleUrl: './dashboard.component.scss',
})
export class DashboardComponent {
itensRedirect: ItemRedirectDashboard[] = [
{ rota: '/medicos', texto: 'Medicos', icone: 'people' },
{ rota: '/consultas', texto: 'Consultas', icone: 'event' },
{ rota: '/cirugias', texto: 'Cirugias', icone: 'person_add' },
];
}
