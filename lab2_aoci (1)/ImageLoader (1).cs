using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace lab2_aoci
{
    public static class ImageLoader
    {
        //Функция загрузки изображения
        public static Image<Bgr, byte> LoadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog(); // открытие диалога выбора файла
            if (result == DialogResult.OK) // открытие выбранного файла
            {
                string fileName = openFileDialog.FileName;
                return new Image<Bgr, byte>(fileName);
            }
            return null;
        }
    }
}
