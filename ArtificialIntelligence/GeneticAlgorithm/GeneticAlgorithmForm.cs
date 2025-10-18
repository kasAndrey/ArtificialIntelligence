using GraphicsManagement;
using MathObjects;
using ArtificialIntelligence.Misc;
using static GraphicsManagement.PossibleFunctions;

namespace ArtificialIntelligence.GeneticAlgorithm
{
    public partial class GeneticAlgorithmForm : Form, IBoundable
    {
        GeneticAlgorithm? ga;
        EntityCodingType codingType;
        Function f;
        const string pathToImages = @"..\..\..\Resources\Functions\";
        const string imagesExtension = ".jpg";

        Image functionPlot;
        Graphics graphics;
        bool simulationStarted;

        public GeneticAlgorithmForm()
        {
            InitializeComponent();
            graphics = plot.CreateGraphics();
            functions.Items.Clear();
            functions.Items.AddRange(possibleFunctions.Keys.ToArray());

            codingTypeComboBox.Items.Clear();
            codingTypeComboBox.Items.AddRange(Enum.GetNames(typeof(EntityCodingType)));
            SetFunction(this, new EventArgs());

            boundsButton.Click += (object? sender, EventArgs e) => new Bounds(ref f!.Bounds, this).Show();
        }

        private void FindMinimumValue(object sender, EventArgs e)
        {
            if (simulationStarted) Stop(sender, e);

            graphics.Clear(Color.White);
            graphics.DrawImage(functionPlot, 0, 0, plot.Width, plot.Height);

            ga = new((int)generationEntitiesCount.Value, f, codingType, (double)crossingoverPossibility.Value, (int)iterationsValue.Value, (double)mutationPossibility.Value);
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

        private void Start(object? sender, EventArgs e)
        {
            simulationStarted = true;
            foreach (Control c in Controls) c.Enabled = false;
            startButton.Enabled = true;
            startButton.Text = "Stop Simulation";
            startButton.Click -= Start;
            startButton.Click += Stop;
            graphics = plot.CreateGraphics();
            StartSimulation();
        }

        private void Stop(object? sender, EventArgs e)
        {
            foreach (Control c in Controls) c.Enabled = true;
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
                ga = new((int)generationEntitiesCount.Value, f, codingType, (double)crossingoverPossibility.Value, (int)iterationsValue.Value, (double)mutationPossibility.Value);
                while (simulationStarted)
                {
                    minimum = ga.NextGeneration();

                    g.Clear(Color.Transparent);
                    foreach (Entity e in ga.Entities) DrawPoint(e.GeneCoding.RealPosition(ref f.Bounds), g, 8);

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

        private void SetCodingType(object sender, EventArgs e)
        {
            codingType = (EntityCodingType)Enum.Parse(typeof(EntityCodingType), codingTypeComboBox.Text);
        }

        public void SetFunctionBounds(RectangleF newBnd)
        {
            f.Bounds = newBnd;
            functionPlot = Plotter.DrawFunction(f, 75);
            plot.Image = functionPlot;
        }
    }
}
