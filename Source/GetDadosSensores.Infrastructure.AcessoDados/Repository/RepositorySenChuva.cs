using GetDadosSensores.Domain.Interfaces.IRepository;
using GetDadosSensores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Text;
using System.Threading;

namespace AcessoDados.Repository
{
    public class RepositorySenChuva : IRepositorySenChuva
    {
        /// <summary>
        /// Servico encarregado de pegar os dados do sensor
        /// </summary>
        /// <returns>SensorChuva</returns>
        public SensorChuva GetDadosSensorChuva()
        {
            var pin = 26;
            var pinRain = 17;
            GpioController controller = new GpioController();

            try
            {
                //Inicia o Led saída,
                controller.OpenPin(pin, PinMode.Output);
                controller.OpenPin(pinRain, PinMode.Input);          

                if (!controller.IsPinOpen(pinRain))
                {
                    throw new Exception($"Pino {pinRain} não aberto");
                }

                while (true)
                {
                    var resultPinRain = controller.Read(pinRain);
                   
                    if (!resultPinRain.Equals(PinValue.High))
                    {
                        Console.WriteLine($"Foi detectado chuva - {resultPinRain}");
                        controller.Write(pin, PinValue.High);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine($"Não foi detectadoo chuva - {resultPinRain} ");
                        controller.Write(pin, PinValue.Low);
                        Thread.Sleep(2000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                controller.Dispose();
            }
        }
    }
}
