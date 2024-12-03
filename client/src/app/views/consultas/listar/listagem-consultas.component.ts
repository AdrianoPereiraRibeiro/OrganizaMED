import { Component, OnInit } from '@angular/core';
import { CommonModule, NgForOf } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatCard, MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltip } from '@angular/material/tooltip';
import { ListarConsultasViewModel } from '../models/models/consulta.models';
import { ConsultaService } from '../services/consulta.service';
import { MedicoService } from '../../medicos/services/medico.service';



@Component({
  selector: 'app-listagem-consultas',
  standalone: true,
  imports: [NgForOf, RouterLink,MatCardModule,MatButtonModule,MatIconModule,MatTooltip,CommonModule],
  templateUrl: './listagem-consultas.component.html',
})
export class ListagemConsultasComponent implements OnInit {
consultas: ListarConsultasViewModel[];

constructor(private consultaService : ConsultaService,
  private medicoService: MedicoService
){
  this.consultas = [];
}
  ngOnInit(): void {
    this.consultaService.selecionarTodos().subscribe(res => {
      res.forEach(consulta => {
        this.medicoService.selecionarPorId(consulta.medicoId).subscribe(medico => {
          consulta.medicoNome = medico.nome;
          this.consultas.push(consulta);
        });
      });
    });
  }
}
