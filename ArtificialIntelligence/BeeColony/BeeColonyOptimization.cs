using GraphicsManagement;
using MathObjects;

namespace ArtificialIntelligence.BeeColony
{
    public class BeeColonyOptimization
    {
        private Bee[] bees;
        public Function F;
        Bee globalBestBee;

        double initialTemperature;
        double scoutsRatio;

        readonly Random rand;

        public BeeColonyOptimization(int beesCount, double initialTemperature, double scoutsRatio, Function f)
        {
            bees = new Bee[beesCount];
            F = f;
            rand = new();
            this.initialTemperature = initialTemperature;
            this.scoutsRatio = scoutsRatio;

            for (int i = 0; i < beesCount; ++i)
            {
                bees[i] = new Bee(F, rand);
            }

            globalBestBee = GetBestBee();
        }

        public Vector NextIteration()
        {
            // Defining worker bees by simulated annealing
            List<Bee> workerBees = new();
            double bestFitness = globalBestBee.GetFitness();
            double currentTemperature = initialTemperature;
            foreach (Bee b in bees)
            {
                if (Math.Exp((b.GetFitness() - bestFitness) / currentTemperature) > rand.NextDouble())
                {
                    workerBees.Add(b);
                }
                currentTemperature *= 0.9;
            }

            // Generating new bees population
            List<Bee> newBees = new();
            foreach (Bee b in workerBees)
            {
                double a1 = 2 * rand.NextDouble() - 1;
                newBees.Add(new(F, b.Position + a1 * (b.Position - globalBestBee.Position)));
                double a2 = 2 * rand.NextDouble() - 1;
                newBees.Add(new(F, globalBestBee.Position + a2 * (b.Position - globalBestBee.Position)));
            }

            workerBees.AddRange(newBees);
            workerBees.Sort((Bee b1, Bee b2) =>
            {
                double f1 = b1.GetFitness(), f2 = b2.GetFitness();
                if (f1 > f2) return -1;
                else if (f1 < f2) return 1;
                else return 0;
            });

            globalBestBee = workerBees.First();

            int initialPopulation = bees.Length;
            List<Bee> newPopulation = new(initialPopulation);
            for (int i = 0; i < initialPopulation * scoutsRatio; ++i)
            {
                newPopulation.Add(new(F, rand));
            }
            newPopulation.AddRange(workerBees.Take(initialPopulation - newPopulation.Count));
            bees = newPopulation.ToArray();
            rand.Shuffle(bees);

            return globalBestBee.Position;
        }

        public Vector FindMinimum(int maxIterations)
        {
            Vector previous;
            uint sameResults = 0;
            for (int i = 0; i < maxIterations && sameResults < 5; ++i)
            {
                previous = globalBestBee.Position;
                NextIteration();
                if ((previous - globalBestBee.Position).SqrMagnitude() < 1e-6) ++sameResults;
                else sameResults = 0;
            }

            return globalBestBee.Position;
        }

        private Bee GetBestBee() => bees.MaxBy((Bee b) => b.GetFitness())!;

        public (Vector position, Color color, float scale)[] GetBeesInformation()
        {
            return bees.Select((Bee b) => (
                b.Position,
                b == globalBestBee ? Color.Red : Color.White,
                b == globalBestBee ? 2.5f : 1f
                )
            ).ToArray();
        }
    }
}
