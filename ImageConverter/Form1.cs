using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace ImageConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image m_Image = null;


        private void button_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog sd = new OpenFileDialog();
            sd.RestoreDirectory = true;
            sd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                
                string s = sd.FileName;
                m_Image = Image.FromFile(s);
                Bitmap b = (Bitmap)m_Image;
                ChangeColor(ref b);
                pictureBox.Image = m_Image;
                    
            }
        }

        public static void ChangeColor(ref Bitmap scrBitmap)
        {

            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    Color c = scrBitmap.GetPixel(i, j);
                    Color2Hsv(c, out double h, out double s, out double v);
                    scrBitmap.SetPixel(i, j, Hsv2Color((float)h, (float)s, (float)v));

                }

            }
        }




       static  Color Hsv2Color(float h, float s, float v)
        {
            ColorConverter.Hsv2Rgb(h, s, v, out int r, out int g, out int b);
            return Color.FromArgb(r, g, b);
        }

        public static void Color2Hsv(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }





    }
}
