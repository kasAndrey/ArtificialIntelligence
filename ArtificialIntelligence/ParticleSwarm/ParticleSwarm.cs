using GraphicsManagement;
using MathObjects;
using System.Linq;

namespace ArtificialIntelligence.ParticleSwarm
{
    using TestFunction = Func<double, double, double>;

    public class ParticleSwarm
    {
        public class Particle
        {
            Vector velocity;
            public Vector Position;
            public Vector BestPoint;
            const double a1 = 0.2, a2 = 0.33, a3 = 0.95;

            readonly Random randomNumber;

            public Particle(in RectangleF field, in Random seed)
            {
                randomNumber = seed;

                velocity = new(randomNumber.NextDouble() * 2 - 1, randomNumber.NextDouble() * 2 - 1);
                Position = new(field.X + randomNumber.NextDouble() * field.Width, field.Y + randomNumber.NextDouble() * field.Height);
                BestPoint = Position;
            }

            public void GoToNextPoint(Vector overallBestPoint, TestFunction func)
            {
                Position += velocity;

                velocity[0] = a3 * velocity[0] + a1 * randomNumber.NextDouble() * (BestPoint[0] - Position[0]) + a2 * randomNumber.NextDouble() * (overallBestPoint[0] - Position[0]);
                velocity[1] = a3 * velocity[1] + a1 * randomNumber.NextDouble() * (BestPoint[1] - Position[1]) + a2 * randomNumber.NextDouble() * (overallBestPoint[1] - Position[1]);

                if (func(Position[0], Position[1]) < func(BestPoint[0], BestPoint[1]))
                {
                    BestPoint = Position;
                }
            }
        }

        public Particle[] Particles;
        public TestFunction F;
        Vector globalBestPoint;

        readonly Random rand;

        public ParticleSwarm(int particleCount, Function f)
        {
            Particles = new Particle[particleCount];
            F = f.F;

            rand = new();

            for (int i = 0; i < particleCount; i++)
            {
                Particles[i] = new(f.Bounds, rand);
            }

            globalBestPoint = GetBestPoint();
        }

        public Vector FindMinimum()
        {
            Vector previous;
            int sameResults = 0;
            while (sameResults < 5)
            {
                previous = globalBestPoint;
                NextIteration();
                if ((previous - globalBestPoint).SqrMagnitude() < 1e-6) ++sameResults;
                else sameResults = 0;
            }

            return globalBestPoint;
        }

        public Vector NextIteration()
        {
            foreach (Particle p in Particles) p.GoToNextPoint(globalBestPoint, F);
            return globalBestPoint = GetBestPoint();
        }

        private Vector GetBestPoint() => Particles.MinBy((Particle p) => F(p.BestPoint[0], p.BestPoint[1]))!.BestPoint;
    }
}
