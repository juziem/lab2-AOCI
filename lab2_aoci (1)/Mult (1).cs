using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab2_aoci
{
    public static class Mult
    {
        //функция вывода умножения изображений
        public static Image<Bgr, byte> MultImg(double k1, double k2, Image<Bgr, byte> sourceImage, Image<Bgr, byte> sourceImage2)
        {
            var Imag1 = sourceImage.Copy().Resize(320, 240, Inter.Linear);
            var Imag2 = sourceImage2.Copy().Resize(320, 240, Inter.Linear);

            for (int ch = 0; ch < 3; ch++)
                for (int y = 0; y < Imag1.Height; y++)
                    for (int x = 0; x < Imag1.Width; x++)
                    {
                        if ((Imag1.Data[y, x, ch] * k1 * Imag2.Data[y, x, ch] * k2) > 255)
                            Imag1.Data[y, x, ch] = 255;
                        else if ((Imag1.Data[y, x, ch] * k1 * Imag2.Data[y, x, ch] * k2) < 0)
                            Imag1.Data[y, x, ch] = 0;
                        else
                            Imag1.Data[y, x, ch] = Convert.ToByte(Imag1.Data[y, x, ch] * k1 * Imag2.Data[y, x, ch] * k2);
                    }
            return Imag1;
        }
    }
}
