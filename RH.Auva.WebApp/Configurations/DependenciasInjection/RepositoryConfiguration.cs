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
            {
                string server = configuration.GetSection("Production:Server").Value;
                string database = configuration.GetSection("Production:Database").Value;
                string user = configuration.GetSection("Production:User").Value;
                string pass = configuration.GetSection("Production:Pass").Value;

                connectionString = $"Server={server};Database={database};user={user};password={pass};SslMode=VerifyFull;";
            } 

            else
                connectionString = configuration.GetConnectionString("MySql");


            MySqlConnection con = new MySqlConnection(connectionString);

            services.AddSingleton<IDbConnection>(con);
        }

    }
}
