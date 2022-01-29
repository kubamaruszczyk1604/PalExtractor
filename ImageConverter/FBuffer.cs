using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter
{
    class FBuffer
    {
        public float[] Data { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public FBuffer(int w, int h)
        {
            Width = w;
            Height = h;
            Data = new float[Width * Height];
        }

        public FBuffer(int w, int h, float[] data)
        {
            if((w*h)!=data.Length)
            {
                throw new Exception("Data length and dimensions do not match");
            }
            Width = w;
            Height = h;
            Data = data;
        }

        public void SetField(int x, int y, float val)
        {
            Data[XY2I(x, y)] = val;
        }

        public void SetField(int i, float val)
        {
            Data[i] = val;
        }

        public float GetField(int x, int y)
        {
            return Data[XY2I(x, y)];
        }

        public float GetField(int i)
        {
            return Data[i];
        }


        private int XY2I(int x, int y)
        {
            return y * Width + x;
        }
    }
}
