using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.MathObjects
{
    public class Graph : Matrix
    {
        public Graph(int degree) : base(degree, degree)
        {

        }

        public double EdgeWeight(int vertexFrom, int vertexTo) => this[vertexFrom, vertexTo];
    }
}
