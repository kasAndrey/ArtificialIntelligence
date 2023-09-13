using ArtificialIntelligence.NeuralNetwork;

namespace ArtificialIntelligence
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            INeuralNetwork neuralNetwork = new HammingNN();
            ((HammingNN)neuralNetwork).Debugger += Debug;

            neuralNetwork.Train(ImageProcessor.LoadReferencePictures());
            neuralNetwork.Recognize(ImageProcessor.LoadUnknownPicture(@"..\..\..\Images\Unknown_A.bmp"));
        }

        private void Debug(string info)
        {
            DebugField.Text += info + "\n";
        }
    }
}