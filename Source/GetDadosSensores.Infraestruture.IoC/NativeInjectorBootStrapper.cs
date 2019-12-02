using AcessoDados.Repository;
using GetDadosSensores.Application;
using GetDadosSensores.Application.Interface;
using GetDadosSensores.Domain.Interfaces.IRepository;
using GetDadosSensores.Domain.Interfaces.IService;
using GetDadosSensores.Domain.DomainServices;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class NativeInjectorBootStrapper
    {   
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Service       
            services.AddScoped<IAppServiceSenPresenca, AppServiceSenPresenca>();
            services.AddScoped<IAppServiceSenChuva, AppServiceSenChuva>();
            services.AddScoped<IAppServiceSenTemperaturaUmidade, AppServiceSenTemperaturaUmidade>();
            //Domain Services
            services.AddScoped<IServiceSenPresenca, ServiceSenPresenca>();
            services.AddScoped<IServiceSenChuva, ServiceSenChuva>();
            services.AddScoped<IServiceSenTemperaturaHumidade, ServiceSenTemperaturaHumidade>();
            //Repositories
            services.AddScoped<IRepositorySenPresenca, RepositorySenPresenca>();
            services.AddScoped<IRepositorySenChuva, RepositorySenChuva>();
            services.AddScoped<IRepositorySenTemperaturaHumidade, RepositorySenTemperaturaHumidade>();

        }
    }
}
