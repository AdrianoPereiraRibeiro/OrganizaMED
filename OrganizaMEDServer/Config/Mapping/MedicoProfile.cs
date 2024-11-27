using AutoMapper;
using OrganizaMED.Dominio.ModuloMedico;
using OrganizaMEDServer.Views;

namespace OrganizaMEDServer.Config.Mapping
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            CreateMap<Medico, ListarMedicoViewModel>();
            CreateMap<Medico, VisualizarMedicoViewModel>();

            CreateMap<InserirMedicoViewModel, Medico>();
            CreateMap<EditarMedicoViewModel, Medico>();

           

        }
    }
}
