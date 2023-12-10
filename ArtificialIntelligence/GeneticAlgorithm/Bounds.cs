namespace ArtificialIntelligence.GeneticAlgorithm
{
    public partial class Bounds : Form
    {
        private GeneticAlgorithmForm wnd;

        public Bounds(ref RectangleF initial, in GeneticAlgorithmForm mw)
        {
            wnd = mw;
            InitializeComponent();

            cornerXNumeric.Value = (decimal)initial.Left;
            cornerYNumeric.Value = (decimal)initial.Top;
            widthNumeric.Value = (decimal)initial.Width;
            heightNumeric.Value = (decimal)initial.Height;
        }

        private void SaveValuesAndClose(object sender, EventArgs e)
        {
            wnd.SetFunctionBounds(new RectangleF((float)cornerXNumeric.Value, (float)cornerYNumeric.Value, (float)widthNumeric.Value, (float)heightNumeric.Value));
            Close();
            Dispose();
        }
    }
}
