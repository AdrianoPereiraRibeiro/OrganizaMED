
export interface ListarCirugiasViewModel{
   id: string;
   dataInicio: Date;
   duracao: number;
  }

  export interface InserirCirugiaViewModel {
    dataInicio: string;
    duracao: number;
    medicosId: string[];
  }


  export interface CirugiaCriadoViewModel{
    id: string;
    dataInicio: Date;
    duracao: number;
    medicos: SelectListItem[];
    }
    export interface VisualizarCirugiaViewModel {
      id: string;
      dataInicio: string;
      dataEncerramento: string;
      duracao: number;
      medicos: SelectListItem[];
    }

    export interface ListarMedicoViewModel {
      id: string;
      nome: string;
    }

     export interface CirugiaExcluida{
      dataInicio: Date;
      duracao: number;
      medicos: SelectListItem[];
        }
        export interface EditarCirugiaViewModel{
          id: string;
      dataInicio: Date;
      duracao: number;
      medicos: SelectListItem[];
          }
          export interface SelectListItem {
             id: string;
             nome: string;
          }
