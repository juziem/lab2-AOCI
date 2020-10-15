using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab2_aoci
{
    public static class Cartoon
    {
        public static Image<Bgr, byte> Ctn(Image<Bgr, byte> sourceImage)
        {
            var Imag1 = sourceImage.Copy().Resize(320, 240, Inter.Linear);
            var Imag2 = Imag1;
            double k = 1;

            Imag1 = BandW.BW(Imag1).Resize(320, 240, Inter.Linear).Convert<Bgr, byte>();
            Imag1 = Blur.BlurImg(Imag1).Resize(320, 240, Inter.Linear);

            var edges = Imag1.Convert<Gray, byte>();
            edges = edges.ThresholdAdaptive(new Gray(100), AdaptiveThresholdType.MeanC, ThresholdType.Binary, 3, new Gray(0.03));

            Imag1 = Add.AddImg(k, k, Imag2, edges.Convert<Bgr, byte>()).Resize(320, 240, Inter.Linear);

            return Imag1;
        }
    }
}
