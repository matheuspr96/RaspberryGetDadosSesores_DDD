using GetDadosSensores.Domain.Interfaces.IRepository;
using GetDadosSensores.Domain.Interfaces.IService;
using GetDadosSensores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetDadosSensores.Domain.DomainServices
{
    public class ServiceSenChuva : ServiceBase<SensorChuva>, IServiceSenChuva
    {
        private readonly IRepositorySenChuva _iRepositorySenChuva;

        public ServiceSenChuva(IRepositorySenChuva iRepositorySenChuva)
        : base(iRepositorySenChuva)
        {
            _iRepositorySenChuva = iRepositorySenChuva;
        }

        public SensorChuva BuscaDadosSensorChuva()
        {
            return _iRepositorySenChuva.GetDadosSensorChuva();
        }
    }
}
