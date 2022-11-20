using System.Drawing;

namespace AlDS.Coursework.PhotoFilters.Filters
{
    public static class SobelOperator
    {
        const double RedMultiplier = 0.299;
        const double GreenMultiplier = 0.587;
        const double BlueMultiplier = 0.114;
        const double NumberOfShades = 255;

        public static double[,] ToGrayscale(RGBA[,] original)
        {
            var width = original.GetLength(0);
            var height = original.GetLength(1);
            var grayscale = new double[width, height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    grayscale[x, y] = (original[x, y].R *
                                       RedMultiplier + original[x, y].G *
                                       GreenMultiplier + original[x, y].B *
                                       BlueMultiplier) / NumberOfShades;
            return grayscale;
        }
        public static double[,] Apply(RGBA[,] image, double[,] sx)
        {
            var img = ToGrayscale(image);
            return SobelFilter(img, sx);
        }

        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var result = new double[width, height];
            var sy = TransposeMatrix(sx);
            var shift = sx.GetLength(0) / 2;

            for (int x = shift; x < width - shift; x++)
                for (int y = shift; y < height - shift; y++)
                {
                    var gx = MultiplyPixelsByMatrix(g, sx, x, y, shift);
                    var gy = MultiplyPixelsByMatrix(g, sy, x, y, shift);
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            return result;
        }

        public static double[,] TransposeMatrix(double[,] matrix)
        {
            var sideLength = matrix.GetLength(0);
            var transposedMatrix = new double[sideLength, sideLength];
            for (int x = 0; x < sideLength; x++)
                for (int y = 0; y < sideLength; y++)
                    transposedMatrix[x, y] = matrix[y, x];
            return transposedMatrix;
        }

        public static double MultiplyPixelsByMatrix(double[,] pixels, double[,] matrix, int x, int y, int shift)
        {
            double result = 0;
            int sideLength = matrix.GetLength(0);
            for (int i = 0; i < sideLength; i++)
                for (int j = 0; j < sideLength; j++)
                    result += matrix[i, j] * pixels[x - shift + i, y - shift + j];
            return result;
        }
    }
}
