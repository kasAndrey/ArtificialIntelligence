namespace ArtificialIntelligence.MathObjects
{
    public class Vector
    {
        private double[] data;
        public int Length { get; private set; }

        public Vector(int length, double initValue = 0)
        {
            Length = length;
            data = new double[Length];
            for (int i = 0; i < Length; i++)
            {
                data[i] = initValue;
            }
        }

        public double this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }

        public static Vector operator +(Vector A, Vector B)
        {
            if (A.Length != B.Length)
            {
                throw new ArgumentException("Vectors have different sizes");
            }

            Vector c = new(A.Length);
            for (int i = 0; i < A.Length; i++)
            {
                c[i] = A[i] + B[i];
            }

            return c;
        }

        public static Vector operator -(Vector A)
        {
            Vector c = new(A.Length);
            for (int i = 0; i < A.Length; i++)
            {
                c[i] = -A[i];
            }

            return c;
        }

        public static Vector operator -(Vector A, Vector B)
        {
            return A + (-B);
        }

        public static implicit operator Matrix(Vector A)
        {
            Matrix c = new(A.Length, 1);
            for (int i = 0; i < A.Length; i++)
            {
                c[i, 0] = A[i];
            }
            return c;
        }

        public static double DotProduct(Vector A, Vector B)
        {
            if (A.Length != B.Length)
            {
                throw new ArgumentException("Vectors have different sizes");
            }

            double result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                result += A[i] * B[i];
            }

            return result;
        }

        public double SqrMagnitude() => DotProduct(this, this);

        public override string ToString()
        {
            string repr = "[";
            for (int i = 0; i < Length; i++)
            {
                repr += $"{this[i]}" + (i == Length - 1 ? "]" : " ");
            }
            return repr;
        }
    }
}
