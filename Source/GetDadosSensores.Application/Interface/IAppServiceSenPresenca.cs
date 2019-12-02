using GetDadosSensores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetDadosSensores.Application.Interface
{
    public interface IAppServiceSenPresenca : IAppServiceBase<SensorPresenca>
    {
        bool AppGetDadosSensorPresenca(int time);
    }
}
