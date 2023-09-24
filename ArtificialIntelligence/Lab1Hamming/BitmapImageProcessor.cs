using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.Lab1Hamming
{
    static class BitmapImageProcessor
    {
        const int GREY = 0x888888;
        const int WHITE = 0xFFFFFF;
        //const int BLACK = 0x000000;

        public const string ImagesDirectory = @"..\..\..\Lab1Hamming\Images\";
        public static Vector BitmapToVector(Bitmap bmp)
        {
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

        public static Vector[] LoadReferencePictures(FileInfo[] files)
        {
            Bitmap[] bmps = new Bitmap[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                bmps[i] = (Bitmap)Image.FromFile(files[i].FullName);
            }

            Vector[] codedImages = new Vector[files.Length];

            for (int k = 0; k < files.Length; k++)
            {
                codedImages[k] = BitmapToVector(bmps[k]);
            }

            return codedImages;
        }

        public static Vector LoadUnknownPicture(string name) => BitmapToVector((Bitmap)Image.FromFile(name));
    }
}
