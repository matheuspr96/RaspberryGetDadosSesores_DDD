using GetDadosSensores.Application.Interface;
using GetDadosSensores.Domain.Entities;
using GetDadosSensores.Domain.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetDadosSensores.Application
{
    public class AppServiceSenTemperaturaUmidade : IAppServiceSenTemperaturaUmidade
    {
        IServiceSenTemperaturaHumidade _serviceSenTemperaturaUmidade;
        public AppServiceSenTemperaturaUmidade(IServiceSenTemperaturaHumidade serviceSenTemperaturaUmidade)
        {
            _serviceSenTemperaturaUmidade = serviceSenTemperaturaUmidade;
        }
        public SensorTemperaturaUmidade AppGetDadosSensorTemperaturaUmidade()
        {
            try
            {
                SensorTemperaturaUmidade dadosSenTemUmi = _serviceSenTemperaturaUmidade.BuscaDadosSensorTemperaturaUmidade();
                if (dadosSenTemUmi.TempCelcius > 60 || dadosSenTemUmi.TempCelcius < 10)
                {
                    throw new Exception("Verificar Sensor. Foi registrado uma temperatura fora do normal");

                }else if(dadosSenTemUmi.Humidity > 100)
                {
                    throw new Exception("Verificar Sensor. Foi registrado uma Umidade fora do normal");

                }
                else
                {
                    return dadosSenTemUmi;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
      
        }
    }
}
