using ArtificialIntelligence.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography;

namespace ArtificialIntelligence.Hamming
{
    public partial class HammingForm : Form
    {
        private HammingNN neuralNetwork;

        private FileInfo[] referenceImages;

        public HammingForm()
        {
            InitializeComponent();

            referenceImages = new DirectoryInfo(BitmapImageProcessor.ImagesDirectory).GetFiles("Reference*.bmp");

            neuralNetwork = new HammingNN();
            neuralNetwork.Train(BitmapImageProcessor.LoadReferencePictures(referenceImages));

            ofd.InitialDirectory = new DirectoryInfo(BitmapImageProcessor.ImagesDirectory).FullName;

            openFileButton.Click += (object sender, EventArgs e) => { ofd.ShowDialog(); };
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
            Bitmap bmp = new(300, 300);

            var g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(original, 0, 0, bmp.Width, bmp.Height);
            g.Save();

            return bmp;
        }
    }
}
