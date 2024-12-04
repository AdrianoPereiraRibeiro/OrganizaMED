using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrganizaMEDServer.Views
{
    public class InserirCirugiaViewModel
    {
        public required string DataInicio { get; set; }
        public required int Duracao { get; set; }
        public IEnumerable<Guid> MedicosIds { get; set; }
    }

    public class SelectListItem
    {
        public string Nome { get; set; }
        public Guid Id { get; set; }
    }

    public class EditarCirugiaViewModel
        {
            public required string DataInicio { get; set; }
            public required int Duracao { get; set; }
            public IEnumerable<Guid> MedicosIds { get; set; }
    }

        public class ListarCirugiaViewModel
        {
            public required Guid Id { get; set; }
            public required string DataInicio { get; set; }
        }


        public class VisualizarCirugiaViewModel
        {
            public required Guid Id { get; set; }
            public required string DataInicio { get; set; }
            public required string DataEncerramento { get; set; }
            public required int Duracao { get; set; }
            public required List<ListarMedicoViewModel> Medico { get; set; }

        }
    }

