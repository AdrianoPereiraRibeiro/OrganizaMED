import { NgIf, AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { VisualizarCirugiaViewModel } from '../models/models/cirugia.models';
import { CirugiaService } from '../services/cirugia.service';

@Component({
  selector: 'app-exclusao-cirugia',
  standalone: true,
  imports: [NgIf, RouterLink, AsyncPipe, MatButtonModule, MatIconModule],
  templateUrl: './exclusao-cirugias.component.html'
})
export class ExclusaocirugiaComponent implements OnInit {
  id?: string;
  cirugia$?: Observable<VisualizarCirugiaViewModel>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private cirugiaService: CirugiaService,
  ) {}

  ngOnInit(): void {
     this.id = this.route.snapshot.params['id'];
    this.cirugia$ = this.cirugiaService.selecionarPorId(this.id);
  }

  excluir() {

    this.cirugiaService.excluir(this.id).subscribe((res) => {
      this.router.navigate(['/cirugias']);
    });
  }
}
