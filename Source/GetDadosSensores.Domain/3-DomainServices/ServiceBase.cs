using GetDadosSensores.Domain.Interfaces.IRepository;
using GetDadosSensores.Domain.Interfaces.IService;


namespace GetDadosSensores.Domain.DomainServices
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }
    }
}
