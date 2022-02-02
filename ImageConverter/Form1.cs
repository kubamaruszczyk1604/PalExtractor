using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO.Compression;
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
            m_ReservedColors = new List<PixelRGB>();
            m_ReservedColors.Add(new PixelRGB(0, 0, 0));
            UpdateReservedUI();
            //button_Convert.Enabled = false;
        }
        Image m_Image = null;
        BitmapRGB m_SourceBitmap;
        BitmapRGB m_DestinationBitmap;
        FBuffer m_IntensityBuffer;

        List<PixelRGB> m_ReservedColors;

        void UpdateReservedUI()
        {
            if(pictureBoxReserved.Image != null)
            {
                pictureBoxReserved.Image.Dispose();
            }
            pictureBoxReserved.Image = new Bitmap(pictureBoxReserved.Width, pictureBoxReserved.Height);
            for (int y = 0; y < pictureBoxReserved.Height;++y)
            {
                int i = (int) (((float)y / (float)pictureBoxReserved.Height)*m_ReservedColors.Count);

                PixelRGB c = m_ReservedColors[i];
                for (int x = 0; x < pictureBoxReserved.Width; ++x)
                {

                    ((Bitmap)pictureBoxReserved.Image).SetPixel(x, y, Color.FromArgb(c.R, c.G, c.B));
                }
              }

        }

        private void button_Open_Click(object sender, EventArgs e)
        {

            OpenFileDialog sd = new OpenFileDialog();
            sd.RestoreDirectory = true;
            sd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                if (m_Image != null) m_Image.Dispose();
                string s = sd.FileName;
                m_SourceBitmap = BitmapRGB.FromFile(s, new Size(320,240));
                m_DestinationBitmap = BitmapRGB.FromFile(s, new Size(320, 240));
                m_Image = m_SourceBitmap.OriginalImage;

                pictureBoxLeft.BackColor = Color.Black;
                pictureBoxLeft.Image = m_Image;
                label1.Text = "Source resolution: " + m_Image.Width.ToString() + " x " + m_Image.Height.ToString();
            }


        }

        private void button_save_Click(object sender, EventArgs e)
        {

            var dialog = new ExportDialogForm();
            dialog.SetPaletteImage(pictureBoxPalette.Image);
            dialog.SetChromaImage(Bitmap2Image(m_DestinationBitmap));
            if(m_IntensityBuffer != null)
            {
                dialog.SetLumaImage(Intensity2Image(m_IntensityBuffer));
            }
            dialog.ShowDialog();

            if(dialog.Result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.OutputDir))
            {
                try
                {
                    string path = dialog.OutputDir + @"\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if(dialog.PaletteChecked) SavePalette(path + @"\palette.txt");
                    if(dialog.ChromaChecked) SaveColorTexture(path + @"\color.tex");
                    if (m_IntensityBuffer != null && dialog.LumaChecked)
                    {
                        SaveIntensityBuffer(path + @"\luma.buf");
                        m_IntensityBuffer = null;
                    }
                    MessageBox.Show( path, "Texture package saved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Reason: " + ex.Message, "Failed to save");
                }
            }


        }




        public void ClusterHV(BitmapRGB scrBitmap, ref BitmapRGB destinationBitmap, bool excludeSaturation = false)
        {
            List<PixelData> pixels = new List<PixelData>(scrBitmap.Width * scrBitmap.Height);

            for (int i = 0; i < scrBitmap.Pixels.Length; ++i)
            {
                RGB2HSV(ref scrBitmap.Pixels[i], out double h, out double s, out double v);
                pixels.Add(new PixelData(h / 360d, s, v));
            }


            KMeansClustering cl = new KMeansClustering(pixels.ToArray(), 15);
            Cluster[] clusters = cl.Compute();

            m_PaletteColors = new List<PixelRGB>(clusters.Length+m_ReservedColors.Count);
            m_PaletteColors.AddRange(m_ReservedColors);
            for (int i = 0; i < clusters.Length; ++i)
            {
                Cluster c = clusters[i];
                for (int j = 0; j < c.Points.Count; ++j)
                {
                    ((PixelData)c.Points[j]).Set(c.Centroid.Components[0], c.Centroid.Components[1], c.Centroid.Components[2]);
                }
                float val = excludeSaturation ? 1.0f : (float)(c.Centroid.Components[2]);
                m_PaletteColors.Add(HSV2RGB((float)(c.Centroid.Components[0] * 360d), (float)(c.Centroid.Components[1]), val));
                   
            }
            
            m_IntensityBuffer = new FBuffer(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < pixels.Count; ++i)
            {
                float val = excludeSaturation ? 1.0f : (float)(pixels[i].Components[2]);
                destinationBitmap.Pixels[i] = HSV2RGB((float)(pixels[i].Components[0] * 360d), (float)(pixels[i].Components[1]), val);
                m_IntensityBuffer.SetField(i, (float)(pixels[i].Components[2]));
            }
        }


        List<PixelRGB> m_PaletteColors;

        public void ClusterRGB(BitmapRGB scrBitmap, ref BitmapRGB destinationBitmap)
        {
            List<PixelData> pixels = new List<PixelData>(scrBitmap.Width * scrBitmap.Height);

            for (int i = 0; i < scrBitmap.Pixels.Length; ++i)
            {
               // RGB2HSV(ref scrBitmap.Pixels[i], out double h, out double s, out double v);
                //scrBitmap.Pixels[i] = HSV2RGB((float)h, (float)s, (float)v);
                PixelRGB c = scrBitmap.Pixels[i];
                pixels.Add(new PixelData(((double)c.R) / 255d, ((double)c.G / 255d), ((double)c.B / 255d)));
            }


            KMeansClustering cl = new KMeansClustering(pixels.ToArray(), 15);
            Cluster[] clusters = cl.Compute();
            m_PaletteColors = new List<PixelRGB>(clusters.Length+m_ReservedColors.Count);
            m_PaletteColors.AddRange(m_ReservedColors);
            for (int i = 0; i < clusters.Length; ++i)
            {
                Cluster c = clusters[i];
                for (int j = 0; j < c.Points.Count; ++j)
                {
                    ((PixelData)c.Points[j]).Set(c.Centroid.Components[0], c.Centroid.Components[1], c.Centroid.Components[2]);
                }
                m_PaletteColors.Add(new PixelRGB((byte)(c.Centroid.Components[0] * 255d), (byte)(c.Centroid.Components[1] * 255d), (byte)(c.Centroid.Components[2] * 255d)));
            }

            m_IntensityBuffer = new FBuffer(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < pixels.Count; ++i)
            {
                destinationBitmap.Pixels[i] = new PixelRGB((byte)(pixels[i].Components[0] * 255d), (byte)(pixels[i].Components[1] * 255d),
                    (byte)(pixels[i].Components[2] * 255d));

                RGB2HSV(ref scrBitmap.Pixels[i], out double h, out double s, out double v);
                m_IntensityBuffer.SetField(i, (float)v);

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
              
                for(int y = 0; y < m_DestinationBitmap.Height; ++y)
                {
                    string row = "";
                    for(int x = 0; x< m_DestinationBitmap.Width; ++x)
                    {
                        row += map[m_DestinationBitmap.GetPixel(x, y)].ToString() + ",";
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

        private static PixelRGB HSV2RGB(float h, float s, float v)
        {
            ColorConverter.Hsv2Rgb(h, s, v, out int r, out int g, out int b);
            return new PixelRGB((byte)r, (byte)g, (byte)b);
        }

       private static void RGB2HSV(ref PixelRGB color, out double h, out double s, out double v)
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

        Image Bitmap2Image(BitmapRGB bitmap, FBuffer buffer)
        {
            Bitmap img = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int i = 0; i < bitmap.Pixels.Length; ++i)
            {
                int x = i % bitmap.Width;
                int y = i / bitmap.Width;
                float lum =   buffer.Data[i];
                Color c = Color.FromArgb(
                    (int)(((float)bitmap.Pixels[i].R)*lum), 
                    (int)(((float)bitmap.Pixels[i].G)*lum),
                    (int)(((float)bitmap.Pixels[i].B)*lum));
                img.SetPixel(x, y, c);
            }
            return img;
        }

        Image Intensity2Image(FBuffer buffer)
        {
            Bitmap img = new Bitmap(buffer.Width, buffer.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int i = 0; i < buffer.Data.Length; ++i)
            {
                int x = i % buffer.Width;
                int y = i / buffer.Width;
                int lum = (int)(buffer.Data[i] * 255f);
                Color c = Color.FromArgb(lum,lum,lum);
                img.SetPixel(x, y, c);
            }
            return img;
        }

        private async void button_Convert_Click(object sender, EventArgs e)
        {
            if (m_SourceBitmap == null)
            {
                MessageBox.Show("No image selected");
                return;
            }
            //new Task(() => { ClusterRGB(ref m_Bitmap); }).Start();
            button_Convert.Enabled = false;
            button_save.Enabled = false;
            label2.Text = "Calculating... Please wait.";
            if (trackBar1.Value == 2)
            {
                await Task.Run(() => { ClusterRGB(m_SourceBitmap, ref m_DestinationBitmap); });
            }
            else if(trackBar1.Value == 1)
            {
                await Task.Run(() => { ClusterHV(m_SourceBitmap, ref m_DestinationBitmap); });
            }
            else
            {
                await Task.Run(() => { ClusterHV(m_SourceBitmap, ref m_DestinationBitmap, true); });
            }
            pictureBoxRight.Image = Bitmap2Image(m_DestinationBitmap);
            //pictureBoxRight.BackColor = Color.Black;
            Console.WriteLine("Done");
            button_Convert.Enabled = true;
            button_save.Enabled = true;
            label2.Text = "Destination Resolution: " + m_DestinationBitmap.Width.ToString() + " x " + m_DestinationBitmap.Height.ToString();
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(trackBar1.Value == 2)
            {
                labelSpace.Text = "RGB";
            }
            else if(trackBar1.Value == 1)
            {
                labelSpace.Text = "HSV";
            }
            else if (trackBar1.Value == 0)
            {
                labelSpace.Text = "HS";
            }
            else
            {
                labelSpace.Text = "ERR";
            }
        }

        private void pictureBoxReserved_Click(object sender, EventArgs e)
        {
           if( colorDialog1.ShowDialog() == DialogResult.OK)
            {
                m_ReservedColors.Add(new PixelRGB(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B));
                UpdateReservedUI();
            }
        }

        private void buttonRemoveReserved_Click(object sender, EventArgs e)
        {
            if(m_ReservedColors.Count>1)
            {
                m_ReservedColors.Remove(m_ReservedColors[m_ReservedColors.Count - 1]);
                UpdateReservedUI();
            }
        }

        private void buttonAddReserved_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                m_ReservedColors.Add(new PixelRGB(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B));
                UpdateReservedUI();
            }
        }
    }
}
