using RH.Auva.Application.Application.CSV;
using RH.Auva.Application.Application.CSV.Interfaces;
using RH.Auva.Factory.Command;
using RH.Auva.Factory.Command.Interfaces;

namespace RH.Auva.Application.Configurations.DependenciasInjection
{
    public static class CommandConfiguration
    {
        public static void AddCommands(this IServiceCollection services)
        {
            services.AddTransient<ICsvApplication, CsvApplication>();   
            services.AddTransient<ICsvCommand, CsvCommand>();   
        }
    }
}
