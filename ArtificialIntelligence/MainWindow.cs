using ArtificialIntelligence.Hamming;
using ArtificialIntelligence.AntColony;
using ArtificialIntelligence.ParticleSworm;
using ArtificialIntelligence.GenericAlgorithm;

namespace ArtificialIntelligence
{
    public partial class MainWindow : Form
    {
        private Dictionary<string, Form> allForms = new();

        public MainWindow()
        {
            InitializeComponent();

            CreateNewForm("Hamming Neural Network", new HammingForm());
            CreateNewForm("Ant Colony Optimization", new AntColonyForm());
            CreateNewForm("Particle Sworm", new ParticleSwormForm());
            CreateNewForm("Genetic Algorithm", new GeneticAlgorithmForm());
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
                Tag = description,
                Size = new Size(150, 50)
            };
            btn.Click += ShowFormInContainer;

            buttonsPanel.Controls.Add(btn);
        }

        private void ShowFormInContainer(object sender, EventArgs e)
        {
            ContainerForForms.Controls.Clear();

            string description = (sender as Button)!.Text;

            ContainerForForms.Text = description;
            ContainerForForms.Controls.Add(allForms[description]);
        }
    }
}