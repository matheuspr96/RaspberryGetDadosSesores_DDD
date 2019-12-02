using GetDadosSensores.Application.Interface;
using GetDadosSensores.Domain.Interfaces.IService;
using GetDadosSensores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetDadosSensores.Application
{
    public class AppServiceSenChuva : IAppServiceSenChuva
    {
        private readonly IServiceSenChuva _serviceSenChuva;
        public AppServiceSenChuva(IServiceSenChuva serviceSenChuva) 
        {
            _serviceSenChuva = serviceSenChuva;
        }

        public SensorChuva AppGetDadosSensorChuva()
        {
            return _serviceSenChuva.BuscaDadosSensorChuva();
        }
    }
}
