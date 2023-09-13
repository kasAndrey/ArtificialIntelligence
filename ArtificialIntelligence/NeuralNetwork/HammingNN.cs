using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.NeuralNetwork
{
    public delegate void DebugInfo(string textInfo);

    public class HammingNN : INeuralNetwork
    {
        private const double maxSqrError = 1e-2;

        private HammingNNBrain brain;

        public event DebugInfo? Debugger;

        public HammingNN()
        {
            brain = new();
        }

        public void Train(Vector[] images) => brain = HammingNNBrain.Create(images);
        
        public void Recognize(Vector image)
        {
            if (image.Length != brain.ImageComponentsCount)
            {
                throw new ArgumentException("Unknown image's components count differs from reference images'");
            }

            Vector o1 = brain.FirstStep(image), o2 = brain.SecondStep(o1);
            Debugger?.Invoke($"{o1}\n{o2}");

            while ((o2 - o1).SqrMagnitude() > maxSqrError)
            {
                o1 = o2;
                o2 = brain.SecondStep(o1);

                Debugger?.Invoke(o2.ToString());
            }
        }

        /*public void Load(object data)
        {
            if (data is HammingNNBrain hammingNNbrain)
            {
                brain = hammingNNbrain;
            }
            else
            {
                throw new ArgumentException("Invalid data");
            }
        }

        public object Save() => brain;*/
    }
}
