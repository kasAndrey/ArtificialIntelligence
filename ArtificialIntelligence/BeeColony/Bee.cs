using MathObjects;
using GraphicsManagement;

namespace ArtificialIntelligence.BeeColony
{
    internal class Bee
    {
        private Vector pos;

        public Vector Position
        {
            get { return pos; }
            set
            {
                pos = new(2);
                pos[0] = Math.Clamp(value[0], f.Bounds.Left, f.Bounds.Left + f.Bounds.Width);
                pos[1] = Math.Clamp(value[1], f.Bounds.Top, f.Bounds.Top + f.Bounds.Height);
            }
        }
        Function f;

        public Bee(in Function f, in Random rand)
        {
            this.f = f;
            pos = new(2);
            pos[0] = f.Bounds.Left + rand.NextDouble() * f.Bounds.Width;
            pos[1] = f.Bounds.Top + rand.NextDouble() * f.Bounds.Height;
        }

        public Bee(in Function f, Vector pos)
        {
            this.f = f;
            this.pos = new(2);
            Position = pos;
        }

        public double GetFitness() => -f.F(Position[0], Position[1]);
    }
}
