
export interface ListarCirugiasViewModel{
   id: string;
   dataInicio: Date;
   duracao: number;
  }

  export interface InserirCirugiaViewModel {
    dataInicio: string;
    duracao: number;
    medicosIds: string[];
  }


  export interface CirugiaCriadoViewModel{
    id: string;
    dataInicio: Date;
    duracao: number;
    medicosIds: string[];
    }
    export interface VisualizarCirugiaViewModel {
      id: string;
      dataInicio: string;
      dataEncerramento: string;
      duracao: number;
      medicosIds: string[];
    }

    export interface ListarMedicoViewModel {
      id: string;
      nome: string;
    }

     export interface CirugiaExcluida{
      dataInicio: Date;
      duracao: number;
      medicosIds: string[];
        }
        export interface EditarCirugiaViewModel{
      id: string;
      dataInicio: Date;
      duracao: number;
      medicosIds: string[];
          }
          export interface SelectListItem {
             id: string;
             nome: string;
          }
