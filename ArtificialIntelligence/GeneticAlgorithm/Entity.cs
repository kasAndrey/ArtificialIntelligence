using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.GeneticAlgorithm
{
    public enum EntityCodingType
    {
        Binary,
        Real
    }

    public interface IEntityGeneCoding
    {
        public void Mutate(ref Random rnd);
        public IEntityGeneCoding CrossingoverWith(IEntityGeneCoding other, ref Random rnd);
        public Vector RealPosition(ref RectangleF field);
    }

    public class BinaryGeneCoding : IEntityGeneCoding
    {
        public uint PositionX, PositionY;

        public BinaryGeneCoding(uint bitsX, uint bitsY)
        {
            PositionX = bitsX;
            PositionY = bitsY;
        }

        public void Mutate(ref Random rnd)
        {
            int i1 = rnd.Next(0, 32);
            int i2 = rnd.Next(0, 32);
            int j1 = rnd.Next(0, 32);
            int j2 = rnd.Next(0, 32);

            PositionX = (uint)((int)PositionX ^ (1 << i1) ^ (1 << i2));
            PositionY = (uint)((int)PositionY ^ (1 << j1) ^ (1 << j2));
        }

        public IEntityGeneCoding CrossingoverWith(IEntityGeneCoding other, ref Random rnd)
        {
            if (other is not BinaryGeneCoding) throw new ArgumentException("Other entity must have same entity gene coding");

            int maskX = (~0) << rnd.Next(0, 31);
            int maskY = (~0) << rnd.Next(0, 31);
            uint newX = (uint)(PositionX & maskX | (other as BinaryGeneCoding)!.PositionX & ~maskX);
            uint newY = (uint)(PositionY & maskY | (other as BinaryGeneCoding)!.PositionY & ~maskY);

            return new BinaryGeneCoding(newX, newY);
        }

        public Vector RealPosition(ref RectangleF field)
        {
            return new(
                (double)PositionX / uint.MaxValue * field.Width + field.Left,
                (double)PositionY / uint.MaxValue * field.Height + field.Top
                );
        }
    }

    public class RealGeneCoding : IEntityGeneCoding
    {
        public double PositionX, PositionY;

        public RealGeneCoding(double positionX, double positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public IEntityGeneCoding CrossingoverWith(IEntityGeneCoding other, ref Random rnd)
        {
            if (other is not RealGeneCoding) throw new ArgumentException("Other entity must have same entity gene coding");

            double weightX = rnd.NextDouble();
            double weightY = rnd.NextDouble();
            double newX = weightX * PositionX + (1 - weightX) * (other as RealGeneCoding)!.PositionX;
            double newY = weightY * PositionY + (1 - weightY) * (other as RealGeneCoding)!.PositionY;

            return new RealGeneCoding(newX, newY);
        }

        public void Mutate(ref Random rnd)
        {
            PositionX += (rnd.NextDouble() - 0.5) / 2;
            PositionY += (rnd.NextDouble() - 0.5) / 2;
        }

        public Vector RealPosition(ref RectangleF field)
        {
            return new(PositionX * field.Width + field.Left, PositionY * field.Height + field.Top);
        }
    }

    public class Entity
    {
        public IEntityGeneCoding GeneCoding;

        public Entity(IEntityGeneCoding geneCoding) => GeneCoding = geneCoding;
    }
}
