namespace ArtificialIntelligence.DataMining
{
    public class KNearestNeighbors : DataMiningStructure
    {
        public int NeighborsCount;

        public KNearestNeighbors(string dataFilePath, bool hasHeaders = true, int k = 5)
            : base(LoadFromFile(dataFilePath, hasHeaders))
        {
            NeighborsCount = k;
        }

        public override string Classify(string[] dataRecord, int indexValue)
        {
            Dictionary<int, double> distances = new();
            for (int i = 0; i < Count; i++)
            {
                double[] differences = Difference(i, dataRecord);
                double sumsqr = 0;
                for (int j = 0; j < differences.Length; j++)
                {
                    sumsqr += differences[j] * differences[j];
                }
                distances.Add(i, sumsqr);
            }

            List<KeyValuePair<int, double>> neighbors = distances.ToList();
            neighbors.Sort((KeyValuePair<int, double> first, KeyValuePair<int, double> second) => first.Value > second.Value ? 1 : first.Value < second.Value ? -1 : 0);
            neighbors = neighbors.Take(NeighborsCount).ToList();

            string result = "";
            switch (Types![indexValue])
            {
                case DataType.String:
                    Dictionary<string, int> counts = new();
                    foreach (var pair in neighbors)
                    {
                        if (!counts.TryAdd(data[pair.Key][indexValue], 1))
                        {
                            counts[data[pair.Key][indexValue]]++;
                        }
                    }
                    result = counts.First(elem => elem.Value == counts.Values.Max()).Key;
                    break;
                case DataType.Number:
                    double regressionValue = 0;
                    foreach (var pair in neighbors)
                    {
                        regressionValue += Convert.ToDouble(data[pair.Key][indexValue]);
                    }
                    result = (regressionValue / neighbors.Count).ToString();
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
