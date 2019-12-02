using GetDadosSensores.Domain.Interfaces.IRepository;
using GetDadosSensores.Domain.Interfaces.IService;
using GetDadosSensores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetDadosSensores.Domain.DomainServices
{
    public class ServiceSenPresenca : ServiceBase<SensorPresenca>, IServiceSenPresenca
    {
        private readonly IRepositorySenPresenca _repositorySenPresenca;

        public ServiceSenPresenca(IRepositorySenPresenca repositorySenPresenca)
        : base(repositorySenPresenca)
        {   
            _repositorySenPresenca = repositorySenPresenca;
        }

        public bool buscaDadosSensorPresenca(int time)
        {
            return _repositorySenPresenca.GetDadosSensorPresenca(time);
        }
    }
}
