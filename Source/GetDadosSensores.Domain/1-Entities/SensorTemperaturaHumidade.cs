using GetDadosSensores.Domain.Interfaces.IRepository;

namespace GetDadosSensores.Domain.Entities
{
    public class SensorTemperaturaUmidade
    {
        /// <summary>
        /// Temperatura em graus Celcius
        /// </summary>
        public float TempCelcius {get; set;}
        /// <summary>
        /// Temperatura em graus Fahrenheit
        /// </summary>
        public float TempFahrenheit {get; set;}
        /// <summary>
        /// Humidade relativa do ar
        /// </summary>
        public float Humidity {get; set;}
        /// <summary>
        /// HeatIndex
        /// </summary>
        public double HeatIndex {get;set;}  
    }
}