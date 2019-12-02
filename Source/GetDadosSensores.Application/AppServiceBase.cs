using GetDadosSensores.Application.Interface;
using GetDadosSensores.Domain.Interfaces.IService;

namespace GetDadosSensores.Application
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;

        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }
    }

}