using GetDadosSensores.Domain.Entities;

namespace GetDadosSensores.Domain.Interfaces.IService
{
    public interface IServiceSenTemperaturaHumidade : IServiceBase<SensorTemperaturaUmidade>
    {
         SensorTemperaturaUmidade BuscaDadosSensorTemperaturaUmidade();
    }
}