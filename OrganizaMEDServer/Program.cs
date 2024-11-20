
using Microsoft.EntityFrameworkCore;
using OrganizaMED.Dominio.Compartilhado;
using OrganizaMED.Infra.Orm.Compartilhado;
using OrganizaMED.WebApi.Config;
using OrganizaMED.WebApi.Filters;
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

            //builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoriaOrm>();
            //builder.Services.AddScoped<ServicoCategoria>();

            //builder.Services.AddScoped<IRepositorioNota, RepositorioNotaOrm>();
            //builder.Services.AddScoped<ServicoNota>();

            builder.Services.AddAutoMapper(config =>
            {
                //config.AddProfile<CategoriaProfile>();
                //config.AddProfile<NotaProfile>();
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
