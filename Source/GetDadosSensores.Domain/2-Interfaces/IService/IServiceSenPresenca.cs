using GetDadosSensores.Domain.Entities;


namespace GetDadosSensores.Domain.Interfaces.IService
{
    public interface IServiceSenPresenca : IServiceBase<SensorPresenca>
    {
        bool buscaDadosSensorPresenca(int time);
    }
}
