using BeautifulColors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assassins.Helpers
{
    public static class Colors
    {
        public static string ConvertTotalToRgb(double low, double high, double cell)
        {
            var range = high - low;
            double h = cell / range;
            var rgb = Color.FromHSV(h, 1, 0.75);
            //rgb = HSVtoRGB(h, 1.0f, 1.0f);
            return "#" + rgb.R.ToString("X2") + rgb.G.ToString("X2") + rgb.B.ToString("X2");
        }

        public static string GetHeapMapColor(float val, float high, float low)
        {
            // http://www.andrewnoske.com/wiki/Code_-_heatmaps_and_color_gradients
            const int NUM_COLORS = 3;
            var range = high - low;
            float[] bins = new float[NUM_COLORS];
            var binDivVal = range / (NUM_COLORS - 1);
            for (int idx = 0; idx < NUM_COLORS; idx++)
            {
                if (idx == NUM_COLORS - 1)
                    bins[idx] = high;
                else if (idx == 0)
                    bins[idx] = low;
                else
                    bins[idx] = binDivVal * idx;
            }
            float[][] color = new float[][] {
                        new float[] { 0, 0, 1 },
                        //new float[] { 0, 1, 0 },
                        new float[] { 1, 0.5f, 0 },
                        new float[] { 1, 0, 0 },
            };
            // A static array of 4 colors:  (blue,   green,  yellow,  red) using {r,g,b} for each.
            int idx1 = 0;
            int idx2 = 0;
            float fractBetween = 0;
            if (val <= low)
            {
                idx1 = idx2 = 0;
            }
            else if (val >= high)
            {
                idx1 = idx2 = NUM_COLORS - 1;
            }
            else
            {
                //  var newVal = val * (NUM_COLORS - 1);
                //idx1 = (int)Math.Floor(newVal);
                //idx2 = idx1 + 1;
                // fractBetween = newVal - (float)idx1;
                for (int idx = bins.Length - 1; idx >= 0; idx--)
                {
                    if (bins[idx] < val)
                    {
                        idx1 = idx;
                        break;
                    }
                }
                idx2 = idx1 + 1;
                var localVal = val - bins[idx1];
                fractBetween = localVal / binDivVal;
            }
            var r = (int)(255 * ((color[idx2][0] - color[idx1][0]) * fractBetween + color[idx1][0]));
            var g = (int)(255 * ((color[idx2][1] - color[idx1][1]) * fractBetween + color[idx1][1]));
            var b = (int)(255 * ((color[idx2][2] - color[idx1][2]) * fractBetween + color[idx1][2]));
            return "#" + r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
        }
    }
}
