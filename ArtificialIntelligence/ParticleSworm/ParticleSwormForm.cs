using ArtificialIntelligence.MathObjects;
namespace ArtificialIntelligence.ParticleSworm
{
    public partial class ParticleSwormForm : Form
    {
        public class Function
        {
            public Func<double, double, double> F;
            public Rectangle Bounds;

            public Function(Func<double, double, double> f, Rectangle bounds)
            {
                F = f;
                Bounds = bounds;
            }
        }

        ParticleSworm? ps;
        Function f;
        const string pathToImages = @"..\..\..\ParticleSworm\Functions\";
        const string imagesExtension = ".jpg";

        public ParticleSwormForm()
        {
            InitializeComponent();
            SetFunction(this, new EventArgs());
            startButton.Click += Start;
        }

        private void Start(object sender, EventArgs e)
        {
            ps = new((int)particleCount.Value, f.Bounds);
            Vector result = ps.FindMinimum(f.F);
            resultLabel.Text = $"Result: ({result[0]:F3}; {result[1]:F3})";
        }

        private void SetFunction(object sender, EventArgs e)
        {
            f = functions.Text switch
            {
                "Function 1" => new Function(
                        (double x, double y) => x * x + 3 * y * y + 2 * x * y,
                        new Rectangle(-5, -5, 10, 10)
                    ),
                "Function 2" => new Function(
                        (double x, double y) => 4 * (x - 5) * (x - 5) + (y - 6) * (y - 6),
                        new Rectangle(0, 0, 10, 11)
                    ),
                _ => f
            };

            try
            {
                formulaImage.Image = Image.FromFile(pathToImages + functions.Text + imagesExtension);
            }
            catch { }
        }
    }
}
