using ArtificialIntelligence.GraphicsMGMT;
using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.SimulatedAnnealing
{
    public class SimulatedAnnealing
    {
        public double Temperature;
        public GraphPath Solution;
        private Graph graph;
        private Random rnd;
        public GraphPath BestSolution;

        public SimulatedAnnealing(Graph graph, in Random randomValue)
        {
            this.graph = graph;
            Temperature = 125;
            rnd = randomValue;
            Solution = new GraphPath();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Solution.Add(i);
            }

            BestSolution = Solution;

            for (int i = 1; i < Solution.Count; i++)
            {
                int t = Solution[i];
                int k = rnd.Next(1, Solution.Count);
                Solution[i] = Solution[k];
                Solution[k] = t;
            }
        }

        public void FindSolution()
        {
            while (!NextIteration());
        }

        public bool NextIteration()
        {
            ChangeTemperature(0.97);
            GraphPath newPath = Mutate();
            double dE = newPath.Distance(graph, true) - Solution.Distance(graph, true);
            if (dE < 0 || rnd.NextDouble() < Math.Exp(-dE / Temperature))
            {
                Solution = newPath;
            }

            if (dE < 0) BestSolution = new GraphPath (Solution);

            return Temperature <= 0;
        }

        private void ChangeTemperature(double a1 = 1, double a0 = 1)
        {
            Temperature = a1 * Temperature - a0;
            if (Temperature < 0) Temperature = 0;
        }

        private GraphPath Mutate()
        {
            GraphPath newPath = new (Solution);
            for (int i = 1; i < newPath.Count; i++)
            {
                int t = newPath[i];
                int k = rnd.Next(1, newPath.Count);
                newPath[i] = newPath[k];
                newPath[k] = t;
            }

            return newPath;
        }
    }
}
