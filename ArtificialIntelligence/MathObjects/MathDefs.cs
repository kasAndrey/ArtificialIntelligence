namespace ArtificialIntelligence.MathObjects
{
    static class MathDefs
    {
        public static double DegToRad(double degrees) => degrees * Math.PI / 180;

        public static Vector Rotate2(Vector vec, double angle)
        {
            if (vec.Count != 2) throw new ArgumentException($"Vector has invalid dimension ({vec.Count} != 2)");
            return new(vec[0] * Math.Cos(angle) - vec[1] * Math.Sin(angle), vec[0] * Math.Sin(angle) + vec[1] * Math.Cos(angle));
        }
    }
}
