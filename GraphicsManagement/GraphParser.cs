using MathObjects;

namespace GraphicsManagement
{
    public static class GraphParser
    {
        public const string GraphsDirectory = @"..\..\..\Resources\Graphs\";

        public static DisplayableGraph Load(string path)
        {
            if (!File.Exists(path)) path = GraphsDirectory + path;

            StreamReader sr = File.OpenText(path);

            List<DisplayableVertex> vertices = new();
            List<GraphEdge> edges = new();

            int lineCount = 1;
            while (!sr.EndOfStream)
            {
                try
                {
                    string line = sr.ReadLine()!;

                    int commentIndex = line.IndexOf('#');
                    if (commentIndex != -1) line = line.Substring(0, commentIndex);

                    if (line == "") continue;

                    string[] args = line.Trim().Split(',');

                    if (lineCount == 1)
                    {
                        for (int i = 0; i < args.Length; i++)
                        {
                            vertices.Add(new DisplayableVertex(0, 0, args[i]));
                        }
                    }
                    else if (lineCount <= vertices.Count + 1)
                    {
                        vertices[lineCount - 2].X = Convert.ToInt32(args[0]);
                        vertices[lineCount - 2].Y = Convert.ToInt32(args[1]);
                    }
                    else if (lineCount <= vertices.Count * 2 + 1)
                    {
                        if (args.Length < vertices.Count) throw new ArgumentException($"Graph file has incorrect values in line {lineCount}. Argument count");

                        int j = lineCount - vertices.Count - 2;
                        for (int i = 0; i < vertices.Count; i++)
                        {
                            double weight;
                            try
                            {
                                weight = Convert.ToDouble(args[i]);
                            }
                            catch
                            {
                                weight = Graph.NoPath;
                            }

                            edges.Add(new GraphEdge(j, i, GraphEdge.EdgeType.Oriented, weight));
                        }
                    }
                    else continue;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"File parsing failed (line {lineCount}).\n{ex.Message}");
                }

                lineCount++;
            }

            return new(vertices.ToArray(), edges.ToArray());
        }
    }
}
