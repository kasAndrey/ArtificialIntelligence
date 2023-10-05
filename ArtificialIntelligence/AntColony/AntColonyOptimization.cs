using ArtificialIntelligence.MathObjects;
using System.Reflection;

namespace ArtificialIntelligence.AntColony
{
    public class AntColonyOptimization
    {
        public const double InitialPheromoneLevel = 1;

        private double alpha, beta, evaporationRate, pheromoneStrength;

        private Graph objectsMap;
        private Graph pheromoneMap;

        private GraphPath path;

        private Random rnd;

        public double LastResult, BestResult;

        public int SamePaths;

        public AntColonyOptimization(Graph map, double alpha, double beta, double evaporationRate = 0.27, double pheromoneStrength = 1)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.evaporationRate = evaporationRate;
            this.pheromoneStrength = pheromoneStrength;

            objectsMap = map;
            pheromoneMap = Graph.Empty(map.Rows);
            for (int i = 0; i < pheromoneMap.Rows; i++)
            {
                for (int j = 0; j < pheromoneMap.Columns; j++)
                {
                    pheromoneMap[i, j] = objectsMap[i, j] == double.PositiveInfinity ? double.PositiveInfinity : InitialPheromoneLevel;
                }
            }

            rnd = new();
            path = new();

            SamePaths = 0;
            LastResult = -1;
            BestResult = Graph.NoPath;
        }

        public GraphPath NextAnt()
        {
            path.Clear();
            path.Add(0);
            double result = 0;
            for (int i = 1; path.Count < objectsMap.VertexCount; i++)
            {
                path.Add(NextIteration());
                result += objectsMap[path[i - 1], path[i]];
            }
            result += objectsMap[path.Last(), path[0]];

            SamePaths = LastResult == result ? SamePaths + 1 : 0;

            LastResult = result;
            UpdatePheromoneConcentration(path, LastResult);

            if (LastResult < BestResult) BestResult = LastResult;

            return path;
        }

        private int NextIteration()
        {
            (GraphPath v, Vector p) = NextVertexPossibilites();

            double parameter = 0, randomNumber = rnd.NextDouble(), sum = 0;
            for (int i = 0; i < p.Count; i++) sum += p[i];

            for (int i = 0; i < p.Count; i++)
            {
                if (p[i] == 0) continue;
                parameter += p[i] / sum;

                if (randomNumber <= parameter) return v[i];
            }
            return v[p.Count - 1];
        }

        private (GraphPath, Vector) NextVertexPossibilites()
        {
            int currentVertex = path.Last();

            GraphPath adjecentVertices = objectsMap.AdjecentVerticesToVertex(currentVertex);
            Vector possibilities = new(adjecentVertices.Count);

            for (int v = 0; v < adjecentVertices.Count; v++)
            {
                if (path.Contains(adjecentVertices[v])) possibilities[v] = 0;
                else
                {
                    double sum = 0;
                    for (int u = 0; u < adjecentVertices.Count; u++)
                    {
                        sum += Math.Pow(pheromoneMap[currentVertex, adjecentVertices[u]], alpha) / Math.Pow(objectsMap[currentVertex, adjecentVertices[u]], beta);
                    }
                    possibilities[v] = Math.Pow(pheromoneMap[currentVertex, adjecentVertices[v]], alpha) / Math.Pow(objectsMap[currentVertex, adjecentVertices[v]], beta) / sum;
                }
            }

            return (adjecentVertices, possibilities);
        }

        private void UpdatePheromoneConcentration(GraphPath path, double pathDistance)
        {
            for (int i = 0; i < pheromoneMap.Rows; i++)
            {
                for (int j = 0; j < pheromoneMap.Columns; j++)
                {
                    if (pheromoneMap[i, j] == double.PositiveInfinity) continue;

                    pheromoneMap[i, j] *= 1 - evaporationRate;
                    if (path.ContainPath(i, j)) pheromoneMap[i, j] += pheromoneStrength / pathDistance;
                }
            }
        }
    }
}
