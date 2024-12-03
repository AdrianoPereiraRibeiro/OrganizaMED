import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ConsultaCriadoViewModel, ConsultaExcluida, EditarConsultaViewModel, InserirConsultaViewModel, ListarConsultasViewModel, VisualizarDetalhesConsulta } from '../models/models/consulta.models';

@Injectable({
  providedIn: 'root'
})
export class ConsultaService {
  editar(
    id: string | undefined,
    consultaEditada: EditarConsultaViewModel
  ): Observable<EditarConsultaViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.put<EditarConsultaViewModel>(urlCompleto, consultaEditada);
  }
  excluir(id: string | undefined) : Observable<ConsultaExcluida> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.delete<ConsultaExcluida>(urlCompleto);
  }
  selecionarPorId(id: string | undefined): Observable<VisualizarDetalhesConsulta> {
    const urlCompleto = `${this.url}/${id}?_expand=categoria`;

    return this.http.get<VisualizarDetalhesConsulta>(urlCompleto);
  }
  cadastrar(novoconsulta: InserirConsultaViewModel): Observable<ConsultaCriadoViewModel> {
    return this.http.post<ConsultaCriadoViewModel>(this.url, novoconsulta);
  }

private readonly url = `${environment.apiUrl}/consultas`;
  constructor(private http: HttpClient) { }


  selecionarTodos() {
  return this.http.get<ListarConsultasViewModel[]>(this.url)
  }


}
