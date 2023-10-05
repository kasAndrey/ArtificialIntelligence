
using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.ParticleSworm
{
    using TestFunction = Func<double, double, double>;

    public class ParticleSworm
    {
        public class Particle
        {
            Vector velocity;
            Vector position;
            public Vector BestPoint;
            const double a1 = 1, a2 = 1;

            readonly Random randomNumber;

            public Particle(ref Rectangle field, ref Random seed)
            {
                randomNumber = seed;

                velocity = new(randomNumber.NextDouble() * field.Width / 10.0, randomNumber.NextDouble() * field.Height / 10.0);
                position = new(field.X + randomNumber.NextDouble() * field.Width, field.Y + randomNumber.NextDouble() * field.Height);
                BestPoint = position;
            }

            public void GoToNextPoint(Vector overallBestPoint, TestFunction func)
            {
                position += velocity;

                velocity[0] += a1 * randomNumber.NextDouble() * (BestPoint[0] - position[0]) + a2 * randomNumber.NextDouble() * (overallBestPoint[0] - position[0]);
                velocity[1] += a1 * randomNumber.NextDouble() * (BestPoint[1] - position[1]) + a2 * randomNumber.NextDouble() * (overallBestPoint[1] - position[1]);

                if (func(position[0], position[1]) < func(BestPoint[0], BestPoint[1]))
                {
                    BestPoint = position;
                }
            }
        }

        Particle[] particleSworm;
        Vector globalBestPoint;

        Random rand;

        public ParticleSworm(int particleCount, Rectangle functionBounds)
        {
            particleSworm = new Particle[particleCount];
            globalBestPoint = new Vector(-10.0, -10.0);

            rand = new();

            for (int i = 0; i < particleCount; i++)
            {
                particleSworm[i] = new(ref functionBounds, ref rand);
            }
        }

        public Vector FindMinimum(TestFunction func)
        {
            if (func is null) throw new ArgumentNullException(nameof(func), "Function is not set");

            double difference = double.PositiveInfinity;
            int k = 0;
            while (difference > 1e-2 && k < 1000)
            {
                foreach (Particle p in particleSworm)
                {
                    p.GoToNextPoint(globalBestPoint, func);
                }

                foreach (Particle p in particleSworm)
                {
                    double fbp = func(p.BestPoint[0], p.BestPoint[1]), fgbp = func(globalBestPoint[0], globalBestPoint[1]);
                    difference = fgbp - fbp;
                    if (difference > 0)
                    {
                        globalBestPoint = p.BestPoint;
                    }
                }
                k++;
            }

            return globalBestPoint;
        }
    }
}
