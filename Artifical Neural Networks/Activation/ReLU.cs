using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifical_Neural_Networks.Activation
{
    public class ReLU : IActivation
    {
        public double Function(double input)
        {
            if (input <= 0)
            {
                return 0;
            }
            else
            {
                return input;
            }
        }

        public double DerivativeFunction(double input)
        {
            if (input <= 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
