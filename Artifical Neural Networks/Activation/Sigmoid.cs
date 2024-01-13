using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifical_Neural_Networks.Activation
{
    public class Sigmoid : IActivation
    {
        public double Function(double input)
        {
            return 1.0 / (1.0 + Math.Exp(input));
        }

        public double DerivativeFunction(double input)
        {
            return Function(input) * (1.0 - Function(input));
        }
    }
}
