using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrganizaMEDServer.Views
{
    public class InserirCirugiaViewModel
    {
        public required string DataInicio { get; set; }
        public required int Duracao { get; set; }
        public IEnumerable<SelectListItem>? Medicos { get; set; }
    }

    public class EditarCirugiaViewModel
    {
        public required string DataInicio { get; set; }
        public required int Duracao { get; set; }
        public IEnumerable<SelectListItem>? Medicos { get; set; }
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
