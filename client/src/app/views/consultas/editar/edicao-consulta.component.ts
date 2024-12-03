import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CommonModule, NgIf } from '@angular/common';
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ConsultaService } from '../services/consulta.service';
import { EditarConsultaViewModel, VisualizarDetalhesConsulta } from '../models/models/consulta.models';
import { MatSelectModule } from '@angular/material/select';
import { ListarMedicosViewModel } from '../../medicos/models/models/medico.models';
import { MedicoService } from '../../medicos/services/medico.service';

@Component({
  selector: 'app-cadastro-consulta',
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
    MatNativeDateModule ,
    MatSelectModule,
    MatOptionModule,
    CommonModule
  ],
  templateUrl: './edicao-consulta.component.html',
})
export class EditarConsultaComponent {
  id?: string;
  consultaForm: FormGroup;
  medicos: ListarMedicosViewModel[];

  constructor(
    private router: Router,
    private consultaService: ConsultaService,
    private route: ActivatedRoute,
    private medicoService: MedicoService
  ) {
    this.medicos = [];
    this.consultaForm = new FormGroup({
      dataInicio: new FormControl<Date | null>(null, Validators.required),
      duracao: new FormControl<number | null>(null, [Validators.required, Validators.min(1)]),
      medicoId: new FormControl<string>('', Validators.required)
    });
  }

  get dataInicio() {
    return this.consultaForm.get('dataInicio');
  }

  get duracao() {
    return this.consultaForm.get('duracao');
  }
  get medicoId(){
    return this.consultaForm.get('medicoId');
  }

  ngOnInit(): void {
    this.carregarMedicos();
    this.id = this.route.snapshot.params['id'];

    this.consultaService
      .selecionarPorId(this.id)
      .subscribe((res) => this.carregarFormulario(res));
  }

  editar() {
    const novoconsulta: EditarConsultaViewModel = this.consultaForm.value;

    this.consultaService.editar(this.id,novoconsulta).subscribe((res) => {
      this.router.navigate(['/consultas']);

    });
  }

  private carregarFormulario(registro: VisualizarDetalhesConsulta) {
    this.consultaForm.patchValue(registro);
  }

  carregarMedicos(): void {
    this.medicoService.selecionarTodos().subscribe((data) => {
      this.medicos = data;
    });
  }


}


