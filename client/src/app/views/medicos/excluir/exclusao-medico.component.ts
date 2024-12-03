import { NgIf, AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { MedicoService } from '../services/medico.service';
import { VisualizarDetalhesMedico } from '../models/models/medico.models';


@Component({
  selector: 'app-exclusao-medico',
  standalone: true,
  imports: [NgIf, RouterLink, AsyncPipe, MatButtonModule, MatIconModule],
  templateUrl: './exclusao-medico.component.html'
})
export class ExclusaoMedicoComponent implements OnInit {
  id?: string;
  medico$?: Observable<VisualizarDetalhesMedico>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private medicoService: MedicoService,
  ) {}

  ngOnInit(): void {
     this.id = this.route.snapshot.params['id'];
    this.medico$ = this.medicoService.selecionarPorId(this.id);
  }

  excluir() {

    this.medicoService.excluir(this.id).subscribe((res) => {
      this.router.navigate(['/medicos']);
    });
  }
}
