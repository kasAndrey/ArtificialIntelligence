using System.ComponentModel;
using GraphicsManagement;
using MathObjects;

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

            openFileButton.Click += (object? sender, EventArgs e) => { ofd.ShowDialog(); };
        }

        private void OnFileSelected(object sender, CancelEventArgs e)
        {
            try
            {
                int referencePictureIndex = neuralNetwork.Recognize(BitmapImageProcessor.LoadPicture(ofd.FileName));

                inputImage.Image = BitmapImageProcessor.ResizedImage(Image.FromFile(ofd.FileName), outputImage.Size);

                if (referencePictureIndex != -1)
                {
                    uiTextOutput.Text = "Unknown image should be Image #" + (referencePictureIndex + 1) + ".";
                    uiTextOutput.ForeColor = Color.Black;
                    outputImage.Image = BitmapImageProcessor.ResizedImage(Image.FromFile(referenceImageFiles[referencePictureIndex].FullName), outputImage.Size);
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
    }
}
