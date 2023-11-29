using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.FuzzyLogic
{
    public class ObstacleMap
    {
        private byte[,] bytesMap;

        public Size PreferredSize;
        public Size ActualSize { get { return new(bytesMap.GetLength(1), bytesMap.GetLength(0)); } }

        public byte this[int i, int j]
        {
            get { return bytesMap[i, j]; }
        }

        private ObstacleMap(byte[,] bytesMap)
        {
            this.bytesMap = bytesMap;
            PreferredSize = new(300, 300);
        }

        public static ObstacleMap GenerateRandom(int sizeX, int sizeY, double obstaclePossibility)
        {
            Random rnd = new();
            byte[,] byteMap = new byte[sizeY, sizeX];
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    byteMap[i, j] = (byte)(rnd.NextDouble() < obstaclePossibility ? 1 : 0);
                }
            }

            return new(byteMap);
        }

        public static ObstacleMap LoadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int charCount = lines[0].Length;

            byte[,] byteMap = new byte[lines.Length, charCount];
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length != charCount) throw new ArgumentException("Lines in file have different character count");

                for (int j = 0; j < charCount; j++)
                {
                    byteMap[i, j] = lines[i][j] switch
                    {
                        '.' => 0,
                        '#' => 1,
                        _ => throw new ArgumentException("Incorrect file format: unknown character \"" + lines[i][j] + "\""),
                    };
                }
            }

            return new(byteMap);
        }

        public Image Draw()
        {
            Image img = new Bitmap(PreferredSize.Width, PreferredSize.Height);
            Graphics g = Graphics.FromImage(img);

            Size blockSize = new(PreferredSize.Width / bytesMap.GetLength(1) + 1, PreferredSize.Height / bytesMap.GetLength(0) + 1);

            for (int i = 0; i < bytesMap.GetLength(0); i++)
            {
                for (int j = 0; j < bytesMap.GetLength(1); j++)
                {
                    if (bytesMap[i, j] == 1)
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), blockSize.Width * j, blockSize.Height * i, blockSize.Width, blockSize.Height);
                    }
                }
            }
            g.Save();

            return img;
        }

        public bool ObstacleAtPoint(Vector point)
        {
            if (point[0] < 0 || point[1] < 0 || point[0] >= bytesMap.GetLength(1) || point[1] >= bytesMap.GetLength(0)) return true;
            return this[(int)point[1], (int)point[0]] == 1;
        }
    }
}
