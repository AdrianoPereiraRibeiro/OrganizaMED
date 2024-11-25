using OrganizaMED.Dominio.ModuloMedico;

namespace OrganizaMEDServer.Views
{
    public class InserirConsultaViewModel
    {
        public required string DataInicio { get; set; }
        public required int Duracao { get; set; }
        public required Guid MedicoId { get; set; }
    }

    public class EditarConsultaViewModel
    {
        public required string DataInicio { get; set; }
        public required int Duracao { get; set; }
        public required Guid MedicoId { get; set; }
    }

    public class ListarConsultaViewModel
    {
        public required Guid Id { get; set; }
        public required string DataInicio { get; set; }
    }


    public class VisualizarConsultaViewModel
    {
        public required Guid Id { get; set; }
        public required string DataInicio { get; set; }
        public required string DataEncerramento { get; set; }
        public required int Duracao { get; set; }
        public required ListarMedicoViewModel Medico { get; set; }

    }
}
