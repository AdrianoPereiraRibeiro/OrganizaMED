import { NgIf, NgForOf, CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { Router, RouterLink } from '@angular/router';
import { MatDatepicker, MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { MedicoService } from '../../medicos/services/medico.service';
import { MatSelectModule } from '@angular/material/select';
import { Observable } from 'rxjs';
import { ListarMedicosViewModel } from '../../medicos/models/models/medico.models';
import { CirugiaService } from '../services/cirugia.service';
import { InserirCirugiaViewModel, SelectListItem } from '../models/models/cirugia.models';

@Component({
  selector: 'app-cadastro-cirugia',
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
  templateUrl: './cadastro-cirugia.component.html',
})

export class CadastroCirugiaComponent implements OnInit {
  cirugiaForm: FormGroup;
  medicos: SelectListItem[] = [];

  constructor(
    private router: Router,
    private cirugiaService: CirugiaService,
    private medicoService: MedicoService
  ) {
    this.cirugiaForm = new FormGroup({
      dataInicio: new FormControl<Date | null>(null, Validators.required),
      duracao: new FormControl<number | null>(null, [Validators.required, Validators.min(1)]),
      medicoIds: new FormControl<string[]>([], Validators.required)
    });
  }

  ngOnInit(): void {
    this.carregarMedicos();
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

  cadastrar() {
    const novacirugia: InserirCirugiaViewModel = this.cirugiaForm.value;

    this.cirugiaService.cadastrar(novacirugia).subscribe((res) => {
      this.router.navigate(['/cirugias']);
    });
  } }
