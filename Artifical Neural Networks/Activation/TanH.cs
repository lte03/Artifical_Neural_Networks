using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifical_Neural_Networks.Activation
{
    public class TanH : IActivation
    {
        public double Function(double input)
        {
            return Math.Tanh(input);
        }

        public double DerivativeFunction(double input)
        {
            return 1 - Math.Pow(Function(input), 2);
        }
    }
}
