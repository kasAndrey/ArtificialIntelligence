using ArtificialIntelligence.MathObjects;
using System.Net;
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
        private const int margin = 10;
        private double bezierCoeff;

        private readonly Pen vertexPen;
        private readonly Pen pathPen;
        private readonly Pen edgePen;
        private readonly Brush textBrush;
        private readonly Brush valueBrush;

        public DisplayableGraph(DisplayableVertex[] vertices, GraphEdge[] edges) : base(vertices.Length, edges)
        {
            Vertices = vertices; 
            vertexPen = new Pen(Color.Black);
            edgePen = new Pen(Color.Black)
            {
                Width = 0.75f
            };
            pathPen = new Pen(Color.Red)
            {
                Width = 1.75f,
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
            };
            textBrush = new SolidBrush(Color.Blue);
            valueBrush = new SolidBrush(Color.Orange);
            bezierCoeff = 30.0 / VertexCount;
        }

        public void Draw(in Graphics g)
        {
            g.Clear(Color.White);
            for (int i = 0; i < VertexCount; i++)
            {
                for (int j = 0; j < VertexCount; j++)
                {
                    if (this[i, j] != NoPath)
                    {
                        DrawArrow(g, i, j);
                    }
                }
            }

            foreach (DisplayableVertex vertex in Vertices)
            {
                int tempX = vertex.X - vertexSize / 2;
                int tempY = vertex.Y - vertexSize / 2;
                g.FillEllipse(new SolidBrush(Color.White), new Rectangle(tempX, tempY, vertexSize, vertexSize));
                g.DrawEllipse(vertexPen, new Rectangle(tempX, tempY, vertexSize, vertexSize));
                g.DrawString(vertex.Name, new Font("Arial", vertexSize / 2), textBrush, tempX + 1f, tempY + 1f);
            }
        }

        public void FixGraphics(in Graphics g, in Rectangle bounds)
        {
            float minX = float.PositiveInfinity, minY = float.PositiveInfinity;
            float maxX = float.NegativeInfinity, maxY = float.NegativeInfinity;
            for (int i = 0; i < VertexCount; i++)
            {
                DisplayableVertex v = Vertices[i];
                if (minX > v.X) minX = v.X;
                if (minY > v.Y) minY = v.Y;
                if (maxX < v.X) maxX = v.X;
                if (maxY < v.Y) maxY = v.Y;
            }
            float sx = bounds.Width / (maxX - minX + margin * 2), sy = bounds.Height / (maxY - minY + margin * 2);
            g.ScaleTransform(sx, sy);
            g.TranslateTransform(-minX + margin, -minY + margin);
        }

        public void DrawPath(in Graphics g, GraphPath vertex, bool loop = false)
        {
            for (int i = 1; i < vertex.Count + (loop ? 1 : 0); i++)
            {
                DisplayableVertex first = Vertices[vertex[i - 1]], second = Vertices[vertex[i % vertex.Count]];
                Vector direction = new Vector((double)(second.X - first.X), (double)(second.Y - first.Y)).Normalized();
                Point midpoint = new((first.X + second.X) / 2 - (int)(bezierCoeff * direction[1]), (first.Y + second.Y) / 2 + (int)(bezierCoeff * direction[0]));

                g.DrawCurve(pathPen, new Point[] { new Point(first.X, first.Y), midpoint, new Point(second.X, second.Y) });
            }
        }

        private void DrawArrow(in Graphics g, int firstIndex, int secondIndex)
        {
            double angle = DegToRad(30);
            double length = 6.6;

            DisplayableVertex first = Vertices[firstIndex], second = Vertices[secondIndex];

            Vector direction = new Vector((double)(second.X - first.X), (double)(second.Y - first.Y)).Normalized();
            Point realFirst = new(first.X + (int)(direction[0] * vertexSize / 2), first.Y + (int)(direction[1] * vertexSize / 2));
            Point realSecond = new(second.X - (int)(direction[0] * vertexSize / 2), second.Y - (int)(direction[1] * vertexSize / 2));
            
            Point midpoint = new((realFirst.X + realSecond.X) / 2 - (int)(bezierCoeff * direction[1]), (realFirst.Y + realSecond.Y) / 2 + (int)(bezierCoeff * direction[0]));

            g.DrawCurve(edgePen, new Point[] { realFirst, midpoint, realSecond });

            Vector arrowLDirection = Rotate2(direction, angle), arrowRDirection = Rotate2(direction, -angle);
            
            Point arrowL = new(midpoint.X - (int)(arrowLDirection[0] * length), midpoint.Y - (int)(arrowLDirection[1] * length));
            Point arrowR = new(midpoint.X - (int)(arrowRDirection[0] * length), midpoint.Y - (int)(arrowRDirection[1] * length));
            g.DrawLine(edgePen, midpoint, arrowL);
            g.DrawLine(edgePen, midpoint, arrowR);

            g.DrawString(this[firstIndex, secondIndex].ToString(), new Font("Arial", vertexSize / 3f), valueBrush, midpoint);
        }
    }
}
