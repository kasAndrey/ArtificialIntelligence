using ArtificialIntelligence.Lab1Hamming;
using ArtificialIntelligence.Lab8AntColony;

namespace ArtificialIntelligence
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            TabControl.TabPages.Add(new HammingMGMT());
            TabControl.TabPages.Add(new AntColonyMGMT());
        }
    }
}