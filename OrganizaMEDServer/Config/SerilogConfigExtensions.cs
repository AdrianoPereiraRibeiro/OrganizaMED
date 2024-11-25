using Serilog;

namespace OrganizaMED.WebApi.Config
{
    public static class SerilogConfigExtensions
    {
        public static void ConfigureSerilog(this IServiceCollection services, ILoggingBuilder logging)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithClientIp()
                .Enrich.WithMachineName()
                .Enrich.WithThreadId()
                .WriteTo.Console()
                .CreateLogger();

            logging.ClearProviders();


            services.AddLogging(builder => builder.AddSerilog(dispose: true) );
        }


    }
}
