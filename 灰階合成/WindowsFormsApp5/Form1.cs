using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        Bitmap myBitmap;
        Bitmap myBitmap2;
        int Height;
        int Weight;
        int graynum;
        public Form1()
        {
            InitializeComponent();           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "PNG影象(*.png)|*.png|所有檔案(*.*)|*.*";
            of.FilterIndex = 0;
            of.ShowDialog();
            String filename = of.FileName.ToString();

            //在此處載入一個新的圖片。
            myBitmap = new Bitmap(filename);
            // Stretches the image to fit the pictureBox.

            Bitmap myImage = this.myBitmap;//new Bitmap(fileToDisplay);
                                           //pictureBox1.ClientSize = new Size(xSize, ySize);
            pictureBox1.Image = (Image)myImage;
            //設定當前窗體與圖片大小相當

            /*
            Color pixelColor = this.myBitmap.GetPixel(e.X, e.Y);
            pixelColor = Color.FromArgb(255,0,0);//可以以此方法對COLOR變數進行RGB值設定。
            textBox1.Text = pixelColor.R.ToString();
            textBox2.Text = pixelColor.G.ToString();
            textBox3.Text = pixelColor.B.ToString();
            */
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog off = new OpenFileDialog();
            off.Filter = "PNG影象(*.png)|*.png|所有檔案(*.*)|*.*";
            off.FilterIndex = 0;
            off.ShowDialog();
            String filename1 = off.FileName.ToString();

            //在此處載入一個新的圖片。
            myBitmap2 = new Bitmap(filename1);
            // Stretches the image to fit the pictureBox.

            Bitmap myImage1 = this.myBitmap2;//new Bitmap(fileToDisplay);
                                           //pictureBox1.ClientSize = new Size(xSize, ySize);
            pictureBox2.Image = (Image)myImage1;
            //設定當前窗體與圖片大小相當
            
            


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255, 255);
            Color gray1 = Color.FromArgb(255, graynum, graynum, graynum);
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Weight; j++)
                {
                    Color pixelColor = myBitmap.GetPixel(i, j);
                    Color pixelColor2 = myBitmap2.GetPixel(i, j);
                    if (pixelColor2.ToArgb() == White.ToArgb())
                    {
                        myBitmap.SetPixel(i, j, gray1);
                    }
                }
            }
            Bitmap myImage = this.myBitmap;
            pictureBox1.Image = (Image)myImage;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Height = Convert.ToInt32(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Weight = Convert.ToInt32(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            graynum = Convert.ToInt32(textBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Png Image(*.png)|*.png|所有檔案(*.*)|*.*";
                saveFileDialog1.Title = "儲存圖片";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            this.pictureBox1.Image.Save(fs,
                                      System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
