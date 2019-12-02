using GetDadosSensores.Domain.Interfaces.IRepository;
using Unosquare.RaspberryIO;
using System;
using Unosquare.RaspberryIO.Abstractions;
using System.Device.Gpio;
using System.Collections.Generic;
using System.IO;

namespace AcessoDados.Repository
{
    public class RepositorySenPresenca : IRepositorySenPresenca
    {
        public bool GetDadosSensorPresenca(int time)
        {
            // Declare use pins
            var pin = 17;
            var pinLed = 26;
                
            GpioController controller = new GpioController();
            
            // open conetion of Input and Output
            controller.OpenPin(pin, PinMode.Input);
            controller.OpenPin(pinLed, PinMode.Output);


            //turn on output led - checkout
            controller.Write(pinLed, PinValue.High);
            System.Threading.Thread.Sleep(300);
            controller.Write(pinLed, PinValue.Low);
            
            // Monitoring an ambient for 5 secons and returning  if there was movement
            try
            {
                int controle = 0;
                List<bool> ListMovimento = new List<bool>();
                for (var i = 0; i < time; i++)
                {
                    // inity 
                    controller.Write(pinLed, PinValue.Low);
                    bool movimento = false;
                    PinValue result = controller.Read(pin);
                  
                    if (result == PinValue.High)
                    {
                        movimento = true;
                        ListMovimento.Add(movimento);
                        CaptureImage(controle++);
                        controller.Write(pinLed, PinValue.High);
                        System.Threading.Thread.Sleep(800);
                        controller.Write(pinLed, PinValue.Low);
                    }
                    System.Threading.Thread.Sleep(1000);
                }

                // check the list and return if there was movement
                bool rsult = ListMovimento.Contains(true);
                
                // Return result;
                return rsult;
            }
            catch (Exception ex)
            {
                throw new Exception("Repository - Erro ao obter dados do sensor de presenca: " + ex.Message);
            }
        }

        static void CaptureImage(int controle)
        {
            var pictureBytes = Pi.Camera.CaptureImageJpeg(640, 480);
            var targetPath = $"/home/pi/cookie/picture{controle}.jpg";
            if (File.Exists(targetPath))
                File.Delete(targetPath);

            File.WriteAllBytes(targetPath, pictureBytes);
            Console.WriteLine($"Took picture -- Byte count: {pictureBytes.Length}");
        }
    }
}
