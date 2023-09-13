using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.NeuralNetwork
{
    [Serializable]
    public struct HammingNNBrain
    {
        public int ReferenceImagesCount { get; private set; }
        public int ImageComponentsCount { get; private set; }

        private Matrix neuronWeights, feedbackWeights;
        private double actFunctionLB, actFunctionUB;

        private void ApplyActivationFunction(ref Vector s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < actFunctionLB) s[i] = actFunctionLB;
                else if (s[i] > actFunctionUB) s[i] = actFunctionUB;
            }
        }

        public static HammingNNBrain Create(Vector[] images)
        {
            HammingNNBrain instance = new();
            instance.ReferenceImagesCount = images.Length;
            instance.ImageComponentsCount = images[0].Length;

            foreach (Vector image in images)
            {
                if (image.Length != instance.ImageComponentsCount)
                {
                    throw new ArgumentException("Images have different components count");
                }
            }
            
            instance.actFunctionLB = 0;
            instance.actFunctionUB = instance.ImageComponentsCount / 2.0;
            instance.neuronWeights = new(instance.ReferenceImagesCount, instance.ImageComponentsCount);

            for (int i = 0; i < instance.ReferenceImagesCount; i++)
            {
                for (int j = 0; j < instance.ImageComponentsCount; j++)
                {
                    instance.neuronWeights[i, j] = images[i][j] / 2;
                }
            }

            instance.feedbackWeights = new(instance.ReferenceImagesCount, instance.ReferenceImagesCount);
            for (int i = 0; i < instance.ReferenceImagesCount; i++)
            {
                for (int j = 0; j < instance.ReferenceImagesCount; j++)
                {
                    instance.feedbackWeights[i, j] = i == j ? 1.0 : -1.0 / instance.ImageComponentsCount; 
                }
            }
            return instance;
        }

        public Vector FirstStep(Vector unknownImage)
        {
            Vector results = (Vector)(neuronWeights * unknownImage + new Vector(ReferenceImagesCount, ImageComponentsCount / 2.0));
            ApplyActivationFunction(ref results);

            return results;
        }

        public Vector SecondStep(Vector output)
        {
            Vector nextOutput = (Vector)(feedbackWeights * output);
            ApplyActivationFunction(ref nextOutput);
            
            return nextOutput;
        }
    }
}
