namespace ArtificialIntelligence.GraphicsMGMT
{
    public class Function
    {
        public Func<double, double, double> F;
        public RectangleF Bounds;

        public Function(Func<double, double, double> f, RectangleF bounds)
        {
            F = f;
            Bounds = bounds;
        }
    }
}
