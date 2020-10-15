using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab2_aoci
{
    public static class Sharpen
    {
        //функция оконного фильтра 
        public static Image<Bgr, byte> SharpImg(int a11, int a12, int a13, int a21, int a22, int a23, int a31, int a32, int a33, Image<Bgr, byte> sourceImage)
        {
            var grayImage = sourceImage.Convert<Bgr, byte>();
            var resImage = grayImage.CopyBlank();

            int[,] w = new int[3, 3]
            {   {a11, a12, a13},
                {a21, a22, a23},
                {a31, a32, a33}};

            for (int ch = 0; ch < 3; ch++)
                for (int y = 1; y < (grayImage.Height - 1); y++)
                    for (int x = 1; x < (grayImage.Width - 1); x++)
                    {
                        int r = 0;
                        for (int i = -1; i < 2; i++)
                            for (int j = -1; j < 2; j++)
                            {
                                r += grayImage.Data[i + y, j + x, ch] * w[i + 1, j + 1];
                            }
                        if (r > 255)
                            r = 255;
                        if (r < 0)
                            r = 0;
                        resImage.Data[y, x, ch] = (byte)r;
                    }
            return resImage;
        }
    }
}
