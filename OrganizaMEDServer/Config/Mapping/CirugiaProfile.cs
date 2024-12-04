using AutoMapper;
using OrganizaMED.Dominio.ModuloCirugia;
using OrganizaMEDServer.Views;

namespace OrganizaMEDServer.Config.Mapping
{
    public class CirugiaProfile : Profile
    {
        public CirugiaProfile()
        {
            CreateMap<Cirugia, ListarCirugiaViewModel>();
            CreateMap<Cirugia, VisualizarCirugiaViewModel>();

            CreateMap<InserirCirugiaViewModel, Cirugia>().
                ForMember(dest => dest.DataDeInicio, opt => opt.MapFrom(src => src.DataInicio)); ;
            CreateMap<EditarCirugiaViewModel, Cirugia>().
                ForMember(dest => dest.DataDeInicio, opt => opt.MapFrom(src => src.DataInicio)); ;

        }


    }
}
