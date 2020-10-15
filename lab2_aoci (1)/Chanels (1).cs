using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab2_aoci
{
    public static class Chanels
    {
        //Функция вывода значения канала
        public static Image<Bgr, byte> Chanel(int i, Image<Bgr, byte> sourceImage)
        {
            var channel = sourceImage.Split()[i];
            Image<Bgr, byte> destImage = sourceImage.CopyBlank();

            VectorOfMat vm = new VectorOfMat();
            if (i == 0)
            {
                vm.Push(channel);
                vm.Push(channel.CopyBlank());
                vm.Push(channel.CopyBlank());
            }
            if (i == 1)
            {
                vm.Push(channel.CopyBlank());
                vm.Push(channel);
                vm.Push(channel.CopyBlank());
            }
            if (i == 2)
            {
                vm.Push(channel.CopyBlank());
                vm.Push(channel.CopyBlank());
                vm.Push(channel);
            }
            CvInvoke.Merge(vm, destImage);

            return destImage;
        }
    }
}
