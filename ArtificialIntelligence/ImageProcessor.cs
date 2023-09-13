using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence
{
    static class ImageProcessor
    {
        static Vector BitmapToVector(Bitmap bmp)
        {
            Vector a = new(bmp.Width * bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    a[i * bmp.Height + j] = (bmp.GetPixel(i, j).ToArgb() & 0x00FFFFFF) > 0x00888888 ? 1 : -1;
                }
            }
            return a;
        }

        public static Vector[] LoadReferencePictures()
        {
            FileInfo[] files = new DirectoryInfo(@"..\..\..\Images\").GetFiles("Reference*.bmp");
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

        public static Vector LoadUnknownPicture(string path) => BitmapToVector((Bitmap)Image.FromFile(path));
    }
}
