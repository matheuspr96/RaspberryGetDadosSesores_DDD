using GetDadosSensores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetDadosSensores.Application.Interface
{
    public interface IAppServiceSenChuva : IAppServiceBase<SensorChuva>
    {
        SensorChuva AppGetDadosSensorChuva();
    }
}
