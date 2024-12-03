import { GeneratedIdentifierFlags } from "typescript";

export interface ListarMedicosViewModel{
  id: string;
  nome: string;
  crm : string;
  }

  export interface InserirMedicoViewModel{
  nome: string;
  crm : string;
  }
  export interface MedicoCriadoViewModel{
    id: string;
    nome: string;
    crm : string;
    }
    export interface VisualizarDetalhesMedico{
      id: string;
      nome: string;
      crm : string;
      }
     export interface MedicoExcluido{
        nome: string;
        crm : string;
        }
        export interface EditarMedicoViewModel{
          id: string;
          nome: string;
          crm : string;
          }
