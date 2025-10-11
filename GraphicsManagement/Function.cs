namespace GraphicsManagement
{
    using TestFunction = Func<double, double, double>;

    public class Function
    {
        public TestFunction F;
        public RectangleF Bounds;

        public Function(TestFunction f, RectangleF bounds)
        {
            F = f;
            Bounds = bounds;
        }
    }
}
