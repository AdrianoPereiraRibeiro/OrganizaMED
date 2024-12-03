import { NgIf, NgForOf, CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { Router, RouterLink } from '@angular/router';
import { ConsultaService } from '../services/consulta.service';
import { InserirConsultaViewModel } from '../models/models/consulta.models';
import { MatDatepicker, MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { MedicoService } from '../../medicos/services/medico.service';
import { MatSelectModule } from '@angular/material/select';
import { Observable } from 'rxjs';
import { ListarMedicosViewModel } from '../../medicos/models/models/medico.models';

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
    MatNativeDateModule,
    MatSelectModule,
     MatOptionModule,
     CommonModule
  ],
  templateUrl: './cadastro-consulta.component.html',
})
export class CadastroconsultaComponent implements OnInit {
  consultaForm: FormGroup;
  medicos: ListarMedicosViewModel[];

  constructor(
    private router: Router,
    private consultaService: ConsultaService,
    private medicoService: MedicoService
  ) {
    this.medicos = [];
    this.consultaForm = new FormGroup({
      dataInicio: new FormControl<Date | null>(null, Validators.required),
      duracao: new FormControl<number | null>(null, [Validators.required, Validators.min(1)]),
      medicoId: new FormControl<string>('', Validators.required)
    });
  }

  ngOnInit(): void {
    this.carregarMedicos();
  }

  get dataInicio() {
    return this.consultaForm.get('dataInicio');
  }

  get duracao() {
    return this.consultaForm.get('duracao');
  }

  get medicoId() {
    return this.consultaForm.get('medicoId');
  }

  carregarMedicos(): void {
    this.medicoService.selecionarTodos().subscribe((data) => {
      this.medicos = data;
    });
  }

  cadastrar() {
    const novoconsulta: InserirConsultaViewModel = this.consultaForm.value;

    this.consultaService.cadastrar(novoconsulta).subscribe((res) => {
      this.router.navigate(['/consultas']);
    });
  }
}
