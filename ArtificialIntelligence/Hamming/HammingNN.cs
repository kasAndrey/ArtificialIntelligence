using ArtificialIntelligence.MathObjects;
using ArtificialIntelligence.NeuralNetwork;

namespace ArtificialIntelligence.Hamming
{
    public class HammingNN : INeuralNetwork
    {
        private const double maxSqrError = 1e-2;

        private HammingNNBrain brain;

        public HammingNN()
        {
            brain = new();
        }

        public void Train(Vector[] images) => brain = HammingNNBrain.Create(images);

        public int Recognize(Vector image)
        {
            if (image.Length != brain.ImageComponentsCount)
            {
                throw new ArgumentException("Unknown image's components count differs from reference images'");
            }

            Vector o1 = brain.FirstStep(image), o2 = brain.SecondStep(o1);

            while ((o2 - o1).SqrMagnitude() > maxSqrError)
            {
                o1 = o2;
                o2 = brain.SecondStep(o1);
            }

            int referenceImageIndex = -1, possibleImages = 0;
            for (int i = 0; i < o2.Length; i++)
            {
                if (o2[i] != 0)
                {
                    referenceImageIndex = i;
                    possibleImages++;
                }
            }

            brain.FilterValues(ref o2);

            return possibleImages == 1 ? referenceImageIndex : -1;
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
