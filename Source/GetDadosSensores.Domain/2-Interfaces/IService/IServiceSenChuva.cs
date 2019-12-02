using GetDadosSensores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetDadosSensores.Domain.Interfaces.IService
{
    public interface IServiceSenChuva : IServiceBase<SensorChuva>
    {
        SensorChuva BuscaDadosSensorChuva();
    }
}
