using GraphicsManagement;
using MathObjects;

namespace ArtificialIntelligence.BeeColony
{
    using TestFunction = Func<double, double, double>;

    public class BeeColonyOptimization
    {
        private Bee[] bees;
        public TestFunction F;
        Vector globalBestPoint;

        readonly Random rand;

        public BeeColonyOptimization(int beesCount, Function f)
        {
            bees = new Bee[beesCount];

            F = f.F;
            rand = new();

            for (int i = 0; i < beesCount; ++i)
            {
                bees[i] = new Bee(f, rand);
            }

            globalBestPoint = GetBestPoint();
        }

        public Vector NextIteration()
        {
            return globalBestPoint = new(2);
        }

        public Vector FindMinimum(int maxIterations)
        {
            Vector previous;
            uint sameResults = 0;
            for (int i = 0; i < maxIterations && sameResults < 5; ++i)
            {
                previous = globalBestPoint;
                NextIteration();
                if ((previous - globalBestPoint).SqrMagnitude() < 1e-6) ++sameResults;
                else sameResults = 0;
            }

            return globalBestPoint;
        }

        private Vector GetBestPoint() => bees.MinBy((Bee b) => b.GetFitness())!.Position;
    }
}
