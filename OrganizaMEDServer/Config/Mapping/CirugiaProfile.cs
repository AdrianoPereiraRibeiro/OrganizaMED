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

            CreateMap<InserirCirugiaViewModel, Cirugia>();
            CreateMap<EditarCirugiaViewModel, Cirugia>();

        }


    }
}
