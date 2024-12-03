import { NgIf, AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { ConsultaService } from '../services/consulta.service';
import { VisualizarDetalhesConsulta } from '../models/models/consulta.models';


@Component({
  selector: 'app-exclusao-Consulta',
  standalone: true,
  imports: [NgIf, RouterLink, AsyncPipe, MatButtonModule, MatIconModule],
  templateUrl: './exclusao-consulta.component.html'
})
export class ExclusaoConsultaComponent implements OnInit {
  id?: string;
  consulta$?: Observable<VisualizarDetalhesConsulta>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private consultaService: ConsultaService,
  ) {}

  ngOnInit(): void {
     this.id = this.route.snapshot.params['id'];
    this.consulta$ = this.consultaService.selecionarPorId(this.id);
  }

  excluir() {

    this.consultaService.excluir(this.id).subscribe((res) => {
      this.router.navigate(['/consultas']);
    });
  }
}
