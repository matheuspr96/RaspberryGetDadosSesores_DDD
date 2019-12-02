using GetDadosSensores.Domain.DomainServices;
using GetDadosSensores.Domain.Entities;
using GetDadosSensores.Domain.Interfaces.IRepository;
using GetDadosSensores.Domain.Interfaces.IService;

namespace GetDadosSensores.Domain.DomainServices
{
    public class ServiceSenTemperaturaHumidade : ServiceBase<SensorTemperaturaUmidade>, IServiceSenTemperaturaHumidade
    {
        private readonly IRepositorySenTemperaturaHumidade _repositorySenTemperaturaHumidade;
        public ServiceSenTemperaturaHumidade(IRepositorySenTemperaturaHumidade repositorySenTemperaturaHumidade)
        : base(repositorySenTemperaturaHumidade)
        {
            _repositorySenTemperaturaHumidade = repositorySenTemperaturaHumidade;
        }
        public SensorTemperaturaUmidade BuscaDadosSensorTemperaturaUmidade()
        {
            return _repositorySenTemperaturaHumidade.getDadosSensorTemperaturaUmidade();
        }
    }
}