using MySql.Data.MySqlClient;
using RH.Auva.Persistence.Repositorys;
using RH.Auva.Persistence.Repositorys.Interfaces;
using System.Data;
using System.Diagnostics;

namespace RH.Auva.WebApp.Configurations.DependenciasInjection
{
    public static class RepositoryConfiguration
    {

        public static void AddRepositorys(this IServiceCollection services)
        {
            services.AddTransient<IDepartamentoRepository, DepartamentoRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<IPontoFuncionarioRepository, PontoFuncionarioRepository>();
        }


        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = "";

            if (!Debugger.IsAttached)
                connectionString = configuration.GetConnectionString("Production");

            else
                connectionString = configuration.GetConnectionString("MySql");


            MySqlConnection con = new MySqlConnection(connectionString);

            services.AddSingleton<IDbConnection>(con);
        }

    }
}
