using System;

namespace CrossCutting
{
    public class Util
    {
        //static void CaptureImage(int controle)
        //{
        //    var pictureBytes = Pi.Camera.CaptureImageJpeg(640, 480);
        //    var targetPath = $"/home/pi/cookie/picture{controle}.jpg";
        //    if (File.Exists(targetPath))
        //        File.Delete(targetPath);

        //    File.WriteAllBytes(targetPath, pictureBytes);
        //    Console.WriteLine($"Took picture -- Byte count: {pictureBytes.Length}");
        //}
        public enum DHTSensorTypes 
        {
            DHT11,
            DHT21,
            DHT22
        }

    }
}
