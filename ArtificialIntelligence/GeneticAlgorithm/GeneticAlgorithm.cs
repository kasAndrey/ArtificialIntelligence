using ArtificialIntelligence.GraphicsMGMT;
using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.GeneticAlgorithm
{
    public class GeneticAlgorithm
    {
        public List<Entity> Entities;
        public double CrossingoverPossibility;
        public int MaxIterations;
        public double MutationPossibility;
        public Vector globalBestPoint;
        public EntityCodingType type;

        private Function f;
        private Random rnd;

        public GeneticAlgorithm(
            int entitiesCount,
            Function f,
            EntityCodingType codingType,
            double crossingoverPossibility = 0.9,
            int maxIterations = 100,
            double mutationPossibility = 0.25
            )
        {
            rnd = new Random();
            Entities = new();
            type = codingType;

            for (int i = 0; i < entitiesCount; i++)
            {
                IEntityGeneCoding coding = type switch
                {
                    EntityCodingType.Binary => new GrayCode((uint)(rnd.NextDouble() * ~0u), (uint)(rnd.NextDouble() * ~0u)),
                    EntityCodingType.Real => new RealGeneCoding(rnd.NextDouble(), rnd.NextDouble()),
                    _ => throw new NotImplementedException()
                };
                Entities.Add(new(coding));
            }

            this.f = f;
            CrossingoverPossibility = crossingoverPossibility;
            MaxIterations = maxIterations;
            MutationPossibility = mutationPossibility;

            globalBestPoint = GetBestPoint();
        }

        public Vector FindMinimum()
        {
            Vector previous;
            int sameResults = 0;
            for (int iter = 0; sameResults < 5 && Entities.Count > 1 && iter < MaxIterations; ++iter)
            {
                previous = globalBestPoint;
                NextGeneration();
                if ((previous - globalBestPoint).SqrMagnitude() < 1e-3) sameResults++;
                else sameResults = 0;
            }

            return globalBestPoint;
        }

        public Vector NextGeneration()
        {
            Crossingover();
            foreach (Entity e in Entities)
            {
                if (rnd.NextDouble() < MutationPossibility) e.GeneCoding.Mutate(ref rnd);
            }
            return globalBestPoint = GetBestPoint();
        }

        private void Crossingover()
        {
            int initialCount = Entities.Count;

            for (int i = 0; i < initialCount; i++)
            {
                if (rnd.NextDouble() < CrossingoverPossibility)
                {
                    int index = rnd.Next(initialCount);
                    if (i == index) continue;

                    Entities.Add(new(Entities[i].GeneCoding.CrossingoverWith(Entities[index].GeneCoding, ref rnd)));
                }
            }

            Entities.Sort((Entity e1, Entity e2) => {
                Vector p1 = e1.GeneCoding.RealPosition(ref f.Bounds);
                Vector p2 = e2.GeneCoding.RealPosition(ref f.Bounds);
                double val1 = f.F(p1[0], p1[1]), val2 = f.F(p2[0], p2[1]);
                return val1 < val2 ? -1 : val1 > val2 ? 1 : 0;
            });

            Entities = Entities.Take(initialCount).ToList();
        }

        private Vector GetBestPoint()
        {
            Vector bp = Entities[0].GeneCoding.RealPosition(ref f.Bounds);
            for (int i = 1; i < Entities.Count; i++)
            {
                Vector p = Entities[i].GeneCoding.RealPosition(ref f.Bounds);
                if (f.F(p[0], p[1]) < f.F(bp[0], bp[1]))
                {
                    bp = p;
                }
            }
            return bp;
        }
    }
}
