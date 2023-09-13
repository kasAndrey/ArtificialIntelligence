using ArtificialIntelligence.MathObjects;
using System.Runtime.Serialization;

namespace ArtificialIntelligence.NeuralNetwork
{
    public interface INeuralNetwork
    {
        public void Train(Vector[] referenceImages);

        public void Recognize(Vector image);

        /*public void Load(object data);
        
        public object Save();*/
    }
}
