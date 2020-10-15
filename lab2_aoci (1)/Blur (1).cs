using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab2_aoci
{
    public static class Blur
    {
        //функция медианного размытия изображения
        public static Image<Bgr, byte> BlurImg(Image<Bgr, byte> sourceImage)
        {
            var grayImage = sourceImage.Convert<Bgr, byte>();
            var resImage = grayImage.CopyBlank();

            List<byte> l = new List<byte>();
            int sh = 4;
            int N = 9;

            for (int ch = 0; ch < 3; ch++)
                for (int y = sh; y < (grayImage.Height - sh); y++)
                    for (int x = sh; x < (grayImage.Width - sh); x++)
                    {
                        l.Clear();

                        for (int i = -1; i < 2; i++)
                            for (int j = -1; j < 2; j++)
                            {
                                l.Add(grayImage.Data[i + y, j + x, ch]);
                            }
                        l.Sort();
                        resImage.Data[y, x, ch] = l[N / 2];
                    }
            return resImage;
        }
    }
}
