using ArtificialIntelligence.GraphicsMGMT;
using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.GeneticAlgorithm
{
    public class GeneticAlgorithm
    {
        public class Entity
        {
            public uint PositionX, PositionY;

            private Random randomNumber;

            public Entity(uint bitsX, uint bitsY, ref Random seed)
            {
                randomNumber = seed;

                PositionX = bitsX;
                PositionY = bitsY;
            }

            public Entity(ref Random seed)
            {
                randomNumber = seed;

                PositionX = (uint)(uint.MaxValue * randomNumber.NextDouble());
                PositionY = (uint)(uint.MaxValue * randomNumber.NextDouble());
            }

            public Vector RealPosition(ref RectangleF field)
            {
                return new(
                    (double)PositionX / uint.MaxValue * field.Width + field.Left,
                    (double)PositionY / uint.MaxValue * field.Height + field.Top
                    );
            }

            public Entity CrossingoverWith(Entity other)
            {
                int maskX = (~0) << randomNumber.Next(0, 31);
                int maskY = (~0) << randomNumber.Next(0, 31);
                uint newX = (uint)(PositionX & maskX | other.PositionX & ~maskX);
                uint newY = (uint)(PositionY & maskY | other.PositionY & ~maskY);

                return new(newX, newY, ref randomNumber);
            }

            public void Mutate()
            {
                int i1 = randomNumber.Next(0, 32);
                int i2 = randomNumber.Next(0, 32);
                int j1 = randomNumber.Next(0, 32);
                int j2 = randomNumber.Next(0, 32);

                PositionX = (uint)((int)PositionX ^ (1 << i1) ^ (1 << i2));
                PositionY = (uint)((int)PositionY ^ (1 << j1) ^ (1 << j2));
            }
        }

        public List<Entity> Entities;
        public double CrossingoverPossibility;
        public double MutationPossibility;
        public Vector globalBestPoint;

        private Function f;
        private Random rnd;

        bool spawnToConstCount;

        public GeneticAlgorithm(int entitiesCount, Function f, double crossingoverPossibility = 0.9, double mutationPossibility = 0.25, bool spawn = true)
        {
            rnd = new Random();
            Entities = new();
            
            for (int i = 0; i < entitiesCount; i++)
            {
                Entities.Add(new(ref rnd));
            }

            this.f = f;
            CrossingoverPossibility = crossingoverPossibility;
            MutationPossibility = mutationPossibility;

            globalBestPoint = GetBestPoint();
            spawnToConstCount = spawn;
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
                if (rnd.NextDouble() < MutationPossibility) e.Mutate();
            }
            return globalBestPoint = GetBestPoint();
        }

        private void Crossingover()
        {
            Entities.Sort((Entity e1, Entity e2) => {
                Vector p1 = e1.RealPosition(ref f.Bounds);
                Vector p2 = e2.RealPosition(ref f.Bounds);
                double val1 = f.F(p1[0], p1[1]), val2 = f.F(p2[0], p2[1]);
                return val1 < val2 ? -1 : val1 > val2 ? 1 : 0;
                });

            List<Entity> newEntitiesGeneration = new(Entities.Take(Entities.Count / 2));

            for (int i = 1; i < Entities.Count / 2; i++)
            {
                if (rnd.NextDouble() < CrossingoverPossibility)
                    newEntitiesGeneration.Add(newEntitiesGeneration[i - 1].CrossingoverWith(newEntitiesGeneration[i]));
            }
            if (spawnToConstCount)
            {
                for (int i = newEntitiesGeneration.Count; i < Entities.Count; i++)
                {
                    newEntitiesGeneration.Add(new(ref rnd));
                }
            }
            Entities = newEntitiesGeneration;
        }

        private Vector GetBestPoint()
        {
            Vector bp = Entities[0].RealPosition(ref f.Bounds);
            for (int i = 1; i < Entities.Count; i++)
            {
                Vector p = Entities[i].RealPosition(ref f.Bounds);
                if (f.F(p[0], p[1]) < f.F(bp[0], bp[1]))
                {
                    bp = p;
                }
            }
            return bp;
        }
    }
}
