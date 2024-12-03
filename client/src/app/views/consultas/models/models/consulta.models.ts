import { GeneratedIdentifierFlags } from "typescript";

export interface ListarConsultasViewModel{
   id: string;
   dataInicio: Date;
   duracao: number;
   medicoId: string
   medicoNome?: string
  }

  export interface InserirConsultaViewModel{
    dataInicio: Date;
    duracao: number;
    medicoId: string
  }
  export interface ConsultaCriadoViewModel{
    id: string;
    dataInicio: Date;
    duracao: number;
    medicoId: string
    }
    export interface VisualizarDetalhesConsulta{
      id: string;
      dataInicio: Date;
      duracao: number;
      medicoId: string
      }
     export interface ConsultaExcluida{
      dataInicio: Date;
      duracao: number;
      medicoId: string
        }
        export interface EditarConsultaViewModel{
          id: string;
      dataInicio: Date;
      duracao: number;
      medicoId: string
          }
