using System.ComponentModel;

namespace ArtificialIntelligence.AntColony
{
    public partial class AntColonyForm : Form
    {
        private AntColonyOptimization? aco;
        private DisplayableGraph? graph;

        private Graphics graphics;

        public AntColonyForm()
        {
            InitializeComponent();
            aco = null;
            graph = null;

            loadGraphButton.Click += (object sender, EventArgs e) => { ogfd.ShowDialog(); };

            ogfd.InitialDirectory = new DirectoryInfo(GraphParser.GraphsDirectory).FullName;
        }

        private void NextAnt(object sender, EventArgs e)
        {
            graphics.Clear(graphPictureBox.BackColor);
            DisplayableGraphPath vertexes = new (graph!.Vertices);
            vertexes.LoadPath(aco!.NextAnt());
            resultLabel.Text = $"Result: {aco.LastResult} (last), {aco.BestResult} (best)";

            graph!.Draw(graphics);
            graph!.DrawPath(graphics, vertexes, true);

            if (aco.SamePaths >= (int)maxRepeatsNumeric.Value)
            {
                MessageBox.Show($"Optimal solution found: {vertexes.ToString(true)} ({aco.LastResult})", "Solution found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetState(false);
            }
        }

        private void InitializeACO(object sender, EventArgs e)
        {
            SetState(true);

            aco = new AntColonyOptimization(
                graph!,
                (double)alphaNumeric.Value,
                (double)betaNumeric.Value,
                (double)evapNumeric.Value,
                (double)pherStrengthNumeric.Value
                );
            graphics.Clear(graphPictureBox.BackColor);
            graph!.Draw(graphics);
        }

        private void StopACO(object sender, EventArgs e)
        {
            SetState(false);
        }

        private void SetState(bool state)
        {
            if (state)
            {
                startStopButton.Tag = "Stop";
                startStopButton.Text = "Stop";
                startStopButton.Click -= InitializeACO;
                startStopButton.Click += StopACO;
            }
            else
            {
                startStopButton.Tag = "Start";
                startStopButton.Text = "Start";
                startStopButton.Click -= StopACO;
                startStopButton.Click += InitializeACO;
            }

            alphaTrackBar.Enabled = !state;
            betaTrackBar.Enabled = !state;
            pherStrengthTrackBar.Enabled = !state;
            evapTrackBar.Enabled = !state;

            alphaNumeric.Enabled = !state;
            betaNumeric.Enabled = !state;
            pherStrengthNumeric.Enabled = !state;
            evapNumeric.Enabled = !state;

            nextAntButton.Visible = state;
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            Control currentControl = (sender as Control)!;

            if (currentControl.Name.StartsWith("alpha"))
            {
                if (currentControl is TrackBar)
                {
                    alphaNumeric.Value = (decimal)((sender as TrackBar)!.Value / 100.0);
                }
                else if (currentControl is NumericUpDown)
                {
                    alphaTrackBar.Value = (int)((sender as NumericUpDown)!.Value * 100);
                }
            }

            if (currentControl.Name.StartsWith("beta"))
            {
                if (currentControl is TrackBar)
                {
                    betaNumeric.Value = (decimal)((sender as TrackBar)!.Value / 100.0);
                }
                else if (currentControl is NumericUpDown)
                {
                    betaTrackBar.Value = (int)((sender as NumericUpDown)!.Value * 100);
                }
            }

            if (currentControl.Name.StartsWith("evap"))
            {
                if (currentControl is TrackBar)
                {
                    evapNumeric.Value = (decimal)((sender as TrackBar)!.Value / 100.0);
                }
                else if (currentControl is NumericUpDown)
                {
                    evapTrackBar.Value = (int)((sender as NumericUpDown)!.Value * 100);
                }
            }

            if (currentControl.Name.StartsWith("pherStrength"))
            {
                if (currentControl is TrackBar)
                {
                    pherStrengthNumeric.Value = (decimal)((sender as TrackBar)!.Value / 100.0);
                }
                else if (currentControl is NumericUpDown)
                {
                    pherStrengthTrackBar.Value = (int)((sender as NumericUpDown)!.Value * 100);
                }
            }
        }

        private void OnFileSelected(object sender, CancelEventArgs e)
        {
            try
            {
                graph = GraphParser.Load(ogfd.FileName);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            graphics = graphPictureBox.CreateGraphics();
            graph!.FixGraphics(graphics, graphPictureBox.Bounds);
            graph!.Draw(graphics);

            SetState(false);
            startStopButton.Enabled = true;
        }
    }
}
