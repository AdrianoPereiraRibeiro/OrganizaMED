import { Component, OnInit } from '@angular/core';
import { ListarMedicosViewModel } from '../models/models/medico.models';
import { NgForOf } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatCard, MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltip } from '@angular/material/tooltip';
import { MedicoService } from '../services/medico.service';

@Component({
  selector: 'app-listagem-medicos',
  standalone: true,
  imports: [NgForOf, RouterLink,MatCardModule,MatButtonModule,MatIconModule,MatTooltip],
  templateUrl: './listagem-medicos.component.html',
  styleUrl: './listagem-medicos.component.scss'
})
export class ListagemMedicosComponent implements OnInit {
medicos: ListarMedicosViewModel[];

constructor(private medicoService : MedicoService){
  this.medicos = [];
}
  ngOnInit(): void {
    this.medicoService.selecionarTodos().subscribe(res =>{
      this.medicos = res;
    })
  }

}
