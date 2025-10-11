using ArtificialIntelligence.Hamming;
using ArtificialIntelligence.AntColony;
using ArtificialIntelligence.ParticleSworm;
using ArtificialIntelligence.GeneticAlgorithm;
using ArtificialIntelligence.SimulatedAnnealing;
using ArtificialIntelligence.HebbianLearningRule;
using ArtificialIntelligence.DataMining;
using ArtificialIntelligence.FuzzyLogic;
using ArtificialIntelligence.BeeColony;
using GraphicsManagement;

namespace ArtificialIntelligence
{
    public partial class MainWindow : Form
    {
        private Button? currentFormButton;

        private readonly Dictionary<string, Form> allForms = new()
        {
            { "Hamming Neural Network", new HammingForm() },
            { "Ant Colony Optimization", new AntColonyForm() },
            { "Particle Sworm", new ParticleSwormForm() },
            { "Genetic Algorithm", new GeneticAlgorithmForm() },
            { "Simulated Annealing", new SimulatedAnnealingForm() },
            { "Hebbian Learning Rule", new HebbianNNForm() },
            { "Data mining", new DataMiningForm() },
            { "Fuzzy logic", new FuzzyLogicForm() },
            { "Bee Colony Optimization", new BeeColonyForm() },
        };

        public MainWindow()
        {
            InitializeComponent();

            foreach (var (key, value) in allForms)
            {
                AddNewForm(key, value);
            }
        }

        private void AddNewForm(string description, Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Visible = true;

            Button btn = new()
            {
                Text = description,
                Size = new Size(150, buttonsPanel.Height - 25)
            };
            btn.Click += ShowFormInContainer;

            buttonsPanel.Controls.Add(btn);
        }

        private void ShowFormInContainer(object? sender, EventArgs e)
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