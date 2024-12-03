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
import { NgIf } from '@angular/common';
import { MedicoService } from '../services/medico.service';
import { EditarMedicoViewModel, VisualizarDetalhesMedico } from '../models/models/medico.models';


@Component({
  selector: 'app-edicao-medico',
  standalone: true,
  imports: [
    NgIf,
    RouterLink,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
  ],
  templateUrl: './edicao-medico.component.html',
})
export class EdicaoMedicoComponent implements OnInit {
  id?: string;
  medicoForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private medicoService: MedicoService,
  ) {
    this.medicoForm = new FormGroup({
      nome: new FormControl<string>('', [
        Validators.minLength(3),
      ]),
      crm: new FormControl<string>('',[
        Validators.minLength(3)
      ])
    });
  }

  get nome() {
    return this.medicoForm.get('nome');
  }

  get crm() {
    return this.medicoForm.get('crm');
  }
  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    this.medicoService
      .selecionarPorId(this.id)
      .subscribe((res) => this.carregarFormulario(res));
  }

  editar() {

    const medicoEditada: EditarMedicoViewModel = this.medicoForm.value;

    this.medicoService.editar(this.id, medicoEditada).subscribe((res) => {
      this.router.navigate(['/medicos']);
    });
  }

  private carregarFormulario(registro: VisualizarDetalhesMedico) {
    this.medicoForm.patchValue(registro);
  }
}
