import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { CirugiaCriadoViewModel, CirugiaExcluida, EditarCirugiaViewModel, InserirCirugiaViewModel, ListarCirugiasViewModel, VisualizarCirugiaViewModel } from '../models/models/cirugia.models';

@Injectable({
  providedIn: 'root'
})
export class CirugiaService {
  editar(
    id: string | undefined,
    CirugiaEditada: EditarCirugiaViewModel
  ): Observable<EditarCirugiaViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.put<EditarCirugiaViewModel>(urlCompleto, CirugiaEditada);
  }
  excluir(id: string | undefined) : Observable<CirugiaExcluida> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.delete<CirugiaExcluida>(urlCompleto);
  }
  selecionarPorId(id: string | undefined): Observable<VisualizarCirugiaViewModel> {
    const urlCompleto = `${this.url}/${id}?_expand=categoria`;

    return this.http.get<VisualizarCirugiaViewModel>(urlCompleto);
  }
  cadastrar(novoCirugia: InserirCirugiaViewModel): Observable<CirugiaCriadoViewModel> {
    return this.http.post<CirugiaCriadoViewModel>(this.url, novoCirugia);
  }

private readonly url = `${environment.apiUrl}/cirugias`;
  constructor(private http: HttpClient) { }


  selecionarTodos() {
  return this.http.get<ListarCirugiasViewModel[]>(this.url)
  }


}
