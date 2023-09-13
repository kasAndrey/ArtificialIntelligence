namespace ArtificialIntelligence.MathObjects
{
    public class Vector : Matrix
    {
        public Vector(int length) : base(1, length) { }

        public double this[int i]
        {
            get { return this[1, i]; }
        }
    }
}
