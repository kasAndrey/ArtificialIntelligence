namespace MathObjects
{
    public class GraphEdge
    {
        public enum EdgeType
        {
            Unoriented = 0,
            Oriented = 1
        }

        public int FirstVertex, SecondVertex;
        public double Weight;
        public EdgeType Orientation;

        public GraphEdge(int first, int second, EdgeType orientation, double weight)
        {
            FirstVertex = first;
            SecondVertex = second;
            Orientation = orientation;
            Weight = weight;
        }
    }

    public class GraphPath : List<int>
    {
        public GraphPath() : base() { }

        public GraphPath(List<int> other) : base(other)
        { }

        protected const string goesTo = "->";

        public bool ContainPath(int first, int second)
        {
            int firstAt = IndexOf(first);
            return this[(firstAt + 1) % Count] == second;
        }

        public override string ToString()
        {
            string repr = "";
            for (int i = 0; i < Count; i++)
            {
                repr += this[i].ToString() + (i == Count - 1 ? "" : $" {goesTo} ");
            }

            return repr;
        }

        public virtual string ToString(bool loop)
        {
            if (Count == 0) return "";

            return ToString() + (loop ? $" {goesTo} {this[0]}" : "");
        }

        public double Distance(in Graph graph, bool loop = false)
        {
            double result = 0;
            for (int i = 1; i < Count; i++)
            {
                result += graph[this[i - 1], this[i]];
            }
            result += loop ? graph[this.Last(), this[0]] : 0;
            return result;
        }
    }

    public class Graph : Matrix
    {
        public const double NoPath = double.PositiveInfinity;
        public int VertexCount
        {
            get => Rows;
        }

        public Graph(int vertexCount, GraphEdge[] edges) : base(vertexCount, vertexCount, NoPath)
        {
            foreach (GraphEdge edge in edges)
            {
                this[edge.FirstVertex, edge.SecondVertex] = edge.Weight;

                if (edge.Orientation == GraphEdge.EdgeType.Unoriented) this[edge.SecondVertex, edge.FirstVertex] = edge.Weight;
            }
        }

        public static Graph Empty(int vertexCount) => new(vertexCount, Array.Empty<GraphEdge>());

        public GraphPath AdjecentVerticesToVertex(int vertex)
        {
            GraphPath result = new();

            for (int i = 0; i < VertexCount; i++)
            {
                if (this[vertex, i] != NoPath) result.Add(i);
            }

            return result;
        }

        public int VertexDegree(int vertexIndex) => AdjecentVerticesToVertex(vertexIndex).Count;
    }
}
