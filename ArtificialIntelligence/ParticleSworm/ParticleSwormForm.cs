using ArtificialIntelligence.MathObjects;
namespace ArtificialIntelligence.ParticleSworm
{
    public partial class ParticleSwormForm : Form
    {
        ParticleSworm? ps;

        public ParticleSwormForm()
        {
            InitializeComponent();

            startButton.Click += Start;
        }

        private void Start(object sender, EventArgs e)
        {
            ps = new((int)particleCount.Value);
            Vector result = ps.FindMinimum(Function2);
            resultLabel.Text = $"Result: ({result[0]:F3}; {result[1]:F3})";
        }

        private double Function1(double x, double y) => x * x + 3 * y * y + 2 * x * y;
        private double Function2(double x, double y) => 4 * (x - 5) * (x - 5) + (y - 6) * (y - 6);
    }
}
