using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.Lab1Hamming
{
    [Serializable]
    public class HammingNNBrain
    {
        public int ReferenceImagesCount { get; private set; }
        public int ImageComponentsCount { get; private set; }

        private Matrix neuronWeights, feedbackWeights;
        private double actFunctionLB, actFunctionUB;

        public HammingNNBrain()
        {
            ReferenceImagesCount = 0; ImageComponentsCount = 0;
            actFunctionLB = 0; actFunctionUB = 0;
            neuronWeights = new(0, 0);
            feedbackWeights = neuronWeights;
        }

        private void ApplyZActivationFunction(ref Vector s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < actFunctionLB) s[i] = actFunctionLB;
                else if (s[i] > actFunctionUB) s[i] = actFunctionUB;
                else s[i] *= 0.5;
            }
        }

        private void ApplyAActivationFunction(ref Vector s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < 0) s[i] = 0;
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
            instance.actFunctionUB = instance.ImageComponentsCount;
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
                    instance.feedbackWeights[i, j] = i == j ? 1.0 : -1.0 / instance.ReferenceImagesCount;
                }
            }
            return instance;
        }

        public Vector FirstStep(Vector unknownImage)
        {
            Vector results = new Vector(ReferenceImagesCount, ImageComponentsCount / 2.0) + (Vector)(neuronWeights * unknownImage);
            ApplyZActivationFunction(ref results);

            return results;
        }

        public Vector SecondStep(Vector output)
        {
            Vector nextOutput = (Vector)(feedbackWeights * output);
            ApplyAActivationFunction(ref nextOutput);

            return nextOutput;
        }

        public void FilterValues(ref Vector values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > 0) values[i] = 1;
            }
        }
    }
}
