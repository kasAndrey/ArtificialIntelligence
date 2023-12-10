namespace ArtificialIntelligence.DataMining
{
    public class DataMiningStructure
    {
        public enum DataType
        {
            String,
            Number
        }

        protected readonly List<string[]> data;

        public DataType[]? Types { get; private set; }
        public string[] Headers;

        private readonly Dictionary<string, int> stringIndexPair;
        private const string separator = ";";

        protected double[] maxValuesForTypes, minValuesForTypes;

        public int Count { get { return data.Count; } }

        private DataMiningStructure(List<string[]> data, string[] headers)
        {
            this.data = data;
            Types = null;
            Headers = headers;
            stringIndexPair = new();
            minValuesForTypes = new double[headers.Length];
            maxValuesForTypes = new double[headers.Length];
            for (int i = 0; i < headers.Length; i++)
            {
                minValuesForTypes[i] = double.PositiveInfinity;
                maxValuesForTypes[i] = double.NegativeInfinity;
            }
        }

        protected DataMiningStructure(in DataMiningStructure other)
        {
            data = other.data;
            Types = other.Types;
            Headers = other.Headers;
            stringIndexPair = other.stringIndexPair;
            minValuesForTypes = other.minValuesForTypes;
            maxValuesForTypes = other.maxValuesForTypes;
        }

        public static DataMiningStructure LoadFromFile(string path, bool headers = true)
        {
            string[] dataRecords = File.ReadAllLines(path);
            if (dataRecords.Length < 2) throw new ArgumentException("File has not enough lines to form data");
            string[] first = dataRecords[0].Split(separator);

            List<string[]> data = new();
            for (int i = headers ? 1 : 0; i < dataRecords.Length; i++)
            {
                string[] record = dataRecords[i].Split(separator);
                if (record.Length != first.Length)
                {
                    throw new ArgumentException($"File is incorrect, line {i} has different amount of values");
                }

                data.Add(record);
            }

            string[] GenerateHeaders()
            {
                string[] headers = new string[first.Length];
                for (int i = 0; i < first.Length; i++)
                {
                    headers[i] = $"Parameter {i + 1}";
                }
                return headers;
            }

            return new(data, headers ? first : GenerateHeaders());
        }

        public void SetTypes(DataType[] types)
        {
            Types = types;
            if (types.Length != Headers.Length)
            {
                throw new ArgumentException("Types array has different size than data record size");
            }
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i] == DataType.Number) continue;

                int k = 0;
                for (int j = 0; j < Count; j++)
                {
                    if (stringIndexPair.TryAdd(data[j][i], k)) k++;
                }
                //if (k >= Count / 2) Filter.Add(i);
            }

            MinimaxNormalization();
        }

        public double[] Difference(int index, in string[] otherData)
        {
            if (Types == null)
            {
                throw new ArgumentNullException(nameof(Types), "Types of data records are unknown");
            }

            double[] diff = new double[otherData.Length];
            for (int i = 0; i < otherData.Length; i++)
            {
                if (otherData[i] == "")
                {
                    diff[i] = 0;
                }
                else
                {
                    diff[i] = (Types[i] switch
                    {
                        DataType.Number => Convert.ToDouble(data[index][i]) - Convert.ToDouble(otherData[i]),
                        DataType.String => stringIndexPair[data[index][i]] - stringIndexPair[otherData[i]],
                        _ => 0
                    }) / (maxValuesForTypes[i] - minValuesForTypes[i]);
                }
            }

            return diff;
        }

        public string[][] GetData() => data.ToArray();

        public virtual string Classify(string[] dataRecord, int indexValue)
        {
            throw new NotImplementedException();
        }

        private void MinimaxNormalization()
        {
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Types!.Length; j++)
                {
                    double value = Types[j] == DataType.Number ? Convert.ToDouble(data[i][j]) : Convert.ToDouble(stringIndexPair[data[i][j]]);
                    if (value < minValuesForTypes[j]) minValuesForTypes[j] = value;
                    if (value > maxValuesForTypes[j]) maxValuesForTypes[j] = value;
                }
            }
        }
    }
}
