import { Component, OnInit } from '@angular/core';
import { CommonModule, NgForOf } from '@angular/common';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatCard, MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltip } from '@angular/material/tooltip';
import { MedicoService } from '../../medicos/services/medico.service';
import { CirugiaService } from '../services/cirugia.service';
import { ListarCirugiasViewModel, SelectListItem, VisualizarCirugiaViewModel } from '../models/models/cirugia.models';
import { FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-visualizar-cirugias',
  standalone: true,
  imports: [NgForOf, RouterLink,MatCardModule,MatButtonModule,MatIconModule,MatTooltip,CommonModule],
  templateUrl: './visualizar-cirugias.component.html',
})
export class VisualizarCirugiaComponent implements OnInit {
  id? : string;
  cirugiaForm: FormGroup;
  medicos: SelectListItem[] = [];
  cirugia?: VisualizarCirugiaViewModel;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private cirugiaService: CirugiaService,
    private medicoService: MedicoService
  ) {
    this.cirugiaForm = new FormGroup({
      dataInicio: new FormControl<Date | null>(null, Validators.required),
      duracao: new FormControl<number | null>(null, [Validators.required, Validators.min(1)]),
      medicoIds: new FormControl<string[]>([])
    });
  }

  ngOnInit(): void {
    this.carregarMedicos();
    this.id = this.route.snapshot.params['id'];
    this.carregarCirugia();
    this.cirugiaService
      .selecionarPorId(this.id)
      .subscribe((res) => this.carregarFormulario(res));
  }

  get dataInicio() {
    return this.cirugiaForm.get('dataInicio');
  }

  get duracao() {
    return this.cirugiaForm.get('duracao');
  }

  get medicoIds() {
    return this.cirugiaForm.get('medicoIds');
  }




  carregarMedicos(): void {
    this.medicoService.selecionarTodos().subscribe((data) => {
      this.medicos = data.map((medico: any) => ({ nome: medico.nome, id: medico.id }));
    });
  }

  carregarCirugia(): void {
    this.cirugiaService.selecionarPorId(this.id).subscribe((data) => {
      this.cirugia = data;
    });
  }

  private carregarFormulario(registro: VisualizarCirugiaViewModel) {
    this.cirugiaForm.patchValue(registro);
  }
}



