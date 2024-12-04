import { NgIf, NgForOf, CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatDatepicker, MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { MedicoService } from '../../medicos/services/medico.service';
import { MatSelectModule } from '@angular/material/select';
import { Observable } from 'rxjs';
import { ListarMedicosViewModel } from '../../medicos/models/models/medico.models';
import { CirugiaService } from '../services/cirugia.service';
import { EditarCirugiaViewModel, InserirCirugiaViewModel, SelectListItem, VisualizarCirugiaViewModel } from '../models/models/cirugia.models';
import { EditarConsultaViewModel } from '../../consultas/models/models/consulta.models';

@Component({
  selector: 'app-edicao-cirugia',
  standalone: true,
  imports: [
    NgIf,
    RouterLink,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MatOptionModule,
    CommonModule
  ],
  templateUrl: './edicao-cirugia.component.html',
})

export class EdicaoCirugiaComponent implements OnInit {
  id? : string;
  cirugiaForm: FormGroup;
  medicos: SelectListItem[] = [];

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

  editar() {

    const cirugiaEditada: EditarCirugiaViewModel =  {
      id: this.cirugiaForm.value.id,
      dataInicio: this.cirugiaForm.value.dataInicio,
       duracao: this.cirugiaForm.value.duracao,
        medicosIds: this.cirugiaForm.value.medicoIds
       };

    this.cirugiaService.editar(this.id, cirugiaEditada).subscribe((res) => {
      this.router.navigate(['/cirugias']);
    });
  }

  private carregarFormulario(registro: VisualizarCirugiaViewModel) {
    this.cirugiaForm.patchValue(registro);
  }
}
