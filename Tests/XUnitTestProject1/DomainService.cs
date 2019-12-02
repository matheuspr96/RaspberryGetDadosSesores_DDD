using GetDadosSensores.Domain.DomainServices;
using GetDadosSensores.Domain.Entities;
using GetDadosSensores.Domain.Interfaces.IRepository;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class DomainService
    {
        private Mock<IRepositorySenPresenca> _repositorySenPresenca;
        private Mock<IRepositorySenChuva> _repositorySenChuva;
        private Mock<IRepositorySenTemperaturaHumidade> _repositorySentemoUmd;
        public DomainService()
        {
            _repositorySenPresenca = new Mock<IRepositorySenPresenca>();
            _repositorySenChuva = new Mock<IRepositorySenChuva>();
            _repositorySentemoUmd = new Mock<IRepositorySenTemperaturaHumidade>();
        }

        #region TestSensorPresenca

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(10)]
        [InlineData(120)]
        public void TestDomainService_accept(int time)
        {        
            _repositorySenPresenca.Setup(x => x.GetDadosSensorPresenca(time)).Returns(true);

            ServiceSenPresenca svcSenPresenca = new ServiceSenPresenca(_repositorySenPresenca.Object);
            var result = svcSenPresenca.buscaDadosSensorPresenca(time);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(10)]
        [InlineData(120)]
        public void TestDomainService_fail(int time)
        {
            _repositorySenPresenca.Setup(x => x.GetDadosSensorPresenca(time)).Returns(true);

            ServiceSenPresenca svcSenPresenca = new ServiceSenPresenca(_repositorySenPresenca.Object);
            var result = svcSenPresenca.buscaDadosSensorPresenca(time+1);

            Assert.IsType<bool>(result);
            Assert.False(result);
        }

        #endregion


        #region TestSensorChuva

        [Theory]
        [InlineData(true, "300")]
        [InlineData(false, "500")]
        [InlineData(true, "1000")]
        [InlineData(false, "50")]
        public void TestDomainServiceSenChuva_accept(bool g_chuva, string g_intensidade)
        {
            SensorChuva dadosSensorChuva = new SensorChuva()
            {
                chuva = g_chuva,
                intensidade = g_intensidade
            };
         
            _repositorySenChuva.Setup(x => x.GetDadosSensorChuva()).Returns(dadosSensorChuva);

            ServiceSenChuva svcSenChuva = new ServiceSenChuva(_repositorySenChuva.Object);
            var result = svcSenChuva.BuscaDadosSensorChuva();

            Assert.IsType<SensorChuva>(result);
            Assert.Equal(JsonConvert.SerializeObject(result) ,JsonConvert.SerializeObject(dadosSensorChuva));
        }

        [Theory]
        [InlineData(true, "300")]
        [InlineData(false, "500")]
        [InlineData(true, "1000")]
        [InlineData(false, "50")]
        public void TestDomainServiceSenChuva_fail(bool g_chuva, string g_intensidade)
        {
            SensorChuva dadosSensorChuva = new SensorChuva()
            {
                chuva = g_chuva,
                intensidade = g_intensidade + "1"
            };

            _repositorySenChuva.Setup(x => x.GetDadosSensorChuva()).Returns(dadosSensorChuva);

            ServiceSenChuva svcSenChuva = new ServiceSenChuva(_repositorySenChuva.Object);
            var result = svcSenChuva.BuscaDadosSensorChuva();

            Assert.IsType<SensorChuva>(result);
            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(dadosSensorChuva));
        }

        #endregion

        #region TestSensorTemperaturaUmidade

        [Theory]
        [InlineData(35.5, 20.0)]
        [InlineData(20.5, 45.0)]
        [InlineData(0.5, 40.0)]
        public void TestDomainServiceSenTemUmd_accept(float g_temp, float g_umid)
        {
            SensorTemperaturaUmidade dadosSensorTemUmd = new SensorTemperaturaUmidade()
            {
                TempCelcius = g_temp,
                Humidity = g_umid
            };

            _repositorySentemoUmd.Setup(x => x.getDadosSensorTemperaturaUmidade()).Returns(dadosSensorTemUmd);

            ServiceSenTemperaturaHumidade svcSentempum = new ServiceSenTemperaturaHumidade(_repositorySentemoUmd.Object);
            var result = svcSentempum.BuscaDadosSensorTemperaturaUmidade();

            Assert.IsType<SensorTemperaturaUmidade>(result);
            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(dadosSensorTemUmd));
        }

        [Theory]
        [InlineData(35.5, 20.0)]
        [InlineData(20.5, 45.0)]
        [InlineData(0.5, 40.0)]
        public void TestDomainServiceSenTemUmd_fail(float g_temp, float g_umid)
        {
            SensorTemperaturaUmidade dadosSensorTemUmd = new SensorTemperaturaUmidade()
            {
                TempCelcius = g_temp + 1,
                Humidity = g_umid
            };

            _repositorySentemoUmd.Setup(x => x.getDadosSensorTemperaturaUmidade()).Returns(dadosSensorTemUmd);

            ServiceSenTemperaturaHumidade svcSentempum = new ServiceSenTemperaturaHumidade(_repositorySentemoUmd.Object);
            var result = svcSentempum.BuscaDadosSensorTemperaturaUmidade();

            Assert.IsType<SensorTemperaturaUmidade>(result);
            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(dadosSensorTemUmd));
        }

        #endregion


    }
}
