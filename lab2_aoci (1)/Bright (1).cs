using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab2_aoci
{
    public static class Bright
    {
        //функция вывода яркого изображения
        public static Image<Bgr, byte> Brig(int b, Image<Bgr, byte> sourceImage)
        {
            var BrightImage = sourceImage.Copy();

            for (int ch = 0; ch < 3; ch++)
                for (int y = 0; y < BrightImage.Height; y++)
                    for (int x = 0; x < BrightImage.Width; x++)
                    {
                        if ((BrightImage.Data[y, x, ch] + b) > 255)
                            BrightImage.Data[y, x, ch] = 255;
                        else if ((BrightImage.Data[y, x, ch] + b) < 0)
                            BrightImage.Data[y, x, ch] = 0;
                        else
                            BrightImage.Data[y, x, ch] = Convert.ToByte(BrightImage.Data[y, x, ch] + b);
                    }
            return BrightImage;
        }
    }
}
