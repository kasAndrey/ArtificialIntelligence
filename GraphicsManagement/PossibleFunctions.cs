namespace GraphicsManagement
{
    public static class PossibleFunctions
    {
        public static readonly Dictionary<string, Function> possibleFunctions = new()
        {
            { "Function 1", new Function(
                        (double x, double y) => x * x + 3 * y * y + 2 * x * y,
                        new Rectangle(-6, -7, 15, 15)) },
            { "Function 2", new Function(
                        (double x, double y) => 4 * (x - 5) * (x - 5) + (y - 6) * (y - 6),
                        new Rectangle(-13, -5, 30, 25)) },
            { "Function 3", new Function(
                        (double x, double y) => (x - 2) * (x - 2) * (x - 2) * (x - 2) + (x - 2 * y) * (x - 2 * y),
                        new Rectangle(-24, -37, 64, 82)) },
            { "Function 4", new Function(
                        (double x, double y) => 8 * x * x + 4 * x * y + 5 * y * y,
                        new Rectangle(-8, -11, 15, 20)) },
            { "Function 5", new Function(
                        (double x, double y) => (y - x * x) * (y - x * x) + (1 - x) * (1 - x),
                        new Rectangle(-27, -23, 49, 57)) },
        };
    }
}
