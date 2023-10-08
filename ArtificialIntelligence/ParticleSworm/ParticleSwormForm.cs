using ArtificialIntelligence.MathObjects;
namespace ArtificialIntelligence.ParticleSworm
{
    public partial class ParticleSwormForm : Form
    {
        ParticleSworm? ps;
        Function f;
        const string pathToImages = @"..\..\..\ParticleSworm\Functions\";
        const string imagesExtension = ".jpg";

        Image functionPlot;
        Graphics graphics;
        bool simulationStarted;

        public ParticleSwormForm()
        {
            InitializeComponent();
            Plotter.ColorPallete = new List<Color>() { Color.LightGreen, Color.Yellow, Color.Red, Color.Pink, Color.White };
            graphics = plot.CreateGraphics();
            SetFunction(this, new EventArgs());
        }

        private void FindMinimumValue(object sender, EventArgs e)
        {
            if (simulationStarted) Stop(sender, e);

            graphics.Clear(Color.White);
            graphics.DrawImage(functionPlot, 0, 0, plot.Width, plot.Height);

            ps = new((int)particleCount.Value, f);
            Vector result = ps.FindMinimum();
            resultLabel.Text = $"Result: f({result[0]:F3}, {result[1]:F3}) = {f.F(result[0], result[1]):F3}";

            DrawPoint(result, graphics);
        }

        private void DrawPoint(Vector p, in Graphics g, int size = 20)
        {
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
                ps = new((int)particleCount.Value, f);
                while (simulationStarted)
                {
                    minimum = ps.NextIteration();

                    g.Clear(Color.Transparent);
                    foreach (ParticleSworm.Particle p in ps.Particles) DrawPoint(p.Position, g, 8);

                    graphics.DrawImage(functionPlot, 0, 0, plot.Width, plot.Height);
                    graphics.DrawImage(image, 0, 0, plot.Width, plot.Height);

                    Thread.Sleep(50);
                }
            });

            resultLabel.Text = $"Result: f({minimum[0]:F3}, {minimum[1]:F3}) = {f.F(minimum[0], minimum[1]):F3}";
        }

        private void SetFunction(object sender, EventArgs e)
        {
            f = functions.Text switch
            {
                "Function 1" => new Function(
                        (double x, double y) => x * x + 3 * y * y + 2 * x * y,
                        new Rectangle(-6, -7, 15, 15)
                    ),
                "Function 2" => new Function(
                        (double x, double y) => 4 * (x - 5) * (x - 5) + (y - 6) * (y - 6),
                        new Rectangle(-13, -5, 30, 25)
                    ),
                "Function 3" => new Function(
                        (double x, double y) => (x - 2) * (x - 2) * (x - 2) * (x - 2) + (x - 2 * y) * (x - 2 * y),
                        new Rectangle(-34, -57, 74, 102)
                    ),
                _ => f
            };

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
