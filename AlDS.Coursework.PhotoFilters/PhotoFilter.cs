using AlDS.Coursework.PhotoFilters.Filters;
using System.Drawing;

namespace AlDS.Coursework.PhotoFilters
{
    public class PhotoFilter
    {

        public uint Width { get; set; }
        public uint Heigh { get; set; }

        public RGBA[,]? Img { get; set; }
        private double[,] _Img { get; set; }

        public void LoadPixels(string path)
        {
            using (FileStream stream = File.OpenRead(path))
            {
                var bmp = new Bitmap(stream);

                Img = new RGBA[bmp.Width, bmp.Height];

                for (var x = 0; x < bmp.Width; x++)
                    for (var y = 0; y < bmp.Height; y++)
                        Img[x, y] = new RGBA(bmp.GetPixel(x, y));
            }

        }

        private static Bitmap ConvertToBitmap(int width, int height, Func<int, int, Color> getPixelColor)
        {
            var bmp = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bmp))
            {
                for (var x = 0; x < width; x++)
                    for (var y = 0; y < height; y++)
                        g.FillRectangle(new SolidBrush(getPixelColor(x, y)),
                            x,
                            y,
                            1,
                            1
                        );
            }

            return bmp;
        }

        private static Bitmap ConvertToBitmap(RGBA[,] array)
        {
            return ConvertToBitmap(array.GetLength(0), array.GetLength(1),
                (x, y) => Color.FromArgb(array[x, y].Alpha, array[x, y].R, array[x, y].G, array[x, y].B));
        }

        private static Bitmap ConvertToBitmap(double[,] array)
        {
            return ConvertToBitmap(array.GetLength(0), array.GetLength(1), (x, y) =>
            {
                var gray = (int)(255 * array[x, y]);
                gray = Math.Min(gray, 255);
                gray = Math.Max(gray, 0);
                return Color.FromArgb(gray, gray, gray);
            });
        }

        public void ApplySobel()
        {
            //_Img = ToRGBA.ConvertToDoubleArray(Img);
            _Img = SobelOperator.Apply(Img, new double[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } });
        }


        public void Save(string path)
        {
            var bitmap = ConvertToBitmap(_Img);
            bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
