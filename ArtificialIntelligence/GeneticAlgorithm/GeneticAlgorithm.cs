using ArtificialIntelligence.GraphicsMGMT;
using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.GeneticAlgorithm
{
    public class GeneticAlgorithm
    {
        public List<Entity> Entities;
        public double CrossingoverPossibility;
        public double PopulationCrossingoverWeight;
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
            double populationCrossingoverWeight = 0.5,
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
                    EntityCodingType.Binary => new BinaryGeneCoding((uint)(rnd.NextDouble() * ~0u), (uint)(rnd.NextDouble() * ~0u)),
                    EntityCodingType.Real => new RealGeneCoding(rnd.NextDouble(), rnd.NextDouble()),
                    _ => throw new NotImplementedException()
                };
                Entities.Add(new(coding));
            }

            this.f = f;
            CrossingoverPossibility = crossingoverPossibility;
            PopulationCrossingoverWeight = populationCrossingoverWeight;
            MutationPossibility = mutationPossibility;

            globalBestPoint = GetBestPoint();
        }

        public Vector FindMinimum()
        {
            Vector previous;
            int sameResults = 0;
            while (sameResults < 5 && Entities.Count > 1)
            {
                previous = globalBestPoint;
                NextGeneration();
                if ((previous - globalBestPoint).SqrMagnitude() < 1e-6) sameResults++;
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
            Entities.Sort((Entity e1, Entity e2) => {
                Vector p1 = e1.GeneCoding.RealPosition(ref f.Bounds);
                Vector p2 = e2.GeneCoding.RealPosition(ref f.Bounds);
                double val1 = f.F(p1[0], p1[1]), val2 = f.F(p2[0], p2[1]);
                return val1 < val2 ? -1 : val1 > val2 ? 1 : 0;
                });

            List<Entity> newEntitiesGeneration = Entities.Take((int)(Entities.Count * PopulationCrossingoverWeight)).ToList();

            for (int i = 1; i < Entities.Count / 2; i++)
            {
                if (rnd.NextDouble() < CrossingoverPossibility)
                    newEntitiesGeneration.Add(new(newEntitiesGeneration[i - 1].GeneCoding.CrossingoverWith(newEntitiesGeneration[i].GeneCoding, ref rnd)));
            }
            Entities = newEntitiesGeneration;
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
