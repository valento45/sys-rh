using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Rh.Auva.Domain.Security;
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
                string encryptBase = configuration.GetConnectionString("Production");

                var baseDecrypt = Security.Decrypt(encryptBase);
                var basedados = JsonConvert.DeserializeObject<DatabaseSecurity>(baseDecrypt);

                connectionString = $"Server={basedados.Server};Database={basedados.Database};user={basedados.User};password={basedados.Pass};SslMode=VerifyFull;";
            }

            else
                connectionString = configuration.GetConnectionString("MySql");


            MySqlConnection con = new MySqlConnection(connectionString);

            services.AddSingleton<IDbConnection>(con);
        }

    }
}
