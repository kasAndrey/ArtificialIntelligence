using ArtificialIntelligence.MathObjects;
using static ArtificialIntelligence.MathObjects.MathDefs;

namespace ArtificialIntelligence.AntColony
{
    public class DisplayableVertex
    {
        public int X, Y;
        public string Name;

        public DisplayableVertex(int x, int y, string name = "")
        {
            X = x;
            Y = y;
            Name = name;
        }

        public Point Point() => new(X, Y);
    }

    public class DisplayableGraphPath : GraphPath
    {
        DisplayableVertex[] vertices;

        public DisplayableGraphPath(DisplayableVertex[] vertices) : base()
        {
            this.vertices = vertices;
        }

        public void LoadPath(GraphPath other)
        {
            Clear();
            AddRange(other);
        }

        public override string ToString()
        {
            string repr = "";
            for (int i = 0; i < Count; i++)
            {
                repr += vertices[this[i]].Name + (i == Count - 1 ? "" : $" {goesTo} ");
            }

            return repr;
        }

        public override string ToString(bool loop)
        {
            if (Count == 0) return "";

            return ToString() + (loop ? $" {goesTo} {vertices[this[0]].Name}" : "");
        }
    }

    public class DisplayableGraph : Graph
    {
        public DisplayableVertex[] Vertices;

        private const int vertexSize = 10;
        private readonly Pen vertexPen;
        private readonly Pen pathPen;
        private readonly Pen edgePen;
        private readonly Brush textBrush;

        public DisplayableGraph(DisplayableVertex[] vertices, GraphEdge[] edges) : base(vertices.Length, edges)
        {
            Vertices = vertices; 
            vertexPen = new Pen(Color.Black);
            edgePen = new Pen(Color.Black);
            pathPen = new Pen(Color.Red)
            {
                Width = 1.75f,
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
            };
            textBrush = new SolidBrush(Color.Black);
        }

        public void Draw(in Graphics g)
        {
            for (int i = 0; i < VertexCount; i++)
            {
                for (int j = 0; j < VertexCount; j++)
                {
                    if (this[i, j] != NoPath)
                    {
                        DrawArrow(g, Vertices[i], Vertices[j]);
                        //SpecifyValue(g, i, j);
                    }
                }
            }

            foreach (DisplayableVertex vertex in Vertices)
            {
                int tempX = vertex.X - vertexSize / 2;
                int tempY = vertex.Y - vertexSize / 2;
                g.FillEllipse(new SolidBrush(Color.White), new Rectangle(tempX, tempY, vertexSize, vertexSize));
                g.DrawEllipse(vertexPen, new Rectangle(tempX, tempY, vertexSize, vertexSize));
                g.DrawString(vertex.Name, new Font("Arial", 12f), textBrush, tempX + vertexSize / 2, tempY + vertexSize / 2);
            }
        }

        public void FixGraphics(in Graphics g)
        {
            // Need update
            g.TranslateTransform(100, 100);
            g.ScaleTransform(2, 2);
        }

        public void DrawPath(in Graphics g, GraphPath vertex, bool loop = false)
        {
            for (int i = 1; i < vertex.Count; i++)
            {
                DisplayableVertex first = Vertices[vertex[i - 1]], second = Vertices[vertex[i]];
                g.DrawLine(pathPen, first.X, first.Y, second.X, second.Y);
            }
            if (loop) g.DrawLine(pathPen, Vertices[vertex.Last()].X, Vertices[vertex.Last()].Y, Vertices[0].X, Vertices[0].Y);
        }

        private void DrawArrow(in Graphics g, DisplayableVertex first, DisplayableVertex second)
        {
            // Need update
            double angle = DegToRad(30);
            double length = 6.6;

            Vector direction = new Vector((double)(second.X - first.X), (double)(second.Y - first.Y)).Normalized();
            Point realFirst = new(first.X + (int)(direction[0] * vertexSize / 2), first.Y + (int)(direction[1] * vertexSize / 2));
            Point realSecond = new(second.X - (int)(direction[0] * vertexSize / 2), second.Y - (int)(direction[1] * vertexSize / 2));

            g.DrawLine(edgePen, realFirst, realSecond);

            Vector arrowLDirection = Rotate2(direction, angle), arrowRDirection = Rotate2(direction, -angle);
            
            Point arrowL = new(realSecond.X - (int)(arrowLDirection[0] * length), realSecond.Y - (int)(arrowLDirection[1] * length));
            Point arrowR = new(realSecond.X - (int)(arrowRDirection[0] * length), realSecond.Y - (int)(arrowRDirection[1] * length));
            g.DrawLine(edgePen, realSecond, arrowL);
            g.DrawLine(edgePen, realSecond, arrowR);
        }
    }
}
