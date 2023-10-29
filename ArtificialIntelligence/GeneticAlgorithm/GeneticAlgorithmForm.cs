﻿using ArtificialIntelligence.GraphicsMGMT;
using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.GeneticAlgorithm
{
    public partial class GeneticAlgorithmForm : Form
    {
        GeneticAlgorithm? ga;
        Function f;
        const string pathToImages = @"..\..\..\Resources\Functions\";
        const string imagesExtension = ".jpg";

        readonly Dictionary<string, Function> possibleFunctions = new()
        {
            { "Function 1", new Function(
                        (double x, double y) => x * x + 3 * y * y + 2 * x * y,
                        new Rectangle(-6, -7, 15, 15)) },
            { "Function 2", new Function(
                        (double x, double y) => 4 * (x - 5) * (x - 5) + (y - 6) * (y - 6),
                        new Rectangle(-13, -5, 30, 25)) },
            { "Function 3", new Function(
                        (double x, double y) => (x - 2) * (x - 2) * (x - 2) * (x - 2) + (x - 2 * y) * (x - 2 * y),
                        new Rectangle(-24, -37, 64, 82)) },
            { "Function 4", new Function(
                        (double x, double y) => 8 * x * x + 4 * x * y + 5 * y * y,
                        new Rectangle(-8, -11, 15, 20)) },
            { "Function 5", new Function(
                        (double x, double y) => (y - x * x) * (y - x * x) + (1 - x) * (1 - x),
                        new Rectangle(-27, -23, 49, 57)) },
        };

        Image functionPlot;
        Graphics graphics;
        bool simulationStarted;

        public GeneticAlgorithmForm()
        {
            InitializeComponent();
            Plotter.ColorPallete = new List<Color>() { Color.LimeGreen, Color.LightGreen, Color.Yellow, Color.Red, Color.Pink, Color.White };
            graphics = plot.CreateGraphics();
            functions.Items.Clear();
            functions.Items.AddRange(possibleFunctions.Keys.ToArray());
            SetFunction(this, new EventArgs());
        }

        private void FindMinimumValue(object sender, EventArgs e)
        {
            if (simulationStarted) Stop(sender, e);

            graphics.Clear(Color.White);
            graphics.DrawImage(functionPlot, 0, 0, plot.Width, plot.Height);

            ga = new((int)generationEntitiesCount.Value, f, (double)crossingoverPossibility.Value, (double)mutationPossibility.Value, spawnOption.Checked);
            Vector result = ga.FindMinimum();
            resultLabel.Text = $"Result: f({result[0]:F3}, {result[1]:F3}) = {f.F(result[0], result[1]):F3}";

            DrawPoint(result, graphics);
        }

        private void DrawPoint(Vector p, in Graphics g, int size = 20)
        {
            //graphics = plot.CreateGraphics();
            Vector realPos = new((p[0] - f.Bounds.X) * plot.Width / f.Bounds.Width, (p[1] - f.Bounds.Y) * plot.Height / f.Bounds.Height);
            g.FillEllipse(new SolidBrush(Color.White), (int)realPos[0] - size / 2, (int)realPos[1] - size / 2, size, size);
            g.DrawEllipse(new Pen(Color.Black), (int)realPos[0] - size / 2, (int)realPos[1] - size / 2, size, size);
        }

        private void Start(object sender, EventArgs e)
        {
            simulationStarted = true;
            startButton.Text = "Stop Simulation";
            startButton.Click -= Start;
            startButton.Click += Stop;
            graphics = plot.CreateGraphics();
            StartSimulation();
        }

        private void Stop(object sender, EventArgs e)
        {
            simulationStarted = false;
            startButton.Text = "Start Simulation";
            startButton.Click -= Stop;
            startButton.Click += Start;
        }

        private async void StartSimulation()
        {
            Image image = new Bitmap(plot.Width, plot.Height);
            Graphics g = Graphics.FromImage(image);

            Vector minimum = new(2);
            await Task.Run(() =>
            {
                ga = new((int)generationEntitiesCount.Value, f, (double)crossingoverPossibility.Value, (double)mutationPossibility.Value, spawnOption.Checked);
                while (simulationStarted)
                {
                    minimum = ga.NextGeneration();

                    g.Clear(Color.Transparent);
                    foreach (GeneticAlgorithm.Entity e in ga.Entities) DrawPoint(e.RealPosition(ref f.Bounds), g, 8);

                    graphics.DrawImage(functionPlot, 0, 0, plot.Width, plot.Height);
                    graphics.DrawImage(image, 0, 0, plot.Width, plot.Height);

                    Thread.Sleep(250);
                    if (ga.Entities.Count < 2)
                    {
                        MessageBox.Show("Simulation ended: one entity left", "Simulation ended", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            });

            if (simulationStarted) Stop(this, EventArgs.Empty);
            resultLabel.Text = $"Result: f({minimum[0]:F3}, {minimum[1]:F3}) = {f.F(minimum[0], minimum[1]):F3}";
        }

        private void SetFunction(object sender, EventArgs e)
        {
            f = possibleFunctions[functions.Text];

            try
            {
                formulaImage.Image = Image.FromFile(pathToImages + functions.Text + imagesExtension);
            }
            catch { }

            functionPlot = Plotter.DrawFunction(f, 75);

            plot.Image = functionPlot;
        }
    }
}
