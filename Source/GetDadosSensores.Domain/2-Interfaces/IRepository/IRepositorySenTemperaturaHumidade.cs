using GetDadosSensores.Domain.Interfaces.IRepository;
using GetDadosSensores.Domain.Entities;

namespace GetDadosSensores.Domain.Interfaces.IRepository
{
    public interface IRepositorySenTemperaturaHumidade : IRepositoryBase<SensorTemperaturaUmidade>
    {
         SensorTemperaturaUmidade getDadosSensorTemperaturaUmidade();
    }
}