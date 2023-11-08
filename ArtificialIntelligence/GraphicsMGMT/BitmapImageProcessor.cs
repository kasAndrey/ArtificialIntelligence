using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.GraphicsMGMT
{
    static class BitmapImageProcessor
    {
        const int GREY = 0x888888;
        const int WHITE = 0xFFFFFF;
        //const int BLACK = 0x000000;

        public const string ImagesDirectory = @"..\..\..\Resources\Images\";
        public static Vector LoadPicture(string path)
        {
            Bitmap bmp = (Bitmap)Image.FromFile(path);

            Vector a = new(bmp.Width * bmp.Height);
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    a[i * bmp.Width + j] = (bmp.GetPixel(i, j).ToArgb() & WHITE) > GREY ? 1 : -1;
                }
            }
            return a;
        }

        public static Image ResizedImage(Image original, Size newSize)
        {
            Bitmap bmp = new(newSize.Width, newSize.Height);

            var g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(original, 0, 0, bmp.Width, bmp.Height);
            g.Save();

            return bmp;
        }
    }
}
