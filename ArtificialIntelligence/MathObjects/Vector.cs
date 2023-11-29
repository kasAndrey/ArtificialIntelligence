namespace ArtificialIntelligence.MathObjects
{
    public class Vector
    {
        private double[] data;
        public int Count
        {
            get => data.Length;
        }

        public Vector(int length, double initValue = 0)
        {
            data = new double[length];
            for (int i = 0; i < Count; i++)
            {
                data[i] = initValue;
            }
        }

        public Vector(params double[] values) => data = values;

        public double this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }

        public static Vector operator +(Vector A, Vector B)
        {
            if (A.Count != B.Count)
            {
                throw new ArgumentException("Vectors have different sizes");
            }

            Vector c = new(A.Count);
            for (int i = 0; i < A.Count; i++)
            {
                c[i] = A[i] + B[i];
            }

            return c;
        }

        public static Vector operator -(Vector A)
        {
            Vector c = new(A.Count);
            for (int i = 0; i < A.Count; i++)
            {
                c[i] = -A[i];
            }

            return c;
        }

        public static Vector operator *(Vector A, double c)
        {
            Vector r = new(A.Count);
            for (int i = 0; i < A.Count; i++)
            {
                r[i] = c * A[i];
            }

            return r;
        }

        public static Vector operator -(Vector A, Vector B)
        {
            return A + (-B);
        }

        public static implicit operator Matrix(Vector A)
        {
            Matrix c = new(A.Count, 1);
            for (int i = 0; i < A.Count; i++)
            {
                c[i, 0] = A[i];
            }
            return c;
        }

        public static double DotProduct(Vector A, Vector B)
        {
            if (A.Count != B.Count)
            {
                throw new ArgumentException("Vectors have different sizes");
            }

            double result = 0;
            for (int i = 0; i < A.Count; i++)
            {
                result += A[i] * B[i];
            }

            return result;
        }

        public double Length() => Math.Sqrt(SqrMagnitude());

        public Vector Normalized()
        {
            Vector newVector = this;
            double l = Length();
            for (int i = 0; i < Count; i++) newVector[i] /= l;

            return newVector;
        }

        public double SqrMagnitude() => DotProduct(this, this);

        public override string ToString()
        {
            string repr = "[";
            for (int i = 0; i < Count; i++)
            {
                repr += $"{this[i]}" + (i == Count - 1 ? "" : " ");
            }
            return repr + "]";
        }
    }
}
