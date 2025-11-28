using ArtificialIntelligence.Misc;
using GraphicsManagement;
using MathObjects;
using static GraphicsManagement.PossibleFunctions;

namespace ArtificialIntelligence.ParticleSwarm
{
    public partial class ParticleSwarmForm : Form, IBoundable
    {
        ParticleSwarm? ps;
        Function f;
        const string pathToImages = @"..\..\..\Resources\Functions\";
        const string imagesExtension = ".jpg";

        Image functionPlot;
        Graphics graphics;
        bool simulationStarted;


        public ParticleSwarmForm()
        {
            InitializeComponent();
            graphics = plot.CreateGraphics();
            functions.Items.Clear();
            functions.Items.AddRange(possibleFunctions.Keys.ToArray());
            SetFunction(this, new EventArgs());
            
            boundsButton.Click += (object? sender, EventArgs e) => new Bounds(ref f!.Bounds, this).Show();
        }

        private void FindMinimumValue(object sender, EventArgs e)
        {
            if (simulationStarted) Stop(sender, e);

            graphics.Clear(Color.White);
            graphics.DrawImage(functionPlot, 0, 0, plot.Width, plot.Height);

            ps = new((int)particleCount.Value, f);
            Vector result = ps.FindMinimum();
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
                ps = new((int)particleCount.Value, f);
                while (simulationStarted)
                {
                    minimum = ps.NextIteration();

                    g.Clear(Color.Transparent);
                    foreach (ParticleSwarm.Particle p in ps.Particles)
                    {
                        Plotter.DrawPoint(g, (PointF)p.Position, f.Bounds, plot.Size, 8);
                    }

                    graphics.DrawImage(functionPlot, 0, 0, plot.Width, plot.Height);
                    graphics.DrawImage(image, 0, 0, plot.Width, plot.Height);

                    Thread.Sleep(50);
                }
            });

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

        public void SetFunctionBounds(RectangleF newBnd)
        {
            f.Bounds = newBnd;
            functionPlot = Plotter.DrawFunction(f, 75);
            plot.Image = functionPlot;
        }
    }
}
