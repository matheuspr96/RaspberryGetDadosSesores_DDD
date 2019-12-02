using GetDadosSensores.Domain.Entities;

namespace GetDadosSensores.Domain.Interfaces.IRepository
{
    public interface IRepositorySenPresenca : IRepositoryBase<SensorPresenca>
    {
        bool GetDadosSensorPresenca(int time);
    }
}
