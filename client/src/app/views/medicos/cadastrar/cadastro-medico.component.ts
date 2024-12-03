import { NgIf, NgForOf } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { Router, RouterLink } from '@angular/router';
import { MedicoService } from '../services/medico.service';
import { InserirMedicoViewModel } from '../models/models/medico.models';

@Component({
  selector: 'app-cadastro-medico',
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
  templateUrl: './cadastro-medico.component.html',
})
export class CadastroMedicoComponent {
  medicoForm: FormGroup;

  constructor(
    private router: Router,
    private MedicoService: MedicoService,
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

  cadastrar() {
    const novoMedico: InserirMedicoViewModel = this.medicoForm.value;

    this.MedicoService.cadastrar(novoMedico).subscribe((res) => {
      this.router.navigate(['/medicos']);

    });
  }
}
