using ArtificialIntelligence.MathObjects;

namespace ArtificialIntelligence.NeuralNetwork
{
    public interface INeuralNetwork
    {
        public void Train(Vector[] referenceImages);

        public int Recognize(Vector image);

        /*public void Load(object data);
        
        public object Save();*/
    }
}
