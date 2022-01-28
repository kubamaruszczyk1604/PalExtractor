using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ImageReader
{
    public struct PixelRGB
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }


        public PixelRGB(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }

    public class BitmapRGB
    {
        public PixelRGB[] Pixels { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Image OriginalImage { get; private set; }

        private static int XY2I(int x, int y, int w)
        {
            return (w * y + x);
        }

        static public BitmapRGB FromFile(string s, Size limit = new Size())
        {
           
            try
            {
                Image img = Image.FromFile(s);
                int w = img.Width;
                int h = img.Height;
                

                float sf = 1.0f;  
                if(limit.Width>0 &&  w >limit.Width)
                {
                    sf = ((float)limit.Width) / w;
                    w = (int)((float)w * sf);
                    h = (int)((float)h * sf);
                }
                if(limit.Height>0 &&   h>limit.Height)
                {
                    sf = ((float)limit.Height) / h;
                    w = (int)((float)w * sf);
                    h = (int)((float)h * sf);
                }

                
                Bitmap b = new Bitmap(img,new Size(w,h));
                
                PixelRGB[] data = new PixelRGB[b.Width * b.Height];
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c = b.GetPixel(i, j);
                        data[XY2I(i, j, b.Width)] = new PixelRGB(c.R, c.G, c.B);
                    }
                }
                //img.Dispose();
                b.Dispose();
                BitmapRGB ret = new BitmapRGB(data, w, h);
                ret.OriginalImage = img;
                return ret;
            }
            catch
            {
                return null;
            }
        }

        private BitmapRGB(PixelRGB[] data, int w, int h)
        {
            Width = w;
            Height = h;
            Pixels = data;
        }

        public PixelRGB GetPixel(int x, int y)
        {
            return Pixels[XY2I(x, y, Width)];
        }

        public void SetPixel(int x, int y, PixelRGB pixel)
        {
            Pixels[XY2I(x, y, Width)] = pixel;
        }

        public void SetR(int x, int y, byte r)
        {
            Pixels[XY2I(x, y, Width)].R = r;
        }

        public void SetG(int x, int y, byte g)
        {
            Pixels[XY2I(x, y, Width)].G = g;
        }

        public void SetB(int x, int y, byte b)
        {
            Pixels[XY2I(x, y, Width)].B = b;
        }

        public void Dispose()
        {
            OriginalImage.Dispose();
            Pixels = null;
        }


    }
}
