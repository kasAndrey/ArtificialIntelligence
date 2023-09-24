using System.ComponentModel;

namespace ArtificialIntelligence.Lab1Hamming
{
    public class HammingMGMT : TabPage
    {
        private HammingNN neuralNetwork;
        private OpenFileDialog ofd;
        private Button openFileButton;

        private Label uiTextOutput;
        private PictureBox inputImage, outputImage;
        private Label inputImageDescription, outputImageDescription;

        private readonly FileInfo[] referenceImages;

        private readonly Size imageNewSize = new(300, 300);

        public HammingMGMT() : base("1. Hamming Neural Network")
        {
            base.AutoSize = true;

            referenceImages = new DirectoryInfo(BitmapImageProcessor.ImagesDirectory).GetFiles("Reference*.bmp");

            neuralNetwork = new HammingNN();
            neuralNetwork.Train(BitmapImageProcessor.LoadReferencePictures(referenceImages));

            SuspendLayout();

            inputImageDescription = new Label()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(10, 10),
                Size = new Size(imageNewSize.Width, 20),
                Text = "Loaded image:"
            };
            inputImage = new PictureBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Size = imageNewSize,
                Location = new Point(10, 40),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle
            };

            outputImageDescription = new Label
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(320, 10),
                Size = new Size(imageNewSize.Width, 20),
                Text = "Recognized as:"
            };
            outputImage = new PictureBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Size = imageNewSize,
                Location = new Point(320, 40),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle
            };

            openFileButton = new Button
            {
                Text = "Open Image",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Size = new Size(120, 40),
                Location = new Point(70, 10)
            };

            uiTextOutput = new Label
            {
                BorderStyle = BorderStyle.Fixed3D,
                BackColor = Color.White,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                Size = new Size(180, 50),
                Font = new Font("Arial", 18.0f),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 40)
            };

            ofd = new()
            {
                Filter = "Images (*.bmp)|*.bmp",
                InitialDirectory = new DirectoryInfo(BitmapImageProcessor.ImagesDirectory).FullName
            };
            ofd.FileOk += OnFileSelected;

            openFileButton.Click += (object sender, EventArgs e) => { ofd.ShowDialog(); };

            ResumeLayout(false);

            Controls.Add(inputImageDescription);
            Controls.Add(inputImage);
            Controls.Add(outputImageDescription);
            Controls.Add(outputImage);
            Controls.Add(uiTextOutput);
            Controls.Add(openFileButton);
        }

        private void OnFileSelected(object sender, CancelEventArgs e)
        {
            try
            {
                int referencePictureIndex = neuralNetwork.Recognize(BitmapImageProcessor.LoadUnknownPicture(ofd.FileName));

                inputImage.Image = ResizedImage(Image.FromFile(ofd.FileName));

                if (referencePictureIndex != -1)
                {
                    uiTextOutput.Text = "Unknown image should be Image #" + (referencePictureIndex + 1) + ".";
                    uiTextOutput.ForeColor = Color.Black;
                    outputImage.Image = ResizedImage(Image.FromFile(referenceImages[referencePictureIndex].FullName));
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
            Bitmap bmp = new(imageNewSize.Width, imageNewSize.Height);

            var g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(original, 0, 0, bmp.Width, bmp.Height);
            g.Save();

            return bmp;
        }
    }
}
