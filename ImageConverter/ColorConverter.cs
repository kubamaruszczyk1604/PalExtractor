using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter
{
    class ColorConverter
    {


        public static void Hsv2Rgb(double h, double s, double v, out int r, out int g, out int b)
        {

            h = (Math.Abs(h) % 360d)/60d;
            double R, G, B;
            if (v <= 0)
            {
                R = G = B = 0;
            }
            else if (s <= 0)
            {
                R = G = B = v;
            }
            else
            {
                int stepH = (int)Math.Floor(h);
                double fractH = h - stepH;
                double pv = v * (1 - s);
                double qv = v * (1 - s * fractH);
                double tv = v * (1 - s * (1 - fractH));

                switch (stepH)
                {
                    // Red dominant
                    case 0:
                        R = v; G = tv; B = pv;
                        break;

                    // Green dominant
                    case 1:
                        R = qv; G = v; B = pv;
                        break;
                    case 2:
                        R = pv; G = v; B = tv;
                        break;

                    // Blue dominant
                    case 3:
                        R = pv; G = qv; B = v;
                        break;
                    case 4:
                        R = tv; G = pv; B = v;
                        break;

                    // Red dominant
                    case 5:
                        R = v; G = pv; B = qv;
                        break;
                    case 6:
                        R = v; G = tv; B = pv;
                        break;

                    default:
                        R = G = B = v;
                        break;
                }
            }
            r = Norm2Int(R); g = Norm2Int(G); b = Norm2Int(B);
        }

        static int Norm2Int(double val)
        {
            val *= 255d;
            val = (val < 0) ? 0 : val;
            val = (val > 255) ? 255 : val;
            return (int)val;
        }

        static public double GetHue(int r, int g, int b)
        {
            double R = (double)r / 255d;
            double G = (double)g / 255d;
            double B = (double)b / 255d;

            double M = Math.Max(R, G);
            M = Math.Max(M, B);

            double m = Math.Min(R, G);
            m = Math.Min(m, B);

            double C = M - m;
            if (C == 0) return 0;

            double hue = 0;
            if (M == R)
            {
                hue = (G - B) / C;
                hue %= 6;
            }
            else if (M == G)
            {
                hue = (B - R) / C;
                hue += 2;
            }
            else if (M == B)
            {
                hue = (R - G) / C;
                hue += 4;
            }
            return hue * 60;

        }


        public static void Rgb2Hsv(int r, int g, int b, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(r, Math.Max(g, b));
            int min = Math.Min(r, Math.Min(g, b));

            hue = GetHue(r, g, b);
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }
    }
}
