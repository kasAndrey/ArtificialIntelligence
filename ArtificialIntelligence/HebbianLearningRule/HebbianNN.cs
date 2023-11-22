using ArtificialIntelligence.MathObjects;
using ArtificialIntelligence.NeuralNetwork;

namespace ArtificialIntelligence.HebbianLearningRule
{
    public class HebbianNN : INeuralNetwork
    {
        public int ImagesCount { get; private set; }
        public int NeuronsCount { get; private set; }

        private Matrix? neuronWeights;
        private int componentsCount;

        public HebbianNN(int images)
        {
            ImagesCount = images;
            NeuronsCount = (int)Math.Log2(ImagesCount);
        }

        private double ActivationFunction(double val) => val > 0 ? 1 : -1;

        public int Recognize(Vector image)
        {
            if (neuronWeights is null) throw new ArgumentNullException(nameof(neuronWeights), "Neural Network should be trained first (use Train method)");

            Vector weightedImage = new(image.Count + 1, 1);
            for (int i = 0; i < image.Count; i++)
            {
                weightedImage[i + 1] = image[i];
            }

            Matrix signals = neuronWeights * weightedImage;
            
            int result = 0;
            for (int i = 0; i < NeuronsCount; i++)
            {
                result |= (ActivationFunction(signals[i, 0]) == 1 ? 1 : 0) << i;
            }

            return result;
        }

        public void Train(Vector[] referenceImages)
        {
            if (referenceImages.Length != ImagesCount) throw new ArgumentException($"Exactly {ImagesCount} images are needed");

            componentsCount = referenceImages[0].Count;

            for (int i = 1; i < ImagesCount; i++)
            {
                if (referenceImages[i].Count != componentsCount) throw new ArgumentException("Images have different components count!");
            }

            neuronWeights = new(NeuronsCount, componentsCount + 1);

            Matrix initialSignals = new(ImagesCount, NeuronsCount);
            for (int i = 0; i < ImagesCount; i++)
            {
                for (int j = 0; j < NeuronsCount; j++)
                {
                    initialSignals[i, j] = ((i >> j) & 1) == 1 ? 1 : -1;
                }
            }

            while (true)
            {
                Matrix currentSignals = new(ImagesCount, NeuronsCount);
                for (int k = 0; k < NeuronsCount; k++)
                {
                    for (int i = 0; i < ImagesCount; i++)
                    {
                        for (int j = 0; j < componentsCount + 1; j++)
                        {
                            if (j == 0)
                            {
                                neuronWeights[k, j] += initialSignals[i, k];
                                currentSignals[i, k] += neuronWeights[k, j];
                            }
                            else
                            {
                                neuronWeights[k, j] += initialSignals[i, k] * referenceImages[i][j - 1];
                                currentSignals[i, k] += neuronWeights[k, j] * referenceImages[i][j - 1];
                            }
                        }

                        currentSignals[i, k] = ActivationFunction(currentSignals[i, k]);
                    }
                }

                if (initialSignals == currentSignals) break;
            }
        }
    }
}
