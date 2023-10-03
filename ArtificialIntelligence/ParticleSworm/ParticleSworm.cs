
using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.ParticleSworm
{
    using Func2Dim = Func<double, double, double>;

    public class ParticleSworm
    {
        public class Particle
        {
            Vector velocity;
            Vector position;
            public Vector BestPoint;
            const double a1 = 1, a2 = 1;

            readonly Random randomNumber;

            public Particle()
            {
                randomNumber = new();

                velocity = new(randomNumber.NextDouble(), randomNumber.NextDouble());
                position = new(randomNumber.NextDouble(), randomNumber.NextDouble());
                BestPoint = position;
            }

            public void GoToNextPoint(Vector overallBestPoint, Func2Dim func)
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

        public ParticleSworm(int particleCount)
        {
            particleSworm = new Particle[particleCount];
            globalBestPoint = new Vector(-10.0, -10.0);

            for (int i = 0; i < particleCount; i++)
            {
                particleSworm[i] = new();
            }
        }

        public Vector FindMinimum(Func2Dim function)
        {
            double difference = double.PositiveInfinity;
            int k = 0;
            while (difference > 1e-2 && k < 1000)
            {
                foreach (Particle p in particleSworm)
                {
                    p.GoToNextPoint(globalBestPoint, function);
                }

                foreach (Particle p in particleSworm)
                {
                    double fbp = function(p.BestPoint[0], p.BestPoint[1]), fgbp = function(globalBestPoint[0], globalBestPoint[1]);
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
