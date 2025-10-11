using ArtificialIntelligence.Misc;
using GraphicsManagement;
using MathObjects;

namespace ArtificialIntelligence.BeeColony
{
    public partial class BeeColonyForm : Form, IBoundable
    {
        BeeColonyOptimization? bco;
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

        public BeeColonyForm()
        {
            InitializeComponent();
            graphics = plot.CreateGraphics();
            functions.Items.Clear();
            functions.Items.AddRange(possibleFunctions.Keys.ToArray());
            functions.SelectedIndex = 0;

            SetFunction(this, new EventArgs());

            boundsButton.Click += (object? sender, EventArgs e) => new Bounds(ref f!.Bounds, this).Show();
        }

        private void FindMinimumValue(object? sender, EventArgs e)
        {
            if (simulationStarted) Stop(sender, e);

            graphics.Clear(Color.White);
            graphics.DrawImage(functionPlot, 0, 0, plot.Width, plot.Height);

            bco = new((int)beesCount.Value, f);
            Vector result = bco.FindMinimum((int)iterationsValue.Value);
            resultLabel.Text = $"Result: f({result[0]:F3}, {result[1]:F3}) = {f.F(result[0], result[1]):F3}";

            Plotter.DrawPoint(graphics, (PointF)result, f.Bounds, plot.Size);
        }

        private void Start(object? sender, EventArgs e)
        {
            simulationStarted = true;
            startButton.Text = "Stop Simulation";
            startButton.Click -= Start;
            startButton.Click += Stop;
            graphics = plot.CreateGraphics();
            StartSimulation();
        }

        private void Stop(object? sender, EventArgs e)
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
                bco = new BeeColonyOptimization((int)beesCount.Value, f);
                while (simulationStarted)
                {
                    minimum = bco.NextIteration();

                    g.Clear(Color.Transparent);
                    
                    /*
                     * Code for drawing simulation
                     */

                    graphics.DrawImage(functionPlot, 0, 0, plot.Width, plot.Height);
                    graphics.DrawImage(image, 0, 0, plot.Width, plot.Height);

                    Thread.Sleep(50);
                }
            });

            resultLabel.Text = $"Result: f({minimum[0]:F3}, {minimum[1]:F3}) = {f.F(minimum[0], minimum[1]):F3}";
        }

        private void SetFunction(object? sender, EventArgs e)
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

        public void SetFunctionBounds(RectangleF newBnd)
        {
            f.Bounds = newBnd;
            functionPlot = Plotter.DrawFunction(f, 75);
            plot.Image = functionPlot;
        }
    }
}
