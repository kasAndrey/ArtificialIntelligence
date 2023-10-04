using System.ComponentModel;
using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.Hamming
{
    public partial class HammingForm : Form
    {
        private HammingNN neuralNetwork;

        private FileInfo[] referenceImageFiles;

        public HammingForm()
        {
            InitializeComponent();

            referenceImageFiles = new DirectoryInfo(BitmapImageProcessor.ImagesDirectory).GetFiles("Reference*.bmp");

            neuralNetwork = new HammingNN();

            Vector[] referenceImages = new Vector[referenceImageFiles.Length];

            for (int i = 0; i < referenceImageFiles.Length; i++)
            {
                referenceImages[i] = BitmapImageProcessor.LoadPicture(referenceImageFiles[i].FullName);
            }

            neuralNetwork.Train(referenceImages);

            ofd.InitialDirectory = new DirectoryInfo(BitmapImageProcessor.ImagesDirectory).FullName;

            openFileButton.Click += (object sender, EventArgs e) => { ofd.ShowDialog(); };
        }

        private void OnFileSelected(object sender, CancelEventArgs e)
        {
            try
            {
                int referencePictureIndex = neuralNetwork.Recognize(BitmapImageProcessor.LoadPicture(ofd.FileName));

                inputImage.Image = ResizedImage(Image.FromFile(ofd.FileName));

                if (referencePictureIndex != -1)
                {
                    uiTextOutput.Text = "Unknown image should be Image #" + (referencePictureIndex + 1) + ".";
                    uiTextOutput.ForeColor = Color.Black;
                    outputImage.Image = ResizedImage(Image.FromFile(referenceImageFiles[referencePictureIndex].FullName));
                }
                else
                {
                    uiTextOutput.Text = "Image is unrecognized.";
                    uiTextOutput.ForeColor = Color.Red;
                    outputImage.Image = null;
                }
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image ResizedImage(Image original)
        {
            Bitmap bmp = new(300, 300);

            var g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(original, 0, 0, bmp.Width, bmp.Height);
            g.Save();

            return bmp;
        }
    }
}
