using System.ComponentModel;

namespace ArtificialIntelligence.DataMining
{
    public partial class DataMiningForm : Form
    {
        private KNearestNeighbors? dataMiningAlgorithm;

        public DataMiningForm()
        {
            InitializeComponent();
            dataList.GridLines = true;
            ofd.InitialDirectory = @"..\..\..\Resources\DataFiles";
            openDataButton.Click += (object sender, EventArgs e) => ofd.ShowDialog();
        }

        private void ChangeNearestNeighborsCount(object sender, EventArgs e) => dataMiningAlgorithm!.NeighborsCount = (int)neighborsCountNumeric.Value;

        private void LoadDataFile(object sender, CancelEventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Does this file contain headers?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                dataMiningAlgorithm = new KNearestNeighbors(ofd.FileName, res == DialogResult.Yes);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillTable();

            neighborsCountNumeric.Enabled = true;
            classifyButton.Enabled = true;

            new TypesForm(dataMiningAlgorithm!).Show();
        }

        private void Classify(object sender, EventArgs e) => new ClassifyForm(dataMiningAlgorithm!).Show();

        private void FillTable()
        {
            dataList.Columns.Clear();
            dataList.Items.Clear();

            ColumnHeader[] headers = new ColumnHeader[dataMiningAlgorithm!.Headers.Length];
            for (int i = 0; i < dataMiningAlgorithm!.Headers.Length; i++)
            {
                headers[i] = new ColumnHeader() { Text = dataMiningAlgorithm!.Headers[i] };
            }
            dataList.Columns.AddRange(headers);

            string[][] data = dataMiningAlgorithm.GetData();
            for (int i = 0; i < data.Length; i++)
            {
                dataList.Items.Add(new ListViewItem(data[i]));
            }

            dataList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
