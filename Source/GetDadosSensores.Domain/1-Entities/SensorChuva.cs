using System;
using System.Collections.Generic;
using System.Text;

namespace GetDadosSensores.Domain.Entities
{
    public class SensorChuva
    {
        /// <summary>
        /// Detecta se está chovendo
        /// </summary>
        public bool chuva { get; set; }
        /// <summary>
        /// Intensidade registrada
        /// </summary>
        public string intensidade { get; set; }

    }
}
