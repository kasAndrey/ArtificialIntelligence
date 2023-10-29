using ArtificialIntelligence.GraphicsMGMT;
using System.ComponentModel;

namespace ArtificialIntelligence.SimulatedAnnealing
{
    public partial class SimulatedAnnealingForm : Form
    {
        DisplayableGraph? graph;
        SimulatedAnnealing? annealingAlgorithm;

        Graphics graphics;

        public SimulatedAnnealingForm()
        {
            InitializeComponent();

            loadGraphButton.Click += (object sender, EventArgs e) => { ofd.ShowDialog(); };

            ofd.InitialDirectory = new DirectoryInfo(GraphParser.GraphsDirectory).FullName;
        }

        private void OnFileSelected(object sender, CancelEventArgs e)
        {
            graph = GraphParser.Load(ofd.FileName);

            graphics = graphPictureBox.CreateGraphics();
            graphics.Clear(graphPictureBox.BackColor);
            graph.FixGraphics(graphics, graphPictureBox.Bounds);
            graph.Draw(graphics);

            initializeNewButton.Enabled = true;
        }

        private void InitializeNew(object sender, EventArgs e)
        {
            annealingAlgorithm = new(graph!, new Random());
            temperatureLabel.Text = $"Temp: {annealingAlgorithm.Temperature:F3}";
            nextButton.Enabled = true;
            findSolution.Enabled = true;
        }

        private void FindSolution(object sender, EventArgs e)
        {
            annealingAlgorithm!.FindSolution();
            temperatureLabel.Text = $"Temp: {annealingAlgorithm.Temperature:F3}";
            resultLabel.Text = $"Result: {annealingAlgorithm.Solution.ToString(true)} ({annealingAlgorithm.Solution.Distance(graph!, true)})";
            RedrawGraph();
            nextButton.Enabled = false;
            findSolution.Enabled = false;
        }

        private void NextIteration(object sender, EventArgs e)
        {
            if (annealingAlgorithm!.NextIteration())
            {
                MessageBox.Show("Algorithm finished as the temperature reached zero degrees.", "Algorithm finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nextButton.Enabled = false;
                findSolution.Enabled = false;
            }
            temperatureLabel.Text = $"Temp: {annealingAlgorithm.Temperature:F3}";
            resultLabel.Text = $"Result: {annealingAlgorithm.Solution.ToString(true)} ({annealingAlgorithm.Solution.Distance(graph!, true)})";
            RedrawGraph();
        }

        private void RedrawGraph()
        {
            graphics.Clear(graphPictureBox.BackColor);
            graph!.Draw(graphics);
            graph!.DrawPath(graphics, annealingAlgorithm!.Solution, true);
        }
    }
}
