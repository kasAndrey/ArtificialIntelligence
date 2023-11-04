using ArtificialIntelligence.Hamming;
using ArtificialIntelligence.AntColony;
using ArtificialIntelligence.ParticleSworm;
using ArtificialIntelligence.GeneticAlgorithm;
using ArtificialIntelligence.SimulatedAnnealing;

namespace ArtificialIntelligence
{
    public partial class MainWindow : Form
    {
        private Dictionary<string, Form> allForms = new();
        private Button? currentFormButton;

        public MainWindow()
        {
            InitializeComponent();

            CreateNewForm("Hamming Neural Network", new HammingForm());
            CreateNewForm("Ant Colony Optimization", new AntColonyForm());
            CreateNewForm("Particle Sworm", new ParticleSwormForm());
            CreateNewForm("Genetic Algorithm", new GeneticAlgorithmForm());
            CreateNewForm("Simulated Annealing", new SimulatedAnnealingForm());
            CreateNewForm("Hebbian Learning Rule", new Form());
            CreateNewForm("Fuzzy logic", new Form());
            CreateNewForm("Data mining", new Form());
        }

        private void CreateNewForm(string description, Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Visible = true;

            allForms.Add(description, form);

            Button btn = new()
            {
                Text = description,
                Size = new Size(150, buttonsPanel.Height - 25)
            };
            btn.Click += ShowFormInContainer;

            buttonsPanel.Controls.Add(btn);
        }

        private void ShowFormInContainer(object sender, EventArgs e)
        {
            ContainerForForms.Controls.Clear();

            if (currentFormButton is not null)
            {
                currentFormButton.BackColor = Color.White;
            }

            currentFormButton = (sender as Button)!;
            currentFormButton.BackColor = Color.LightYellow;

            ContainerForForms.Text = currentFormButton.Text;
            ContainerForForms.Controls.Add(allForms[currentFormButton.Text]);
        }
    }
}