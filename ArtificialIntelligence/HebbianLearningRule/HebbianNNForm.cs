using ArtificialIntelligence.GraphicsMGMT;
using ArtificialIntelligence.MathObjects;
using System.ComponentModel;

namespace ArtificialIntelligence.HebbianLearningRule
{
    public partial class HebbianNNForm : Form
    {
        private const int imagesCount = 4;

        private HebbianNN neuralNetwork;
        private FileInfo[] referenceImageFiles;

        public HebbianNNForm()
        {
            InitializeComponent();

            neuralNetwork = new(imagesCount);
            referenceImageFiles = new FileInfo[imagesCount];

            ofd1.InitialDirectory = new DirectoryInfo(BitmapImageProcessor.ImagesDirectory).FullName;
            ofd2.InitialDirectory = new DirectoryInfo(BitmapImageProcessor.ImagesDirectory).FullName;

            openFileButton.Click += (object sender, EventArgs e) =>
            {
                ofd1.ShowDialog();
            };

            referenceImagesButton.Click += (object sender, EventArgs e) =>
            {
                ofd2.ShowDialog();
            };
        }

        private void SetReferenceImages(object sender, CancelEventArgs e)
        {
            if (ofd2.FileNames.Length != imagesCount)
            {
                MessageBox.Show($"Choose exactly {imagesCount} different images!", "Images count is not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < imagesCount; i++)
            {
                referenceImageFiles[i] = new FileInfo(ofd2.FileNames[i]);
            }

            Vector[] referenceImages = new Vector[imagesCount];

            for (int i = 0; i < imagesCount; i++)
            {
                referenceImages[i] = BitmapImageProcessor.LoadPicture(referenceImageFiles[i].FullName);
            }

            try
            {
                neuralNetwork.Train(referenceImages);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            imagesLoadedLabel.Visible = true;
            openFileButton.Enabled = true;
        }

        private void OnFileSelected(object sender, CancelEventArgs e)
        {
            try
            {
                int referencePictureIndex = neuralNetwork.Recognize(BitmapImageProcessor.LoadPicture(ofd1.FileName));

                inputImage.Image = BitmapImageProcessor.ResizedImage(Image.FromFile(ofd1.FileName), outputImage.Size);

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
