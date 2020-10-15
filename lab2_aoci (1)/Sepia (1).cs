using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab2_aoci
{
    public static class Sepia
    {
        //функция вывода изображения в сепии
        public static Image<Bgr, byte> SepIm (Image<Bgr, byte> sourceImage)
        {
            var SepImage = sourceImage.Copy();

            for (int y = 0; y < SepImage.Height; y++)
                for (int x = 0; x < SepImage.Width; x++)
                {
                    if ((0.393 * sourceImage.Data[y, x, 2] + 0.769 * sourceImage.Data[y, x, 1] + 0.189 * sourceImage.Data[y, x, 0]) > 255)
                        SepImage.Data[y, x, 2] = 255;
                    else
                        SepImage.Data[y, x, 2] = Convert.ToByte(0.393 * sourceImage.Data[y, x, 2] + 0.769 * sourceImage.Data[y, x, 1] + 0.189 * sourceImage.Data[y, x, 0]);

                    if ((0.349 * sourceImage.Data[y, x, 2] + 0.686 * sourceImage.Data[y, x, 1] + 0.168 * sourceImage.Data[y, x, 0]) > 255)
                        SepImage.Data[y, x, 1] = 255;
                    else
                        SepImage.Data[y, x, 1] = Convert.ToByte(0.349 * sourceImage.Data[y, x, 2] + 0.686 * sourceImage.Data[y, x, 1] + 0.168 * sourceImage.Data[y, x, 0]);

                    if ((0.272 * sourceImage.Data[y, x, 2] + 0.534 * sourceImage.Data[y, x, 1] + 0.131 * sourceImage.Data[y, x, 0]) > 255)
                        SepImage.Data[y, x, 0] = 255;
                    else
                        SepImage.Data[y, x, 0] = Convert.ToByte(0.272 * sourceImage.Data[y, x, 2] + 0.534 * sourceImage.Data[y, x, 1] + 0.131 * sourceImage.Data[y, x, 0]);
                }
            return SepImage;
        }
    }
}
