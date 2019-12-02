using System;
using System.Collections.Generic;
using System.Text;

namespace GetDadosSensores.Domain.Entities
{
    public class SensorPresenca
    {
        /// <summary>
        /// Output: Digital pulse high (3V) when triggered (motion detected) digital low when idle (no motion detected)
        /// Sensitivity range: up to 20 feet (6 meters) 110° x 70° detection range
        /// </summary>
        public bool DetectPresence { get; set; }
    }
}
