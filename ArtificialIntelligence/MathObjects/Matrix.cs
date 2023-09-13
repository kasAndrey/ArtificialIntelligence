namespace ArtificialIntelligence.MathObjects
{
    public class Matrix
    {
        private double[,] data;

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Matrix(int rows, int columns)
        {
            Rows = rows; Columns = columns;
            data = new double[Rows, Columns];
        }

        public double this[int i, int j]
        {
            get { return data[i, j]; }
            private set { data[i, j] = value; }
        }

        public static Matrix operator * (Matrix A, Matrix B)
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

        public Matrix Transpose()
        {
            Matrix c = new (Rows, Columns);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    c[i, j] = this[j, i];
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
