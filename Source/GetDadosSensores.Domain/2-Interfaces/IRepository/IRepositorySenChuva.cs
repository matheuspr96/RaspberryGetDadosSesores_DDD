using GetDadosSensores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetDadosSensores.Domain.Interfaces.IRepository
{
    public interface IRepositorySenChuva : IRepositoryBase<SensorChuva>
    {
        SensorChuva GetDadosSensorChuva();
    }
}
