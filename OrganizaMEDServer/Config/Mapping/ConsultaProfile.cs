using AutoMapper;
using OrganizaMED.Dominio.ModuloConsulta;
using OrganizaMED.Dominio.ModuloConsulta;
using OrganizaMED.Dominio.ModuloMedico;
using OrganizaMEDServer.Views;

namespace OrganizaMEDServer.Config.Mapping
{
    public class ConsultaProfile : Profile
    {
        public  ConsultaProfile()
        {
            CreateMap<Consulta, ListarConsultaViewModel>();
            CreateMap<Consulta, VisualizarConsultaViewModel>();
            CreateMap<InserirConsultaViewModel, Consulta>().
                ForMember(dest => dest.DataDeInicio, opt => opt.MapFrom(src => src.DataInicio));
            CreateMap<EditarConsultaViewModel, Consulta>().
                ForMember(dest => dest.DataDeInicio, opt => opt.MapFrom(src => src.DataInicio));
            CreateMap<Medico, ListarMedicoViewModel>();
            CreateMap<Medico, VisualizarMedicoViewModel>();
        }


    }
}
