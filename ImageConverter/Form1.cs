using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KMeans;
using ImageReader;

namespace ImageConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image m_Image = null;
        BitmapRGB m_Bitmap;

        private void button_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog sd = new OpenFileDialog();
            sd.RestoreDirectory = true;
            sd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                
                string s = sd.FileName;
                m_Bitmap = BitmapRGB.FromFile(s);
                ChangeColor(ref m_Bitmap);
                m_Image = Bitmap2Image(m_Bitmap);
                //Bitmap b = (Bitmap)m_Image;
                //ChangeColor(ref b);
                 pictureBox.Image = m_Image;                 
            }
        }
        
        Image Bitmap2Image(BitmapRGB bitmap)
        {
            Bitmap img = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for(int i = 0; i < bitmap.Pixels.Length; ++i)
            {
                int x = i % bitmap.Width;
                int y = i / bitmap.Width;
                Color c = Color.FromArgb(bitmap.Pixels[i].R, bitmap.Pixels[i].G, bitmap.Pixels[i].B);
                img.SetPixel(x, y, c);
            }
            return img;
        }


        public static void ChangeColor(ref BitmapRGB scrBitmap)
        {
            List<PixelData> pixels = new List<PixelData>(scrBitmap.Width * scrBitmap.Height);

            for(int i = 0; i <  scrBitmap.Pixels.Length;++i)
            {
                Color2Hsv(ref scrBitmap.Pixels[i], out double h, out double s, out double v);
                scrBitmap.Pixels[i] = Hsv2Color((float)h, (float)s, (float)v);
                PixelRGB c = scrBitmap.Pixels[i];
                pixels.Add(new PixelData( (double)c.R / 255d, (double)c.G / 255d, (double)c.B / 255d));
            }


            KMeansClustering cl = new KMeansClustering(pixels.ToArray(), 3);
            Cluster[] clusters = cl.Compute();
            for (int i = 0; i < clusters.Length; ++i)
            {
                Cluster c = clusters[i];
                for (int j = 0; j < c.Points.Count; ++j)
                {
                    ((PixelData)c.Points[j]).SetRGB(c.Centroid.Components[0], c.Centroid.Components[1], c.Centroid.Components[2]);
                }

            }

            for (int i = 0; i < pixels.Count; ++i)
            {
                scrBitmap.Pixels[i] = new PixelRGB((byte)(pixels[i].Components[0] * 255d), (byte)(pixels[i].Components[1] * 255d),
                    (byte)(pixels[i].Components[2] * 255d));
            }
        }




       static  PixelRGB Hsv2Color(float h, float s, float v)
        {
            ColorConverter.Hsv2Rgb(h, s, v, out int r, out int g, out int b);
            return new PixelRGB((byte)r, (byte)g, (byte)b);
        }

        public static void Color2Hsv(ref PixelRGB color, out double h, out double s, out double v)
        {
           ColorConverter.Rgb2Hsv(color.R, color.G, color.B, out h, out s, out v);
        }


    }
}
