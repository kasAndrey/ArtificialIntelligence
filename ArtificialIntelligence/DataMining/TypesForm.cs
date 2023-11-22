namespace ArtificialIntelligence.DataMining
{
    public partial class TypesForm : Form
    {
        private readonly Size controlSize = new(200, 32);
        private DataMiningStructure dm;

        public TypesForm(in DataMiningStructure dm)
        {
            InitializeComponent();

            this.dm = dm;
            TopMost = true;
            Size = new(2 * controlSize.Width + 40, controlSize.Height * (dm.Headers.Length + 3) + 60);
            Text = "Settings Types of Data";

            string[] possibleValues = Enum.GetNames(typeof(DataMiningStructure.DataType));
            for (int i = 0; i < dm.Headers.Length; i++)
            {
                Label label = new()
                {
                    Location = new(5, 5 + controlSize.Height * i),
                    Text = dm.Headers[i],
                    AutoSize = false,
                    Size = controlSize,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top
                };
                Controls.Add(label);

                ComboBox comboBox = new()
                {
                    Location = new(15 + controlSize.Width, 5 + controlSize.Height * i),
                    Size = controlSize,
                    Anchor = AnchorStyles.Right | AnchorStyles.Top,
                    Tag = i
                };
                comboBox.Items.AddRange(possibleValues);
                comboBox.SelectedIndex = 0;

                Controls.Add(comboBox);
            }

            Button applyButton = new()
            {
                Location = new((Size.Width - controlSize.Width) / 2, 15 + controlSize.Height * dm.Headers.Length),
                Size = new(controlSize.Width, 2 * controlSize.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                Text = "Apply"
            };
            applyButton.Click += GetTypes;
            Controls.Add(applyButton);
        }

        private void GetTypes(object sender, EventArgs e)
        {
            DataMiningStructure.DataType[] types = new DataMiningStructure.DataType[dm.Headers.Length];
            foreach (Control c in Controls)
            {
                if (c is ComboBox)
                {
                    types[(int)c.Tag] = (DataMiningStructure.DataType)Enum.Parse(typeof(DataMiningStructure.DataType), c.Text);
                }
            }

            dm.SetTypes(types);
            Close();
            Dispose();
        }
    }
}
