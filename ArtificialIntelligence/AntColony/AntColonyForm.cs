namespace ArtificialIntelligence.AntColony
{
    public partial class AntColonyForm : Form
    {
        //private AntColony;

        public AntColonyForm()
        {
            InitializeComponent();

            loadGraphButton.Click += (object sender, EventArgs e) => { ogfd.ShowDialog(); };
            ogfd.InitialDirectory = new DirectoryInfo(GraphParser.GraphsDirectory).FullName;
        }

        private void alphaChanged(object sender, EventArgs e)
        {
            if (sender is TrackBar)
            {
                alphaNumeric.Value = (decimal)((sender as TrackBar)!.Value / 100.0);
            }
            else if (sender is NumericUpDown)
            {
                alphaTrackBar.Value = (int)((sender as NumericUpDown)!.Value * 100);
            }
        }

        private void betaChanged(object sender, EventArgs e)
        {
            if (sender is TrackBar)
            {
                betaNumeric.Value = (decimal)((sender as TrackBar)!.Value / 100.0);
            }
            else if (sender is NumericUpDown)
            {
                betaTrackBar.Value = (int)((sender as NumericUpDown)!.Value * 100);
            }
        }
    }
}
