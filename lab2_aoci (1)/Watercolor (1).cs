using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab2_aoci
{
    public static class Watercolor
    {
        public static Image<Bgr, byte> Wclr(string br, string co, string kk1, string kk2, Image<Bgr, byte> sourceImage, Image<Bgr, byte> sourceImage2)
        {
            var Imag1 = sourceImage.Copy().Resize(320, 240, Inter.Linear);
            var Imag2 = sourceImage2.Copy().Resize(320, 240, Inter.Linear);

            int b = int.Parse(br);
            double c = double.Parse(co);
            double k1 = double.Parse(kk1);
            double k2 = double.Parse(kk2);

            Imag1 = Bright.Brig(b, Imag1).Resize(320, 240, Inter.Linear);
            Imag1 = Contrast.Contr(c, Imag1).Resize(320, 240, Inter.Linear);
            Imag1 = Blur.BlurImg(Imag1).Resize(320, 240, Inter.Linear);
            Imag1 = Add.AddImg(k1, k2, Imag1, Imag2).Resize(320, 240, Inter.Linear);

            return Imag1;
        }
    }
}
