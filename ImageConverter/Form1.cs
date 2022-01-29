using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            button_save.Enabled = false;
            //button_Convert.Enabled = false;
        }
        Image m_Image = null;
        BitmapRGB m_Bitmap;
        FBuffer m_IntensityBuffer;

        private void button_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog sd = new OpenFileDialog();
            sd.RestoreDirectory = true;
            sd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                if (m_Image != null) m_Image.Dispose();
                string s = sd.FileName;
                m_Bitmap = BitmapRGB.FromFile(s, new Size(320,240));
                m_Image = m_Bitmap.OriginalImage;
              
                pictureBoxLeft.Image = m_Image;
                label1.Text = "Source resolution: " + m_Image.Width.ToString() + " x " + m_Image.Height.ToString();
            }


        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string name = "nowa_textura8";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    try
                    {
                        string path = fbd.SelectedPath + @"\" + name;
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        SavePalette(path + @"\palette.txt");
                        SaveColorTexture(path + @"\color.tex");
                        if (m_IntensityBuffer != null)
                        {
                            SaveIntensityBuffer(path + @"\luma.buf");
                            m_IntensityBuffer = null;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Reason: " + ex.Message, "Failed to save");
                    }

                }
            }
        }




        public void ClusterHV(ref BitmapRGB scrBitmap)
        {
            List<PixelData> pixels = new List<PixelData>(scrBitmap.Width * scrBitmap.Height);

            for (int i = 0; i < scrBitmap.Pixels.Length; ++i)
            {
                RGB2HSV(ref scrBitmap.Pixels[i], out double h, out double s, out double v);
                pixels.Add(new PixelData(h / 360d, s, (float)v));
            }


            KMeansClustering cl = new KMeansClustering(pixels.ToArray(), 15);
            Cluster[] clusters = cl.Compute();
            m_PaletteColors = new List<PixelRGB>(clusters.Length+1);
            m_PaletteColors.Add(new PixelRGB(0, 0, 0));
            for (int i = 0; i < clusters.Length; ++i)
            {
                Cluster c = clusters[i];
                for (int j = 0; j < c.Points.Count; ++j)
                {
                    ((PixelData)c.Points[j]).SetHueSat(c.Centroid.Components[0], c.Centroid.Components[1]);
                }
                m_PaletteColors.Add(HSV2RGB((float)(c.Centroid.Components[0] * 360d), (float)(c.Centroid.Components[1]), 1.0f));

            }
            m_IntensityBuffer = new FBuffer(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < pixels.Count; ++i)
            {
                scrBitmap.Pixels[i] = HSV2RGB((float)(pixels[i].Components[0] * 360d), (float)(pixels[i].Components[1]), 1.0f);
                m_IntensityBuffer.SetField(i, pixels[i].Value);
                //(float)((Math.Round(pixels[i].Value*10d)/10d)));
            }
        }


        List<PixelRGB> m_PaletteColors;

        public void ClusterRGB(ref BitmapRGB scrBitmap)
        {
            List<PixelData> pixels = new List<PixelData>(scrBitmap.Width * scrBitmap.Height);

            for (int i = 0; i < scrBitmap.Pixels.Length; ++i)
            {
                RGB2HSV(ref scrBitmap.Pixels[i], out double h, out double s, out double v);
                scrBitmap.Pixels[i] = HSV2RGB((float)h, (float)s, (float)v);
                PixelRGB c = scrBitmap.Pixels[i];
                pixels.Add(new PixelData((double)c.R / 255d, (double)c.G / 255d, (double)c.B / 255d));
            }


            KMeansClustering cl = new KMeansClustering(pixels.ToArray(), 15);
            Cluster[] clusters = cl.Compute();
            m_PaletteColors = new List<PixelRGB>(clusters.Length+1);
            m_PaletteColors.Add(new PixelRGB(0, 0, 0));
            for (int i = 0; i < clusters.Length; ++i)
            {
                Cluster c = clusters[i];
                for (int j = 0; j < c.Points.Count; ++j)
                {
                    ((PixelData)c.Points[j]).SetRGB(c.Centroid.Components[0], c.Centroid.Components[1], c.Centroid.Components[2]);
                }
                m_PaletteColors.Add(new PixelRGB((byte)(c.Centroid.Components[0] * 255d), (byte)(c.Centroid.Components[1] * 255d), (byte)(c.Centroid.Components[2] * 255d)));
            }

            for (int i = 0; i < pixels.Count; ++i)
            {
                scrBitmap.Pixels[i] = new PixelRGB((byte)(pixels[i].Components[0] * 255d), (byte)(pixels[i].Components[1] * 255d),
                    (byte)(pixels[i].Components[2] * 255d));
            }
        }

        private void SavePalette(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                if (m_PaletteColors == null) return;

                foreach (var cl in m_PaletteColors)
                {
                    writer.WriteLine(cl.R.ToString() + "," + cl.G.ToString() + "," + cl.B.ToString());
                }
                writer.Close();

            }
        }

        private void SaveColorTexture(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                if (m_PaletteColors == null) return;

                Dictionary<PixelRGB, int> map = new Dictionary<PixelRGB, int>(m_PaletteColors.Count);
                for (int i = 0; i < m_PaletteColors.Count; ++i)
                {
                    try
                    {
                        map.Add(m_PaletteColors[i], i);
                    }
                    catch
                    {
                        PixelRGB p = m_PaletteColors[i];
                        p.R -= 1;

                        map.Add(p, i);
                    }
                }
              
                for(int y = 0; y < m_Bitmap.Height; ++y)
                {
                    string row = "";
                    for(int x = 0; x< m_Bitmap.Width; ++x)
                    {
                        row += map[m_Bitmap.GetPixel(x, y)].ToString() + ",";
                    }
                    row = row.Substring(0, row.Length - 1);
                    writer.WriteLine(row);
                }
                writer.Close();

            }
        }


        private void SaveIntensityBuffer(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {

                for (int y = 0; y < m_IntensityBuffer.Height; ++y)
                {
                    string row = "";
                    for (int x = 0; x < m_IntensityBuffer.Width; ++x)
                    {
                        row += m_IntensityBuffer.GetField(x,y).ToString() + ",";
                    }
                    row = row.Substring(0, row.Length - 1);
                    writer.WriteLine(row);
                }
                writer.Close();
            }
        }

        static PixelRGB HSV2RGB(float h, float s, float v)
        {
            ColorConverter.Hsv2Rgb(h, s, v, out int r, out int g, out int b);
            return new PixelRGB((byte)r, (byte)g, (byte)b);
        }

        public static void RGB2HSV(ref PixelRGB color, out double h, out double s, out double v)
        {
            ColorConverter.Rgb2Hsv(color.R, color.G, color.B, out h, out s, out v);
        }

        Image Bitmap2Image(BitmapRGB bitmap)
        {
            Bitmap img = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int i = 0; i < bitmap.Pixels.Length; ++i)
            {
                int x = i % bitmap.Width;
                int y = i / bitmap.Width;
                Color c = Color.FromArgb(bitmap.Pixels[i].R, bitmap.Pixels[i].G, bitmap.Pixels[i].B);
                img.SetPixel(x, y, c);
            }
            return img;
        }

        private async void button_Convert_Click(object sender, EventArgs e)
        {
            if (m_Bitmap == null)
            {
                MessageBox.Show("No image selected");
                return;
            }
            //new Task(() => { ClusterRGB(ref m_Bitmap); }).Start();
            button_Convert.Enabled = false;
            button_save.Enabled = false;
            label2.Text = "Calculating... Please wait.";
            await Task.Run(() => { ClusterHV(ref m_Bitmap); });
            pictureBoxRight.Image = Bitmap2Image(m_Bitmap);
            Console.WriteLine("Done");
            button_Convert.Enabled = true;
            button_save.Enabled = true;
            label2.Text = "Destination Resolution: " + m_Bitmap.Width.ToString() + " x " + m_Bitmap.Height.ToString();
            DrawPalette();
        }

        private void DrawPalette()
        {
            pictureBoxPalette.Image = new Bitmap(512, 40);
            Bitmap img = (Bitmap)pictureBoxPalette.Image;
            for (int x = 0; x < img.Width; ++x)
            {
                int ind = (int)(((float)x) / ((float)img.Width) * 16.0f);
                PixelRGB col = m_PaletteColors[ind];
                Color c = Color.FromArgb(col.R, col.G, col.B);
                for(int y =0; y < img.Height; ++y)
                {
                    img.SetPixel(x, y, c);
                }
            }
        }
    }
}
