
using Microsoft.EntityFrameworkCore;
using OrganizaMED.Aplicacao.ModuloCirugia;
using OrganizaMED.Aplicacao.ModuloConsulta;
using OrganizaMED.Aplicacao.ModuloMedico;
using OrganizaMED.Dominio.Compartilhado;
using OrganizaMED.Dominio.ModuloCirugia;
using OrganizaMED.Dominio.ModuloConsulta;
using OrganizaMED.Dominio.ModuloMedico;
using OrganizaMED.Infra.ModuloCirugia;
using OrganizaMED.Infra.ModuloConsulta;
using OrganizaMED.Infra.ModuloMedico;
using OrganizaMED.Infra.Orm.Compartilhado;
using OrganizaMED.WebApi.Config;
using OrganizaMED.WebApi.Filters;
using OrganizaMEDServer.Config.Mapping;
using Serilog;

namespace OrganizaMEDServer
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("SqlServer");

            builder.Services.AddDbContext<IContextoPersistencia, OrganizaMEDDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IRepositorioMedico, RepositorioMedicoOrm>();
            builder.Services.AddScoped<ServiceMedico>();
            builder.Services.AddScoped<IRepositorioConsulta, RepositorioConsultaOrm>();
            builder.Services.AddScoped<ServiceConsulta>();
            builder.Services.AddScoped<IRepositorioCirugia, RepositorioCirugiaOrm>();
            builder.Services.AddScoped<ServiceCirugia>();

        ;

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile<MedicoProfile>();
                config.AddProfile<ConsultaProfile>();
                config.AddProfile<CirugiaProfile>();
            });

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ResponseWrapperFilter>();
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.ConfigureSerilog(builder.Logging);

            //
            var app = builder.Build();

            app.UseGlobalExceptionHandler();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal("Ocorreu um erro que fechou a aplicação.", ex);

                return;
            }

        }
    }
}
