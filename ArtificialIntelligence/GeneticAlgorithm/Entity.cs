using MathObjects;

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

    public class GrayCode : BinaryGeneCoding
    {
        public GrayCode(uint bitsX, uint bitsY) : base(bitsX, bitsY) { }

        public new Vector RealPosition(ref RectangleF field)
        {
            uint oldPosX = PositionX, oldPosY = PositionY;
            uint realPosX, realPosY;
            for (realPosX = 0; oldPosX != 0; oldPosX >>= 1)
            {
                realPosX ^= oldPosX;
            }
            for (realPosY = 0; oldPosY != 0; oldPosY >>= 1)
            {
                realPosY ^= oldPosY;
            }

            return new(
                (double)realPosX / uint.MaxValue * field.Width + field.Left,
                (double)realPosY / uint.MaxValue * field.Height + field.Top
                );
        }
    }

    public class RealGeneCoding : IEntityGeneCoding
    {
        public double PositionX, PositionY;

        public RealGeneCoding(double positionX, double positionY)
        {
            PositionX = positionX > 1 ? 1 : positionX < 0 ? 0 : positionX;
            PositionY = positionY > 1 ? 1 : positionY < 0 ? 0 : positionY;
        }

        public IEntityGeneCoding CrossingoverWith(IEntityGeneCoding other, ref Random rnd)
        {
            if (other is not RealGeneCoding) throw new ArgumentException("Other entity must have same entity gene coding");

            double weightX = rnd.NextDouble();
            double weightY = rnd.NextDouble();
            double newX = weightX * PositionX + (1 - weightX) * (other as RealGeneCoding)!.PositionX;
            double newY = weightY * PositionY + (1 - weightY) * (other as RealGeneCoding)!.PositionY;

            newX = newX > 1 ? 1 : newX < 0 ? 0 : newX;
            newY = newY > 1 ? 1 : newY < 0 ? 0 : newY;

            return new RealGeneCoding(newX, newY);
        }

        public void Mutate(ref Random rnd)
        {
            PositionX += (rnd.NextDouble() - 0.5) / 2;
            PositionX = PositionX > 1 ? 1 : PositionX < 0 ? 0 : PositionX;
            PositionY += (rnd.NextDouble() - 0.5) / 2;
            PositionY = PositionY > 1 ? 1 : PositionY < 0 ? 0 : PositionY;
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
