using RH.Auva.Factory.Factorys;
using RH.Auva.Factory.Interfaces;

namespace RH.Auva.WebApp.Configurations.DependenciasInjection
{
    public static class FactoryConfiguration
    {

        public static void AddFactorys(this IServiceCollection services)
        {

            services.AddTransient<IExcelFactory, ExcelFactory>();
        }
    }
}
