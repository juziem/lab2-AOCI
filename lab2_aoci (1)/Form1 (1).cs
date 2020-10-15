using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace lab2_aoci
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> sourceImage; //глобальная переменная
        private Image<Bgr, byte> sourceImage2;
        int i = 0; //переменная канала
        double c = 2; //переменная контрастности
        int b = 2; //переменная яркости
        double k1 = 0.5; //коэффициент прозрачности 1 изображения
        double k2 = 0.5; //коэффициент прозрачности 2 изображения
        int hsv_cnt = 0; //канал hsv

        int a11 = -1;
        int a12 = -1;
        int a13 = -1;

        int a21 = -1;
        int a22 = 9;
        int a23 = -1;

        int a31 = -1;
        int a32 = -1;
        int a33 = -1;

        public Form1()
        {
            InitializeComponent();
        }

        //загрузка изображения
        private void button8_Click(object sender, EventArgs e)
        {
            sourceImage = ImageLoader.LoadImage();
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                imageBox1.Image = sourceImage.Resize(320, 240, Inter.Linear);
        }

        //красный канал
        private void button1_Click(object sender, EventArgs e)
        {
            i = 2;
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                imageBox2.Image = Chanels.Chanel(i, sourceImage).Resize(320, 240, Inter.Linear);
        }

        //зеленый канал
        private void button2_Click(object sender, EventArgs e)
        {
            i = 1;
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                imageBox2.Image = Chanels.Chanel(i, sourceImage).Resize(320, 240, Inter.Linear);
        }

        //синий канал
        private void button3_Click(object sender, EventArgs e)
        {
            i = 0;
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                imageBox2.Image = Chanels.Chanel(i, sourceImage).Resize(320, 240, Inter.Linear); 
        }             

        //чб изображение
        private void button4_Click(object sender, EventArgs e)
        {
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                imageBox2.Image = BandW.BW(sourceImage).Resize(320, 240, Inter.Linear);
        }        

        //сепия
        private void button5_Click(object sender, EventArgs e)
        {
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                imageBox2.Image = Sepia.SepIm(sourceImage).Resize(320, 240, Inter.Linear);
        }

        //контрастность
        private void button6_Click(object sender, EventArgs e)
        {
            
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            { 
                if (double.TryParse(textBox2.Text, out c))
                {
                    if (c >= 0)
                    {
                        imageBox2.Image = Contrast.Contr(c, sourceImage).Resize(320, 240, Inter.Linear);
                        return;
                    }
                }
                MessageBox.Show("Введите коэффициент от 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        //яркость
        private void button7_Click(object sender, EventArgs e)
        {      
            if (!int.TryParse(textBox1.Text, out b))
                b = 1;
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                imageBox2.Image = Bright.Brig(b, sourceImage).Resize(320, 240, Inter.Linear);
        }

        //сложение изображений
        private void button9_Click(object sender, EventArgs e)
        {
            sourceImage2 = ImageLoader.LoadImage();
            if (sourceImage == null || sourceImage2 == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (double.TryParse(textBox6.Text, out k1) && double.TryParse(textBox7.Text, out k2))
                {
                    if ((k1 >= 0 && k1 <= 1) && (k2 >= 0 && k2 <= 1))
                    {
                        imageBox2.Image = Add.AddImg(k1, k2, sourceImage, sourceImage2).Resize(320, 240, Inter.Linear);                        
                        return;
                    }
                }
                MessageBox.Show("Введите коэффициент от 0 до 1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        //умножение изображений
        private void button10_Click(object sender, EventArgs e)
        {
            sourceImage2 = ImageLoader.LoadImage();
            if (sourceImage == null || sourceImage2 == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (double.TryParse(textBox6.Text, out k1) && double.TryParse(textBox7.Text, out k2))
                {
                    if ((k1 >= 0 && k1 <= 1) && (k2 >= 0 && k2 <= 1))
                    {
                        imageBox2.Image = Mult.MultImg(k1, k2, sourceImage, sourceImage2).Resize(320, 240, Inter.Linear);                        
                        return;
                    }
                }
                MessageBox.Show("Введите коэффициент от 0 до 1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //вычитание изображений
        private void button11_Click(object sender, EventArgs e)
        {
            sourceImage2 = ImageLoader.LoadImage();
            if (sourceImage == null || sourceImage2 == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (double.TryParse(textBox6.Text, out k1) && double.TryParse(textBox7.Text, out k2))
                {
                    if ((k1 >= 0 && k1 <= 1) && (k2 >= 0 && k2 <= 1))
                    {
                        imageBox2.Image = Sub.SubImg(k1, k2, sourceImage, sourceImage2).Resize(320, 240, Inter.Linear);
                        return;
                    }
                }
                MessageBox.Show("Введите коэффициент от 0 до 1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        //H из HSV
        private void button12_Click(object sender, EventArgs e)
        {
            hsv_cnt = 0;
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if ((double.Parse(textBox3.Text) >= 0) && (double.Parse(textBox3.Text) <= 255))
                {
                    imageBox2.Image = HSV.HSV_f(hsv_cnt, sourceImage, textBox3.Text).Resize(320, 240, Inter.Linear);
                    return;
                }
                MessageBox.Show("Введите коэффициент от 0 до 255", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //S из HSV
        private void button14_Click(object sender, EventArgs e)
        {
            hsv_cnt = 1;
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if ((double.Parse(textBox4.Text) >= 0) && (double.Parse(textBox4.Text) <= 255))
                {                    
                    imageBox2.Image = HSV.HSV_f(hsv_cnt, sourceImage, textBox4.Text).Resize(320, 240, Inter.Linear);                    
                    return;
                }
                MessageBox.Show("Введите коэффициент от 0 до 255", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //V из HSV
        private void button13_Click(object sender, EventArgs e)
        {
            hsv_cnt = 2;
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if ((double.Parse(textBox5.Text) >= 0) && (double.Parse(textBox5.Text) <= 255))
                {
                    imageBox2.Image = HSV.HSV_f(hsv_cnt, sourceImage, textBox5.Text).Resize(320, 240, Inter.Linear);                    
                    return;
                }
                MessageBox.Show("Введите коэффициент от 0 до 255", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        //медианное размытие
        private void button15_Click(object sender, EventArgs e)
        {
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                imageBox2.Image = Blur.BlurImg(sourceImage).Resize(320, 240, Inter.Linear);
        }

        //оконный фильтр
        private void button16_Click(object sender, EventArgs e)
        {     
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int a11 = int.Parse(textBox12.Text);
                int a12 = int.Parse(textBox13.Text);
                int a13 = int.Parse(textBox14.Text);

                int a21 = int.Parse(textBox15.Text);
                int a22 = int.Parse(textBox16.Text);
                int a23 = int.Parse(textBox17.Text);

                int a31 = int.Parse(textBox18.Text);
                int a32 = int.Parse(textBox19.Text);
                int a33 = int.Parse(textBox20.Text);

                imageBox2.Image = Sharpen.SharpImg(a11, a12, a13, a21, a22, a23, a31, a32, a33, sourceImage).Resize(320, 240, Inter.Linear);
            }
                
        }

        //акварельный фильтр
        private void button17_Click(object sender, EventArgs e)
        {
            sourceImage2 = ImageLoader.LoadImage();
            if (sourceImage == null || sourceImage2 == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if ((double.Parse(textBox9.Text) > 0) && (double.Parse(textBox10.Text) >= 0 && double.Parse(textBox10.Text) <= 1) && (double.Parse(textBox11.Text) >= 0 && double.Parse(textBox11.Text) <= 1) )
                    imageBox2.Image = Watercolor.Wclr(textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, sourceImage, sourceImage2);
                else MessageBox.Show("Введены некорректные значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //cartoon filter
        private void button18_Click(object sender, EventArgs e)
        {
            if (sourceImage == null)
                MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                imageBox2.Image = Cartoon.Ctn(sourceImage).Resize(320, 240, Inter.Linear);
        }
    }
}
