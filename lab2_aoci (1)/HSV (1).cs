using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace lab2_aoci
{
    public static class HSV
    {
        //функция вывода HSV
        public static Image<Hsv, byte> HSV_f(int hsv_cnt, Image<Bgr, byte> sourceImage, string hsv)
        {
            var hsvImage = sourceImage.Convert<Hsv, byte>();

            for (int y = 0; y < hsvImage.Height; y++)
                for (int x = 0; x < hsvImage.Width; x++)
                {
                    if (!string.IsNullOrEmpty(hsv)) hsvImage.Data[y, x, hsv_cnt] = Convert.ToByte(double.Parse(hsv));                        
                    else hsvImage.Data[y, x, hsv_cnt] = 100;
                }
            return hsvImage;
        }
    }
}
