import { Component, OnInit } from '@angular/core';
import { CommonModule, NgForOf } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatCard, MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltip } from '@angular/material/tooltip';
import { MedicoService } from '../../medicos/services/medico.service';
import { CirugiaService } from '../services/cirugia.service';
import { ListarCirugiasViewModel } from '../models/models/cirugia.models';



@Component({
  selector: 'app-listagem-cirugias',
  standalone: true,
  imports: [NgForOf, RouterLink,MatCardModule,MatButtonModule,MatIconModule,MatTooltip,CommonModule],
  templateUrl: './listagem-cirugias.component.html',
})
export class ListagemcirugiasComponent implements OnInit {
cirugias: ListarCirugiasViewModel[];

constructor(private cirugiaService : CirugiaService,
  private medicoService: MedicoService
){
  this.cirugias = [];
}
ngOnInit(): void {
  this.cirugiaService.selecionarTodos().subscribe(res =>{
    this.cirugias = res;
  })
      };
    };


