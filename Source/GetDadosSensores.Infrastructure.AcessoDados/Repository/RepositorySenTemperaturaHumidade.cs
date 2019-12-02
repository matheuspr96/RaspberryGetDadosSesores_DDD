using GetDadosSensores.Domain.Interfaces.IRepository;
using Unosquare.RaspberryIO;
using System;
using Unosquare.RaspberryIO.Abstractions;
using System.Device.Gpio;
using System.Collections.Generic;
using System.IO;
using GetDadosSensores.Domain.Entities;
using static CrossCutting.Util;
using System.Threading;

namespace AcessoDados.Repository
{
    public class RepositorySenTemperaturaHumidade : IRepositorySenTemperaturaHumidade
    {
        private UInt32[] _data;
        private int _dataPin;
        private bool _firstReading;
        private DateTime _prevReading;
        private DHTSensorTypes _sensorType;
        GpioController _controller;

        //Inicializa serviço
        public RepositorySenTemperaturaHumidade()
        {
            _dataPin = 7;

            _controller = new GpioController();
            _controller.OpenPin(_dataPin, PinMode.Output);

            _firstReading = true;
            _prevReading = DateTime.MinValue;
            _data = new UInt32[6];
            _sensorType = DHTSensorTypes.DHT22;

            _controller.Write(_dataPin, PinValue.High);
        }

        public SensorTemperaturaUmidade ReadData()
        {
            float t = 0;
            float h = 0;
            try
            {
                if (Read())
                {
                    switch (_sensorType)
                    {
                        case DHTSensorTypes.DHT11:
                            t = _data[2];
                            h = _data[0];
                            break;
                        case DHTSensorTypes.DHT22:
                        case DHTSensorTypes.DHT21:
                            t = _data[2] & 0x7F;
                            t *= 256;
                            t += _data[3];
                            t /= 10;
                            if ((_data[2] & 0x80) != 0)
                            {
                                t *= -1;
                            }
                            h = _data[0];
                            h *= 256;
                            h += _data[1];
                            h /= 10;
                            break;
                    }

                    return new SensorTemperaturaUmidade()
                    {
                        TempCelcius = t,
                        //TempFahrenheit = ConvertCtoF(t),
                        Humidity = h,
                        //HeatIndex = ComputeHeatIndex(t, h, false)       
                    };
                }
                else
                {
                    throw new Exception("Não foi possivel ler o sensor");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        private bool Read()
        {
            var now = DateTime.UtcNow;

            if (!_firstReading && ((now - _prevReading).TotalMilliseconds < 2000))
            {
                return false;
            }

            _firstReading = false;
            _prevReading = now; ;

            _data[0] = _data[1] = _data[2] = _data[3] = _data[4] = 0;

            _controller.SetPinMode(_dataPin, PinMode.Output);

            _controller.Write(_dataPin, PinValue.High);

            Thread.Sleep(250);

            _controller.Write(_dataPin, PinValue.Low);

            Thread.Sleep(20);

            //TIME CRITICAL ###############
            _controller.Write(_dataPin, PinValue.High);
            //=> DELAY OF 40 microseconds needed here
            WaitMicroseconds(40);

            _controller.SetPinMode(_dataPin, PinMode.Input);
            //Delay of 10 microseconds needed here
            WaitMicroseconds(10);

            if (ExpectPulse(PinValue.Low) == 0)
            {
                return false;
            }
            if (ExpectPulse(PinValue.High) == 0)
            {
                return false;
            }

            // Now read the 40 bits sent by the sensor.  Each bit is sent as a 50
            // microsecond low pulse followed by a variable length high pulse.  If the
            // high pulse is ~28 microseconds then it's a 0 and if it's ~70 microseconds
            // then it's a 1.  We measure the cycle count of the initial 50us low pulse
            // and use that to compare to the cycle count of the high pulse to determine
            // if the bit is a 0 (high state cycle count < low state cycle count), or a
            // 1 (high state cycle count > low state cycle count).
            for (int i = 0; i < 40; ++i)
            {
                UInt32 lowCycles = ExpectPulse(PinValue.Low);
                if (lowCycles == 0)
                {
                    return false;
                }
                UInt32 highCycles = ExpectPulse(PinValue.High);
                if (highCycles == 0)
                {
                    return false;
                }
                _data[i / 8] <<= 1;
                // Now compare the low and high cycle times to see if the bit is a 0 or 1.
                if (highCycles > lowCycles)
                {
                    // High cycles are greater than 50us low cycle count, must be a 1.
                    _data[i / 8] |= 1;
                }
                // Else high cycles are less than (or equal to, a weird case) the 50us low
                // cycle count so this must be a zero.  Nothing needs to be changed in the
                // stored data.
            }
            //TIME CRITICAL_END #############

            // Check we read 40 bits and that the checksum matches.
            if (_data[4] == ((_data[0] + _data[1] + _data[2] + _data[3]) & 0xFF))
            {
                return true;
            }
            else
            {
                //Checksum failure!
                return false;
            }
        }

        private UInt32 ExpectPulse(PinValue level)
        {
            UInt32 count = 0;

            while (_controller.Read(_dataPin) == (level == PinValue.High))
            {
                count++;
                //WaitMicroseconds(1);
                if (count == 10000)
                {
                    return 0;
                }
            }
            return count;
        }

        private void WaitMicroseconds(int microseconds)
        {
            var until = DateTime.UtcNow.Ticks + (microseconds * 10);
            while (DateTime.UtcNow.Ticks < until) { }
        }

        public SensorTemperaturaUmidade getDadosSensorTemperaturaUmidade()
        {
            return ReadData();
        }
    }
}
