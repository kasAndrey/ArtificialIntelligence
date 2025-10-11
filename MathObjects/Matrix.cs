namespace MathObjects
{
    public class Matrix
    {
        private readonly double[,] data;

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Matrix(int rows, int columns, double initValue = 0)
        {
            Rows = rows; Columns = columns;
            data = new double[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    data[i, j] = initValue;
                }
            }
        }

        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.Columns != B.Rows)
            {
                throw new ArgumentException("Invalid size of Matrices: Matrix A should have same number of columns as Matrix B rows");
            }

            Matrix c = new(A.Rows, B.Columns);

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < B.Columns; j++)
                {
                    for (int k = 0; k < A.Columns; k++)
                    {
                        c[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return c;
        }

        public override int GetHashCode() => data.GetHashCode();

        public override bool Equals(object? obj)
        {
            return obj is Matrix m && this == m;
        }

        public static bool operator ==(Matrix A, Matrix B)
        {
            if (A.Columns != B.Columns || A.Rows != B.Rows) return false;

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Columns; j++)
                {
                    if (A[i, j] != B[i, j]) return false;
                }
            }

            return true;
        }

        public static bool operator !=(Matrix A, Matrix B) => !(A == B);

        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (!(A.Columns == B.Columns && A.Rows == B.Rows))
            {
                throw new ArgumentException("Invalid size of Matrices: Matrix A should have same size as Matrix B");
            }

            Matrix c = new(A.Rows, A.Columns);

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Columns; j++)
                {
                    c[i, j] = A[i, j] + B[i, j];
                }
            }
            return c;
        }

        public static Matrix operator -(Matrix A)
        {
            Matrix c = new(A.Rows, A.Columns);

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Columns; j++)
                {
                    c[i, j] = -A[i, j];
                }
            }

            return c;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            return A + (-B);
        }

        public static explicit operator Vector(Matrix A)
        {
            Vector c = new(A.Rows);
            for (int i = 0; i < A.Rows; i++)
            {
                c[i] = A[i, 0];
            }
            return c;
        }

        public Matrix Transpose()
        {
            Matrix c = new(Columns, Rows);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    c[j, i] = this[i, j];
                }
            }
            return c;
        }

        public override string ToString()
        {
            string repr = "";
            for (int i = 0; i < Rows; i++)
            {
                repr += "[";
                for (int j = 0; j < Columns; j++)
                {
                    repr += $"{this[i, j]}" + (j == Columns - 1 ? "]\n" : " ");
                }
            }
            return repr;
        }
    }
}
