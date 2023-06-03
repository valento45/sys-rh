using CsvHelper.Configuration;
using RH.Auva.Factory.Factorys;
using RH.Auva.Factory.Interfaces;
using System.Globalization;
using System.Text;

namespace RH.Auva.WebApp.Configurations.DependenciasInjection
{
    public static class FactoryConfiguration
    {

        public static void AddFactorys(this IServiceCollection services)
        {
            services.AddCsvConfiguration();

            services.AddTransient<ICsvFactory, CsvFactory>();
        }

        public static void AddCsvConfiguration(this IServiceCollection services)
        {

            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
            CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                Encoding = Encoding.UTF8
            };

            services.AddSingleton<CsvConfiguration>(csvConfiguration);
        }
    }
}

