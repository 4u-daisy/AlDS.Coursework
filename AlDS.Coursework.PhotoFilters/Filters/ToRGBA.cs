using System.Drawing;

namespace AlDS.Coursework.PhotoFilters.Filters
{
    public static class ToRGBA
    {
        public static double[,] ConvertToDoubleArray(RGBA[,] image)
        {
            var array = new double[image.GetLength(0), image.GetLength(1)];
            for (int i = 0; i < image.GetLength(0); i++)
                for (int j = 0; j < image.GetLength(1); j++)
                    array[i, j] = image[i, j].GetColor().ToArgb();
            return array;
        }

        public static RGBA[,] ConvertToRGBA(double[,] image)
        {
            var array = new RGBA[image.GetLength(0), image.GetLength(1)];


            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    var color = (int)(image[i, j] * 100);
                    array[i, j] = new RGBA(color);
                }
            }
                    
            return array;
        }

    }
}
