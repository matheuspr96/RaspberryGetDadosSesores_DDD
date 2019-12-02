using System;
using GetDadosSensores.Application.Interface;
using GetDadosSensores.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GetDadosSensoresAPI.Controllers
{
    [ApiController]
    public class SensoresController : ControllerBase
    {
        private readonly IAppServiceSenPresenca _appServiceSenPresenca;
        private readonly IAppServiceSenChuva _appServiceSenChuva;
        private readonly IAppServiceSenTemperaturaUmidade _appServiceSenTemperaturaUmidade;
        public SensoresController(IAppServiceSenPresenca appServiceSenPresenca, IAppServiceSenChuva appServiceSenChuva, IAppServiceSenTemperaturaUmidade appServiceSenTemperaturaUmidade)
        {
            _appServiceSenPresenca = appServiceSenPresenca;
            _appServiceSenChuva = appServiceSenChuva;
            _appServiceSenTemperaturaUmidade = appServiceSenTemperaturaUmidade;
        }

        /// <summary>
        /// Obtém os Dados do Sensor de Presença
        /// </summary>
        /// <param name="time">Tempo de monitoramento em segundos</param>
        /// <returns>bool</returns>
        [HttpGet("GetDadosSensorPresenca")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult GetDadosSensorPresenca(int time)
        {
            try
            {
                var result = _appServiceSenPresenca.AppGetDadosSensorPresenca(time);

                return Ok(result);       
            }
            catch(Exception ex)
            {
               return  BadRequest(ex.Message);
            }       
        }

        /// <summary>
        /// Obtém os dados do Sensor de Chuva
        /// </summary>
        /// <returns>SensorChuva</returns>
        [HttpGet("GetDadosSensorChuva")]
        [ProducesResponseType(typeof(SensorChuva), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult GetDadosSensorChuva()
        {
            try
            {
                var result = _appServiceSenChuva.AppGetDadosSensorChuva();
                return Ok(result);       
            }
            catch(Exception ex)
            {
               return  BadRequest(ex.Message);
            }       
        }

        /// <summary>
        /// Obtém dados do sensor de Temperatura e Umidade (Não implementado)
        /// </summary>
        /// <returns>SensorTemperaturaUmidade</returns>
        [HttpGet("GetDadosSensorTemperaturaUmidade")]
        [ProducesResponseType(typeof(SensorTemperaturaUmidade), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult GetDadosSensorTemperaturaUmidade()
        {
            try
            {
                var result = _appServiceSenTemperaturaUmidade.AppGetDadosSensorTemperaturaUmidade();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
