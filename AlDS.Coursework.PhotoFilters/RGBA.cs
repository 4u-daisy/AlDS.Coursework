using System.Drawing;

namespace AlDS.Coursework.PhotoFilters
{
    public class RGBA

    {
        public int R;
        public int G;
        public int B;

        public int Alpha;

        public RGBA(int opacity = 255, int r = 0, int g = 0, int b = 0)
        {
            R = r;
            G = g;
            B = b;
            Alpha = opacity;
        }

        public RGBA(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
            Alpha = color.A;
        }

        public RGBA(int color)
        {
            var elem = Color.FromArgb(color);
            R = elem.R;
            G = elem.G;
            B = elem.B;
            Alpha = elem.A;
        }

        public Color GetColor()
        {
            return Color.FromArgb(R, G, B);
        }

    }
}
