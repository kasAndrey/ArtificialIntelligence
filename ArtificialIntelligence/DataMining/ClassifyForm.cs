namespace ArtificialIntelligence.DataMining
{
    public partial class ClassifyForm : Form
    {
        private readonly Size controlSize = new(200, 32);
        private DataMiningStructure dm;

        public ClassifyForm(in DataMiningStructure dm)
        {
            InitializeComponent();

            this.dm = dm;
            TopMost = true;
            Size = new(2 * controlSize.Width + 40, controlSize.Height * (dm.Headers.Length + 3) + 60);
            Text = "Classifying data record";

            for (int i = 0; i < dm.Headers.Length; i++)
            {
                Label label = new()
                {
                    Location = new(5, 5 + controlSize.Height * i),
                    Text = $"{dm.Headers[i]}:",
                    AutoSize = false,
                    Size = controlSize,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top
                };
                Controls.Add(label);

                TextBox textBox = new()
                {
                    Location = new(15 + controlSize.Width, 5 + controlSize.Height * i),
                    Size = controlSize,
                    Anchor = AnchorStyles.Right | AnchorStyles.Top,
                    Tag = i
                };
                Controls.Add(textBox);
            }

            Button applyButton = new()
            {
                Location = new((Size.Width - controlSize.Width) / 2, 15 + controlSize.Height * dm.Headers.Length),
                Size = new(controlSize.Width, 2 * controlSize.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                Text = "Apply"
            };
            applyButton.Click += ClassifyDataRecord;
            Controls.Add(applyButton);
        }

        private void ClassifyDataRecord(object sender, EventArgs e)
        {
            TextBox[] values = new TextBox[dm.Headers.Length];
            string[] strings = new string[values.Length];
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    values[(int)c.Tag] = (c as TextBox)!;
                    strings[(int)c.Tag] = (c as TextBox)!.Text;
                }
            }

            for (int i = 0; i < values.Length; i++)
            {
                if (strings[i] == "")
                {
                    try
                    {
                        strings[i] = values[i].Text = dm.Classify(strings, i);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Value unclassified due to error:\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
        }
    }
}
