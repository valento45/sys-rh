using MySql.Data.MySqlClient;
using RH.Auva.Persistence.Repositorys;
using RH.Auva.Persistence.Repositorys.Interfaces;
using System.Data;

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
            string connectionString = configuration.GetConnectionString("MySql");

            MySqlConnection con = new MySqlConnection(connectionString);

            services.AddSingleton<IDbConnection>(con);
        }   

    }
}
