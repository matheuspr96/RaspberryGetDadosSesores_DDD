using GetDadosSensores.Application.Interface;
using GetDadosSensores.Domain.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetDadosSensores.Application
{
    public class AppServiceSenPresenca : IAppServiceSenPresenca
    {
        private readonly IServiceSenPresenca _serviceSenPrenca; 

        public AppServiceSenPresenca(IServiceSenPresenca serviceSenPrenca)
        {
            _serviceSenPrenca = serviceSenPrenca;
        }

        public bool AppGetDadosSensorPresenca(int time)
        {
           return _serviceSenPrenca.buscaDadosSensorPresenca(time);
        }
    }
}
