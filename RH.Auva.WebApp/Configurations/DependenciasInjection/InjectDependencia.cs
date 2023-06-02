using RH.Auva.WebApp.Configurations.DependenciasInjection;

namespace RH.Auva.Application.Configurations.DependenciasInjection
{
    public static class InjectDependencia
    {
        /// <summary>
        /// Adiciona todas as dependências do projeto
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddInjecaoDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            services.AddFactorys();
            services.AddRepositorys();
            services.AddDataBaseConfiguration(configuration);
        }
    }
}
