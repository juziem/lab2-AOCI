using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab2_aoci
{
    public static class Contrast
    {
        //функция вывода контрастного изображения
        public static Image<Bgr, byte> Contr(double c, Image<Bgr, byte> sourceImage)
        {
            var ContrastImage = sourceImage.Copy();            

            for (int ch = 0; ch < 3; ch++)
                for (int y = 0; y < ContrastImage.Height; y++)
                    for (int x = 0; x < ContrastImage.Width; x++)
                    {
                        if ((ContrastImage.Data[y, x, ch] * c) > 255)
                            ContrastImage.Data[y, x, ch] = 255;
                        else
                            ContrastImage.Data[y, x, ch] = Convert.ToByte(ContrastImage.Data[y, x, ch] * c);
                    }
            return ContrastImage;
        }
    }
}
