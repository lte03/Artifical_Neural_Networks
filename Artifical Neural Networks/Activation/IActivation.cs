using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifical_Neural_Networks.Activation
{
    public interface IActivation
    {
        public double Function(double input);
        public double DerivativeFunction(double input);
    }
}
