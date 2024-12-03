import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { EditarMedicoViewModel, InserirMedicoViewModel, ListarMedicosViewModel, MedicoCriadoViewModel, MedicoExcluido, VisualizarDetalhesMedico } from '../models/models/medico.models';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class MedicoService {
  editar(
    id: string | undefined,
    medicoEditada: EditarMedicoViewModel
  ): Observable<EditarMedicoViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.put<EditarMedicoViewModel>(urlCompleto, medicoEditada);
  }
  excluir(id: string | undefined) : Observable<MedicoExcluido> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.delete<MedicoExcluido>(urlCompleto);
  }
  selecionarPorId(id: string | undefined): Observable<VisualizarDetalhesMedico> {
    const urlCompleto = `${this.url}/${id}?_expand=categoria`;

    return this.http.get<VisualizarDetalhesMedico>(urlCompleto);
  }
  cadastrar(novoMedico: InserirMedicoViewModel): Observable<MedicoCriadoViewModel> {
    return this.http.post<MedicoCriadoViewModel>(this.url, novoMedico);
  }

private readonly url = `${environment.apiUrl}/medicos`;
  constructor(private http: HttpClient) { }


  selecionarTodos() {
  return this.http.get<ListarMedicosViewModel[]>(this.url)
  }


}
