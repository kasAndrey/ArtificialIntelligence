using MathObjects;
using GraphicsManagement;

namespace ArtificialIntelligence.BeeColony
{
    internal interface IBeeBehavior
    {
        void GetHoney();
    }

    internal sealed class BeeBehaviors
    {
        public class ScoutBeeBehavior : IBeeBehavior
        {
            RectangleF bounds;
            readonly Random rnd;
            Vector position;

            public ScoutBeeBehavior(in Vector position, RectangleF bounds, in Random rnd)
            {
                this.position = position;
                this.bounds = bounds;
                this.rnd = rnd;
            }

            public void GetHoney()
            {
                position[0] = rnd.NextDouble() * bounds.Width + bounds.X;
                position[1] = rnd.NextDouble() * bounds.Height + bounds.Y;
            }
        }

        public class WorkingBeeBehavior : IBeeBehavior
        {
            RectangleF bounds;
            readonly Random rnd;
            double searchRadius;
            Vector position;

            public WorkingBeeBehavior(in Vector position, double searchRadius, RectangleF bounds, in Random rnd)
            {
                this.position = position;
                this.searchRadius = searchRadius;
                this.bounds = bounds;
                this.rnd = rnd;
            }

            public void GetHoney()
            {
                double angle = rnd.NextDouble() * Math.PI;
                double r = rnd.NextDouble() * searchRadius;
                position[0] = Math.Clamp(position[0] + r * Math.Cos(angle), bounds.X, bounds.X + bounds.Width);
                position[1] = Math.Clamp(position[1] + r * Math.Sin(angle), bounds.Y, bounds.Y + bounds.Height);
            }
        }

        public class OnlookerBeeBehavior : IBeeBehavior
        {
            readonly Random rnd;
            IEnumerable<Bee> other;

            public OnlookerBeeBehavior(IEnumerable<Bee> other, in Random rnd)
            {
                this.other = other;
                this.rnd = rnd;
            }

            public void GetHoney()
            {
                // Здесь надо как то видимо переманивать других пчел на свой участок для исследования
            }
        }
    }
    internal class Bee
    {
        public Vector Position;
        readonly Random rnd;
        Function f;

        public IBeeBehavior Behavior;

        public Bee(in Function f, in Random rnd)
        {
            Position = new(2);
            this.f = f;
            this.rnd = rnd;

            Behavior = new BeeBehaviors.ScoutBeeBehavior(Position, f.Bounds, rnd);
        }

        public double GetFitness() => f.F(Position[0], Position[1]);
    }
}
